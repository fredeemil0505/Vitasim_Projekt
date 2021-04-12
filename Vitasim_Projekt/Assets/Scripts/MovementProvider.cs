using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class MovementProvider : LocomotionProvider
{
    //Variables
    public float speed = 1.0f;
    public float gravityMultiplier = 1.0f;
    public List<XRController> controllers = null;

    //Variables that holds the player controller and head camera
    private CharacterController characterController = null;
    private GameObject head = null;

    protected override void Awake()
    {
        //Gets controller and camera component
        characterController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;
    }

    // Start is called before the first frame update
    void Start()
    {
        //makes sure that head-camera is raised to correct position.
        //guide video uses the term capsule, which could also refer to a specific object rather than camera object.
        PositionController();
    }

    // Update is called once per frame
    void Update()
    {
        PositionController();
        CheckForInput();
        ApplyGravity();
    }

    private void PositionController()
    {
        // Get the Head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        characterController.height = headHeight;

        //this can be redudant, but added to make sure it works
        Vector3 newCenter = Vector3.zero;
        newCenter.y = characterController.height / 2;
        newCenter.y += characterController.skinWidth;

        // Moving the character in local space
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;

        //the apply of new position
        characterController.center = newCenter;
    }

    private void CheckForInput()
    {
        //checks the list of controllers if a controllers is active with input
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        //checks if the device has joystick feature, for 2D movement (ground movement)
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            StartMove(position);
        }
    }

    private void StartMove(Vector2 position)
    {
        // Apply the touch position to the Head's forward vector
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(0, head.transform.eulerAngles.y, 0);

        //Rotate the input direction by the horizontal head rotation
        //The direction of movement is based of the direction the player is looking, this is calculated with MATH!!! no idea what Quaternion or what Euler has to do with this.
        direction = Quaternion.Euler(headRotation) * direction;

        //Apply speed and move
        Vector3 movement = direction * speed;
        characterController.Move(movement * Time.deltaTime);
    }

    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;

        characterController.Move(gravity * Time.deltaTime);
    }
}
