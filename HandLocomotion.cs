using UnityEngine;

public class HandLocomotion : MonoBehaviour
{
    // determines which controller should be used for locomotion
    public enum Controller { Left, Right };
    public Controller controller = Controller.Right;

    // the maximum movement speed in meters per second
    public float maxSpeed = 1.0f;

    public bool viewLocomotion;

    // the deadzone is the area close to the center of the thumbstick
    public float moveDeadzone = 0.2f;
    public bool triggerPushed;
    public bool triggerPressed;

    public GameObject rightHand;

    OVRCameraRig cameraRig = null;


    public float transitionTime = 0.1f;
    public float transitionDistance = 2.0f;

    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    float transitionProgress = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        // this script is meant to be used on the OVRCameraRig game object
        cameraRig = GetComponent<OVRCameraRig>();
        viewLocomotion = false;
        rightHand = GameObject.Find("RightHandAnchor");
        



    }

    // Update is called once per frame
    void Update()
    {
        Teleporter tele = rightHand.GetComponent<Teleporter>();
        Vector3 hitPoint = tele.hitPosition; //this is the position the line renderer is hitting


        // stores the x and y values of the thumbstick
        Vector2 thumbstickVector = new Vector2();

        // read the thumbstick values from either the right or left controller
        if (controller == Controller.Right)
            thumbstickVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch);
        else
            thumbstickVector = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);


        // returns true if the primary thumbstick has been moved upwards more than halfway.

        bool left = OVRInput.Get(OVRInput.Button.PrimaryThumbstickLeft);
        bool right = OVRInput.Get(OVRInput.Button.PrimaryThumbstickRight);

        bool down = OVRInput.GetUp(OVRInput.Button.SecondaryThumbstick);




        // returns true after a press of button A
        bool aPressed = OVRInput.GetUp(OVRInput.Button.One);


        //switch locomotion modes between hand and view
        if (aPressed == true)
        {
            if (viewLocomotion == false)
            {
                viewLocomotion = true;
            }
            else
            {
                viewLocomotion = false;
            }
        }

        
         
        if (left == true && triggerPushed == false)
        {
            transform.rotation *= Quaternion.AngleAxis(-45, Vector3.up);
            triggerPushed = true;
        }
        if (right == true && triggerPushed == false)
        {
            transform.rotation *= Quaternion.AngleAxis(45, Vector3.up);
            triggerPushed = true;
        }

        if (right == false && left == false)
        {
            triggerPushed = false;
        }

        //transition method
        if (down == true)
        {
            triggerPressed = true;
            startPosition = transform.position;
            endPosition = hitPoint;
            transitionProgress = 0;
        }
        if (transitionProgress < 1)
        {
            transitionProgress += Time.deltaTime / transitionTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
        }

        if ( down == false)
        {
            triggerPressed = false;
        }








        Vector3 nextPosition = transform.localPosition;

        // if the thumbstick has been pushed outside the dead zone
        if (thumbstickVector.y > moveDeadzone || thumbstickVector.y < -moveDeadzone)
        {
            // COMPLETE THIS SECTION OF CODE


            // step 1 - create a Vector3 that contains the values for movement            
            // this calculation will require maxSpeeed, thumstickVector.y, and Time.deltaTime

            //Vector3 currentPosition = transform.position;

            nextPosition = new Vector3(0, 0, Time.deltaTime * maxSpeed * thumbstickVector.y);

            // step 2 - multiply by movement vector by the head orientation
            // this can be retrieved using cameraRig.centerEyeAnchor.rotation
            if (viewLocomotion == false)
            {
                nextPosition = cameraRig.rightHandAnchor.rotation * nextPosition;
            }
            else
            {
                nextPosition = cameraRig.centerEyeAnchor.rotation * nextPosition;
            }

            // step 3 - add this movement vector to the current position of the game object
            // this can be found using transform.localPosition

            transform.localPosition = nextPosition + transform.localPosition;

        }
    }
}
