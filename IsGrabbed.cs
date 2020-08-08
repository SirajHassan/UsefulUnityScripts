using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrabbed : MonoBehaviour
{
    public bool isGrabbed;
    public bool hasBeenGrabbed;
    public bool rightGrabber;
    public bool rightHandTrigger;
    // Start is called before the first frame update
    void Start()
    {
        isGrabbed = false;
        hasBeenGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("UPDATECHECK");
        bool rightHandTrigger = OVRInput.Get(OVRInput.RawButton.RHandTrigger);
        Debug.Log(this.tag);

        if (rightGrabber == true)
        {
            Debug.Log("GRABCHECK");
            hasBeenGrabbed = true;
            this.transform.parent = null;
            this.GetComponent<Rigidbody>().useGravity = true;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLLIDECHECK");
        if (other.gameObject.name == "RightHandAnchor" && rightHandTrigger )
        {
            rightGrabber = true;
        }
        
    }
}
