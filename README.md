Documentation of mobile Visual Computing Project
Team members: Yannick Borschneck / Jonas Deichelmann

# How to use it
The project was built for iOS devices which support ARKit. Once the app is built follow these menu items to access the application:

1. Body Tracking
2. Body Tracking 3D
3. Point at humanoid shape from the front
4. Some colored balls should appear on the humanoid figurine

# Description of Project
This project's purpose was to develop a small Augmented Reality (AR) app, designed to demonstrate the correct application of Electrocardiograms (ECGs) on a human body. The app was intended for medical professionals and students to enhance their understanding and to provide a visual and interactive guide for ECG application. The AR app was developed using Unity and equipped with the capability to scan a human torso, providing an interactive demonstration of how to apply an ECG. This project is considered as a standalone module that could be integrated into a larger project, such as a comprehensive learning app for medical professionals.

ECGs play a crucial role in medical diagnostics, specifically in the detection and monitoring of heart conditions. Despite the importance of ECGs, their correct placement can be challenging, especially for new students and even some experienced professionals. Misplacement of ECG leads may result in inaccurate readings, which could potentially lead to misdiagnosis and inappropriate treatment. Therefore, the need for an intuitive and effective learning tool to train professionals and students on proper ECG placement is paramount.



# Goal
The goal of this project was to create a tool that simplifies the learning process for medical professionals and students in understanding and applying ECGs. The application aims to reduce errors in real-world scenarios, promoting more accurate ECG readings and ultimately better patient outcomes. By utilizing AR technology, we hoped to create a more immersive and engaging educational experience.

# Body-Tracking with Unity
There are two ways of implementing body tracking features within Unity: ARFoundation and Mars. The latter is the current top notch framework with a subscription based model in active development by unity while the former is free to use.
ARFoundation requires two components to work: A rigged model and a manager script containing a ARHumanBodyManager object. If a humanoid shape is then detected a skeleton is generated and the rigged model applied. No artificial markers need to be used. The skeleton can deal with partial occlusion of the body but the skeleton might glitch out.
AR-Marker Tracking

Each ECG lead is equipped with a unique marker, and the app is designed to recognize these markers and verify their positioning. We leveraged Unity's AR Foundation and ARKit to develop this marker tracking system.
When a user places an ECG lead onto the torso, the app scans the AR marker and cross-references its position with the ideal placement for that particular lead. If the lead is not correctly placed, the app provides interactive feedback to guide the user to the correct position. This Feature was Implemented by Jonas Deichelmann, who tried several ways to achieve this goal.


# Problems Encountered
Throughout the development of the AR ECG application, our team encountered a range of challenges that tested our problem-solving skills, adaptability, and teamwork.

## Git-Merging and Authorization Conflicts 
One significant issue we faced involved git-merging and authorization conflicts. With multiple team members working on different aspects of the project and making changes to the codebase, merging the changes often led to conflicts. Resolving these required a detailed understanding of the code and careful management of the version control system.

## Understanding the Demo Projects 
The tutorials provided demo projects to guide us in the development process. However, we encountered difficulties in comprehending the implementation details within these demos. The complexity of the code and the techniques used posed a steep learning curve for the team.
Additionally the documentation was sparse or nonexistent. Guidance was only provided through the demo project. Unity deployed a new product called MARS which seems to take up much of their resources in regards to documentation and work.
Therefor alot of guesswork had to be done which is reflected in the quality of the code. Artifacts of the “trying out” process have been left inside the code on purpose to underline this point.

## Problems with AR Detection
Given that Unity was very much of a blackbox until the project end there were a few problems:

1. In order to tell the user where to place the ECG probes spheres have been placed ontop of a robot model. The model itself was not modified due to a lack of knowledge and documentation to modify the model files.
2. The coordination system at the base of the model on runtime is twisted. That made actually placing the balls extremely difficult. The reason for this could not be found.
3. The detection is sometimes off. Therefor the product should only used as guidance and practise tool.

## Integration of AR-Marker Detection 
Integrating the AR-marker detection within the app posed its own set of challenges. The task of creating a system that could accurately recognize and track the unique AR markers on the ECG leads was technically demanding, requiring a deep understanding of the AR technologies we were working with.

## AR-Marker Collision Detection 
Detecting the collision of the AR-markers with the spheres on the body-tracked torso proved to be another significant challenge. Building a reliable system to accurately identify these interactions required careful calibration and numerous iterations to ensure precision.

## Time Overlaps and Responsibilities
Finally, the team faced the challenge of time management. With each team member juggling various important responsibilities outside the project, coordinating schedules to allow for collaborative work sessions was an ongoing issue. 

Despite these conflicts, we strived to maintain consistent communication and ensure that each member's contributions were integrated smoothly into the project.
Despite these challenges, we were able to learn from these problems and develop solutions to keep the project moving forward.

# Conclusion
With today's technology, such an idea is not only possible but also presents an intriguing use case for combining AR technology with medical education.

However, this project was not without its challenges, and these led to a product that, in its current state, serves more as a proof of concept rather than a fully-functional tool for medical professionals. Technical issues such as Git conflicts, understanding demo projects, integrating AR-marker detection, and managing time effectively presented significant obstacles.

Despite these challenges, the proof of concept we've developed demonstrates the potential of AR in medical education.
