using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltRotator : MonoBehaviour
{
    public GameObject toolBeltObj;
    public GameObject leftHand;
    public GameObject center;
    public bool rend;
    public Vector3 currentPos;
    public Vector3 lastPos;
    public Vector3 centerPos;
    public Vector3 yAxis;
    public float angleBtwn;

    

    // Start is called before the first frame update
    void Start()
    {
        toolBeltObj = GameObject.Find("Belt");
        leftHand = GameObject.Find("LeftHandAnchor");
        center = GameObject.Find("CenterEyeAnchor");
        currentPos = leftHand.transform.position; 
        lastPos = leftHand.transform.position;
        centerPos = center.transform.position;
        angleBtwn = 0f;
        



    }

    // Update is called once per frame
    void Update()
    {
        // make toolbelts position follow the center eye anchor.

        Vector3 newBeltPos = new Vector3(center.transform.position.x,center.transform.position.y - 0.5f,center.transform.position.z);
        toolBeltObj.transform.position = newBeltPos;

        // if toolbelt is rendered
        // if the pointer finger and index pushing the left trigger.
        // rotate the ring the degree of how much the hand has rotated from
        // the center eye anchor.

        currentPos = leftHand.transform.position;
        rend = toolBeltObj.GetComponent<Renderer>();

        if (rend) //tool belt exists
        {
            //if left trigger pulled and
            bool leftTrigger = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);
            bool handTrigger = OVRInput.Get(OVRInput.RawButton.LHandTrigger);
            //Debug.Log("renderTrue");

            if (leftTrigger && handTrigger) //left trigger pulled and hand trigger
            {
                //Debug.Log("triggersTrue");
                // do rotation

                currentPos.y = 0;
                centerPos.y = 0;
                lastPos.y = 0;

                yAxis = new Vector3(0f, 1f, 0f);

                Vector3 currentVec = currentPos - centerPos;
                Vector3 lastVec = lastPos - centerPos;
                //Vector3 forward = Vector3.forward;

                angleBtwn = Vector3.SignedAngle(currentVec,lastVec,yAxis);
                //angleBtwn = angleBtwn * -1;
                
                toolBeltObj.transform.Rotate(0.0f, 0.0f, angleBtwn*1.8f, Space.Self);
                
                 
            }
            else
            {
                //rotate the belt the same amound in the z direction as the center eye anchor. 
                //toolBeltObj.transform.Rotate(0.0f, 0.0f, center.transform.rotation.z, Space.Self);

            }
        }
        lastPos = currentPos;
    }
}
