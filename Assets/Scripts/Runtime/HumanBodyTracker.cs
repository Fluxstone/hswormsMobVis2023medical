using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

namespace UnityEngine.XR.ARFoundation.Samples
{
    public class HumanBodyTracker : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The Skeleton prefab to be controlled.")]
        GameObject m_SkeletonPrefab;

        [SerializeField]
        [Tooltip("The ARHumanBodyManager which will produce body tracking events.")]
        ARHumanBodyManager m_HumanBodyManager;

        /// <summary>
        /// Get/Set the <c>ARHumanBodyManager</c>.
        /// </summary>
        public ARHumanBodyManager humanBodyManager
        {
            get { return m_HumanBodyManager; }
            set { m_HumanBodyManager = value; }
        }

        /// <summary>
        /// Get/Set the skeleton prefab.
        /// </summary>
        public GameObject skeletonPrefab
        {
            get { return m_SkeletonPrefab; }
            set { m_SkeletonPrefab = value; }
        }

        Dictionary<TrackableId, BoneController> m_SkeletonTracker = new Dictionary<TrackableId, BoneController>();

        void OnEnable()
        {
            Debug.Assert(m_HumanBodyManager != null, "Human body manager is required.");
            m_HumanBodyManager.humanBodiesChanged += OnHumanBodiesChanged;
        }

        void OnDisable()
        {
            if (m_HumanBodyManager != null)
                m_HumanBodyManager.humanBodiesChanged -= OnHumanBodiesChanged;
        }

        //Objects
        public GameObject sphere1;
        public bool sp1Spawned = false;

        private void drawSphere1(float x,float y,float z)
        {
            sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere1.transform.position = new Vector3(x, y, z);
            sphere1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            sp1Spawned = true;
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "V1")
            {
                Debug.Log("AR Marker collided with the sphere.");
            }
        }

        
        void OnHumanBodiesChanged(ARHumanBodiesChangedEventArgs eventArgs)
        {
            BoneController boneController;

            foreach (var humanBody in eventArgs.added)
            {
                if (!m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    Debug.Log($"Adding a new skeleton [{humanBody.trackableId}].");
                    var newSkeletonGO = Instantiate(m_SkeletonPrefab, humanBody.transform);
                    boneController = newSkeletonGO.GetComponent<BoneController>();
                    m_SkeletonTracker.Add(humanBody.trackableId, boneController);
                }

                boneController.InitializeSkeletonJoints();
                boneController.ApplyBodyPose(humanBody);
            }

            foreach (var humanBody in eventArgs.updated)
            {
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    boneController.ApplyBodyPose(humanBody);
                    
                    Debug.Log("------start------");
                    var index = 0;

                    foreach (var entry in eventArgs.updated)
                    {
                        index = index++;
                        
                        var jointIndex = 0;

                        Debug.Log("Pose1 "+entry.pose.position);

                        var x = entry.pose.position.x;
                        var y = entry.pose.position.y;
                        var z = entry.pose.position.z;

                        foreach (var joint in entry.joints)
                        {
                            jointIndex = jointIndex++;
                            
                            if (joint.index == 17)
                            {
                                //DO STUFF HERE
                                Destroy(sphere1);
                                drawSphere1(x + 0.1f, y + 0.3f, z);
                            }
                        }
                    }
                    Debug.Log("------end------");
                    
                }
            }

            foreach (var humanBody in eventArgs.removed)
            {
                Debug.Log($"Removing a skeleton [{humanBody.trackableId}].");
                if (m_SkeletonTracker.TryGetValue(humanBody.trackableId, out boneController))
                {
                    Destroy(boneController.gameObject);
                    m_SkeletonTracker.Remove(humanBody.trackableId);
                }
            }
        }
    }

    using UnityEngine;
    using UnityEngine.XR.ARFoundation;

    public class ARImageTracking : MonoBehaviour
    {
        [SerializeField]
        private GameObject arMarkerObject; // Assign your virtual collision object prefab here

        private ARTrackedImageManager arTrackedImageManager;

        private void Awake()
        {
            arTrackedImageManager = GetComponent<ARTrackedImageManager>();
        }

        private void OnEnable()
        {
            arTrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
        }

        private void OnDisable()
        {
            arTrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
        }

        private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
        {
            // Iterate over new images
            foreach (var newImage in eventArgs.added)
            {
                // Create a virtual object at the AR marker's position
                Instantiate(arMarkerObject, newImage.transform.position, newImage.transform.rotation);
            }
        }
    }

}