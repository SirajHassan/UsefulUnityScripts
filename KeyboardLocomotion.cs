using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardLocomotion : MonoBehaviour
{
    // Start is called before the first frame update
    //Started gets called once at the beggining of the scene

    public float moveSpeed = 3.0f;




    void Start()
    {
        
    }

    // Update is called once per frame
    // We will check to see if a keyboard key is pressed then move foward.
    void Update()
    {
        // get cameras current position

        Vector3 currentPosition = transform.position;  //data type for xyz current position


        //update position
        if (Input.GetKey("w"))

            currentPosition += transform.rotation * new Vector3(0,0,Time.deltaTime * moveSpeed); //moves meter every time you call update loop
            // time.deltaTime * moveSpeed means any system will run at the same speed. 

        // function for quternion
        //Quaternion.Euler(0, 90, 0); // does yaw pitch and roll.

          

        //assign new position to the camera 
        transform.position = currentPosition;

    }
}
