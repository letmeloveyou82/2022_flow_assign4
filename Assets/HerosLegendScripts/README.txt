Hero's Legend Studio
Follow me on Instragram @HerosLegendStudio

Grab And Throw ability mechanic (Lite Version)
-------------------------------
This package only contains the GrabnThrow_Lite.cs and this README.txt.

To see demo use the following setup steps. 

1. Open Unity and Create a New Unity Project. Use the 2D Template.
-----
2. Once Project is ready. Import package. 
	2a. Assets > Import Package > Custom Package > Find 'HerosLegendStudio_GrabAndThrow_Lite.unityPackage'
	2b. This package only contains the GrabAndThrow.cs script and this README.txt.
	2c. Click Import.

3. You can now examine the script.
-----
4. Next import some Standard Assets to create a demo to test the Grab And Throw script.
	4a. Assets > Import Package > 2D
	4b. If 2D package is not shown here. You will need to sign in and go to the Unity Asset Store and find the 'Standard Assets'
		package there. It is by UNITY TECHNOLOGIES. 
	4c. Click Import if through Unity Editor
	4d. Click Add to Assets if through Asset Store. 
		Then click Open in Unity. The Asset Store will open through the Editor. 
		Search again for Standard Assets and Click Download. It will be FREE.
		Click Import.
		Ensure the below asset folders are checked as they are needed for this demo. 
		Standard Assets > 2D 
		Standard Assets > CrossPlatformInput
-----
5. Create a demo test environment with the below steps.
-----
6. Prepare the Main Character and Camera
	6a. In the Projects Window. Go to Assets > Standard Assets > 2D > Prefabs 
	6b. Drag the CharacterRobotBoy to the Scene Window or Hierarchy Window to add to your Scene
		6b1. 0 the gameObjects Position for X, Y and Z.
	6c. Next Drag the Platform36x01 to the Scene Window or Hierarchy Window
		6c1. Place this platform below the CharacterRobotBoy gameObject
	6d. In the Hierarchy Window click on the Main Camera
	6e. In the Inspector Window click Add Component
		6e1. Search for 'Camera 2D Follow'
		6e2. Scripts > UnityStandardAssets._2D > 'Camera 2D Follow'
		OR
		6e1. In the Project window. Assets > Standard Assets > 2D > Scripts
		6e2. Drag and Drop Camera2DFollow to your Main Camera Inspector window. 
	6f. Drag the CharacterRobotBoy from the Hierarchy window to the Target (Transform) of the Camera 2D Follow script
	6g. Change all variables of script to 5, except Damping this should be set to 0. This is for demo purposes. 
		Camera Size should be 8 to get more of the platform in the camera view. 
	6h. Remove Circle Collider 2D from CharacterRobotBoy and extend Box Collider 2D to Y 1.25 to cover whole body. 
			The GrabAndThrow script wants to ignore the collider attached to theMC so it does not interfere with the collision
			of the throw object. 
	6i. Add Empty gameObject and place it in the CharacterRobotBoy Hierarchy
		6h1. 0 the Positions and rename to 'theHand'
		6h2. Click Add Component > Rendering > Sprite Renderer
		6h3. Add ButtonArrowOverSprite to Sprite variable of Sprite Renderer component.
		6h4. The Scale should be 1 for X Y and Z
		6h5. Draw Mode for Spriter Renderer I set to Sliced and reduced width and height to 1 to have a smaller sprite image. 
		6h6. Circle Collider 2D set Radius to 0.5 this will prevent the object from hitting the ground and slowing theHand down. 
-----
7. Setup Enemy object
	7a. GameObject > 2D Object > Sprite. Rename 'New Sprite' to 'Enemy'
	7b. In the Inspector of the 'Enemy' in the Sprite Renderer Select the 'BackgroundNavyGridSprite' for the sprite variable
	7c. Click Add Component > Physics 2D > Box Collider 2D
	7d. Click Add Component > Physics 2D > Rigidbody 2D
	7e. Add a new 'enemy' Tag, click Tag dropdown > Add Tag...
		7e1. Click + > name new tag 'enemy' > click Save
		7e2. Set Tag to 'enemy'
	7f. Change Scale of X and Y to 0.5
	7g. Move to be above Platform
-----
8. Setup script
	8a. Click on 'theHand' in the Hierarchy Window
	8b. Click Add Component > Physics2D > Circle Collider 2D (**any collider can be used, I chose Circle Collider)
	8b. Click Add Component > Scripts > GrabAndThrow_Lite
		8b1. Start Pos should be the gameObject which the grab should start from and return to. In this case CharacterRobotBoy.
		8b2. The Hand should be theHand gameObject
		8b3. The MC (MainCharacter) should be the CharacterRobotBoy 
		8b4. Set Grab Tag to enemy as it should match your Enemy gameObject tag.
		8b5. Set all other variables to desired setting. The script has default settings which can be kept.
-----
9. Congratulations!!! Setup is all complete go and play your new demo. 
	9a. WASD or Arrow Keys for character movement
	9b. Left Mouse click to shoot grab. 
	
	
	