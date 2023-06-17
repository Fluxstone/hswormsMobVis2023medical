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
        
        public GameObject sphere2;
        public bool sp2Spawned = false;

        public GameObject sphere3;
        public bool sp3Spawned = false;
        
        public GameObject sphere4;
        public bool sp4Spawned = false;
        
        public GameObject sphere5;
        public bool sp5Spawned = false;
        
        public GameObject sphere6;
        public bool sp6Spawned = false;
        
        public GameObject sphere7;
        public bool sp7Spawned = false;
        
        //red
        private void drawSphere1(float x,float y,float z)
        {
            sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere1.transform.position = new Vector3(x, y, z);
            sphere1.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere1.GetComponent<Renderer>().material.color = Color.red;
            
            sp1Spawned = true;
        }
        //blue
        private void drawSphere2(float x,float y,float z)
        {
            sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere2.transform.position = new Vector3(x, y, z);
            sphere2.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere2.GetComponent<Renderer>().material.color = Color.blue;
            
            sp2Spawned = true;
        }
        //green
        private void drawSphere3(float x,float y,float z)
        {
            sphere3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere3.transform.position = new Vector3(x, y, z);
            sphere3.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere3.GetComponent<Renderer>().material.color = Color.green;
            
            sp3Spawned = true;
        }
        //magenta
        private void drawSphere4(float x,float y,float z)
        {
            sphere4 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere4.transform.position = new Vector3(x, y, z);
            sphere4.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere4.GetComponent<Renderer>().material.color = Color.magenta;
            
            sp4Spawned = true;
        }
        //white
        private void drawSphere5(float x,float y,float z)
        {
            sphere5 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere5.transform.position = new Vector3(x, y, z);
            sphere5.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere5.GetComponent<Renderer>().material.color = Color.white;
            
            sp5Spawned = true;
        }
        //yellow
        private void drawSphere6(float x,float y,float z)
        {
            sphere6 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere6.transform.position = new Vector3(x, y, z);
            sphere6.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere6.GetComponent<Renderer>().material.color = Color.yellow;
            
            sp6Spawned = true;
        }
        //black
        private void drawSphere7(float x,float y,float z)
        {
            sphere7 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere7.transform.position = new Vector3(x, y, z);
            sphere7.transform.localScale = new Vector3(0.05f, 0.05f, 0.05f);
            
            sphere7.GetComponent<Renderer>().material.color = Color.black;
            
            sp7Spawned = true;
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "V1")
            {
                Debug.Log("AR Marker collided with the sphere.");
                sphere1.GetComponent<Renderer>().material.color = Color.green;
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
                            
                            if (joint.index == 24)
                            {
                                //red
                                Destroy(sphere1);
                                drawSphere1(x + 0.1f, y + 0.4f, z - 0.1f);
                                //blue
                                Destroy(sphere2);
                                drawSphere2(x - 0.09f, y + 0.30f, z + 0.0f);
                                //green
                                Destroy(sphere3);
                                drawSphere3(x + 0.15f, y + 0.33f, z - 0.1f);
                                //magenta
                                Destroy(sphere4);
                                drawSphere4(x + 0.2f, y + 0.4f, z - 0.1f);
                                //Unable to display these as rotation does not work propperly
                                //white
                                //Destroy(sphere5);
                                //drawSphere5(x + 0.0f, y + 0.0f, z + 0.0f);
                                //yellow
                                //Destroy(sphere6);
                                //drawSphere6(x + 0.0f, y + 0.0f, z + 0.0f);
                                //black
                                //Destroy(sphere7);
                                //drawSphere7(x + 0.0f, y + 0.0f, z + 0.0f);
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