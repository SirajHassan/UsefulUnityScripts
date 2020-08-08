using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandGrab : MonoBehaviour
{
    public bool rightHandGrabbing;
    // Start is called before the first frame update
    void Start()
    {
        rightHandGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        bool handTrigger = OVRInput.Get(OVRInput.RawButton.RHandTrigger);
        if (other.gameObject.name == "RightHandAnchor" && handTrigger == true )
        {
            rightHandGrabbing = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RightHandAnchor")
        {
            rightHandGrabbing = false;
        }



    }
}
