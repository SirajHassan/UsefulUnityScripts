using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBeltAppear : MonoBehaviour
{
    public bool wakandaMotion;
    public bool toolBeltOn;
    public Collider rightHandExtCollider;
    public Collider leftHandCollider;
    public Collider rightSideCollider;
    public Collider leftSideCollider;
    public GameObject rightSideColliderObj;
    public GameObject leftSideColliderObj;
    public Collider rightHand;
    public Collider leftHand;
    public bool sideCollision;
    public bool handExtCollision;
    public bool rightCollision;
    public bool leftCollision;
    public GameObject toolBeltObj;
    public Renderer rend;
    public GameObject hammer_02;
    public GameObject plank;
    public GameObject nail;

    public GameObject spawn1;
    public GameObject spawn2;
    public GameObject spawn3;
    public GameObject spawn4;

    public GameObject hammer_02_og;
    public GameObject nail_og;
    public GameObject plank_og;
    public GameObject crowbar_og;



    // Start is called before the first frame update
    void Start()
    {
        //rightHandExtCollider = GameObject.Find("RightHandCollider").GetComponent < Collider>();
        //leftHandCollider = GameObject.Find("LeftHandCollider").GetComponent < Collider>();
        //rightSideCollider = GameObject.Find("RightCollider").GetComponent<Collider>();
        //leftSideCollider = GameObject.Find("LeftCollider").GetComponent<Collider>();
        //rightHand = GameObject.Find("RightHandAnchor").GetComponent < Collider>();
        //leftHand = GameObject.Find("LeftHandAnchor").GetComponent < Collider>();

        //Debug.Log("Start1");
        rightSideColliderObj = GameObject.Find("RightCollider");
        leftSideColliderObj = GameObject.Find("LeftCollider");

        spawn1 = GameObject.Find("spawn1");
        spawn2 = GameObject.Find("spawn2");
        spawn3 = GameObject.Find("spawn3");
        spawn4 = GameObject.Find("spawn4");

        toolBeltObj = GameObject.Find("Belt");

        hammer_02_og = GameObject.Find("Hammer_02_OG");
        nail_og = GameObject.Find("Nail_OG");
        plank_og = GameObject.Find("Plank_OG");

        wakandaMotion = false;
        toolBeltOn = false; //default start with no toolbelt
        rend = toolBeltObj.GetComponent<Renderer>();
        rend.enabled = false;
        //Debug.Log("Start2");

    }

    // Update is called once per frame
    void Update()
    {
        hammer_02 = GameObject.Find("Hammer_02");
        //plank = GameObject.Find("Plank");
        //nail = GameObject.Find("nail");



        rightCollision = rightSideColliderObj.gameObject.GetComponent<RightCollider>().rightSideCollision;
        
        leftCollision = leftSideColliderObj.gameObject.GetComponent<LeftCollider>().leftSideCollision;
        
        rend = toolBeltObj.GetComponent<Renderer>();
        

        //bool leftIndexTrigger = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);
        //bool leftHandTrigger = OVRInput.Get(OVRInput.RawButton.LHandTrigger);
        //bool rightIndexTrigger = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);
        //bool rightHandTrigger = OVRInput.Get(OVRInput.RawButton.RHandTrigger);
        //bool primaryThumbstick = OVRInput.Get(OVRInput.Button.PrimaryThumbstick);
        //bool secondaryThumbstick = OVRInput.Get(OVRInput.Button.SecondaryThumbstick);


        //get all inputs from OVR..
        //bool triggers_pulled = leftHandTrigger && leftIndexTrigger && rightHandTrigger && rightIndexTrigger;


        if (rightCollision && leftCollision && wakandaMotion == false && rend.enabled == true )
        {
            
                
            rend.enabled = false;
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                // Do something with the renderer here...
                r.enabled = false; // like disable it for example. 
            }

            wakandaMotion = true;

        }
        else if (rightCollision && leftCollision && wakandaMotion == false && rend.enabled == false)
        {
            
            rend.enabled = true;
            Renderer[] renderers = GetComponentsInChildren<Renderer>();
            foreach (var r in renderers)
            {
                // Do something with the renderer here...
                r.enabled = true; // like disable it for example. 
            }

            wakandaMotion = true;



            //hammer_02 has probably has grabber parent
            Debug.Log("AtTheStop");
            if (hammer_02 != null)
            {
                Debug.Log("Parent^");
                if (hammer_02.transform.parent != null)
                {
                    Destroy(hammer_02);
                }
            }

            Transform tform = toolBeltObj.transform; // maybe put in start
                
            Vector3 position = spawn2.transform.position;
            //Vector3 position = new Vector3(-61.126f, 0.424f,45.438f);
            Quaternion rotation = Quaternion.Euler(-90, 90, 0);
            hammer_02 = Instantiate(hammer_02_og, position, rotation, tform);
            hammer_02.name = "Hammer_02"; //set different name
            hammer_02.tag = "hammer"; //set different tag
            hammer_02.transform.localScale = new Vector3(10f, 10f, 10f);
            hammer_02.transform.GetComponent<Rigidbody>().isKinematic = false;
            hammer_02.transform.GetComponent<Rigidbody>().useGravity = false;


            if (nail != null && nail.GetComponent<NailBeltHeight>().onbelt == false)
            {
                Vector3 nail_position = spawn3.transform.position;
                Quaternion nail_rotation = Quaternion.Euler(0, 0, 0);
                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";
            }
            else if (nail == null)
            {
                Vector3 nail_position = spawn3.transform.position;
                Quaternion nail_rotation = Quaternion.Euler(0, 0, 0);
                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 20f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";

                nail = Instantiate(nail_og, nail_position, nail_rotation, tform);
                nail.transform.localScale = new Vector3(20f, 25f, 20f);
                nail.transform.GetComponent<Rigidbody>().useGravity = false;
                nail.transform.GetComponent<Rigidbody>().isKinematic = false;
                nail.tag = "nail";
            }

            if (plank != null && plank.GetComponent<PlankBeltHeight>().onbelt == false)
            {
                Vector3 plank_position = spawn4.transform.position;
                Quaternion plank_rotation = Quaternion.Euler(0, 0, 90);
                plank = Instantiate(plank_og, plank_position, plank_rotation, tform);
                plank.transform.localScale = new Vector3(10f, .3f, 2f);
                plank.tag = "plank";
                plank.transform.GetComponent<Rigidbody>().useGravity = true;
                plank.transform.GetComponent<Rigidbody>().isKinematic = false;

                plank = Instantiate(plank_og, plank_position, plank_rotation, tform);
                plank.transform.localScale = new Vector3(10f, .3f, 2f);
                plank.tag = "plank";
                plank.transform.GetComponent<Rigidbody>().useGravity = true;
                plank.transform.GetComponent<Rigidbody>().isKinematic = false;

                



            }
            else if (plank == null) {
                Vector3 plank_position = spawn4.transform.position;
                Quaternion plank_rotation = Quaternion.Euler(0, 0, 90);
                plank = Instantiate(plank_og, plank_position, plank_rotation, tform);
                plank.transform.localScale = new Vector3(10f, .3f, 2f);
                plank.tag = "plank";
                plank.transform.GetComponent<Rigidbody>().useGravity = true;
                plank.transform.GetComponent<Rigidbody>().isKinematic = false;

                plank = Instantiate(plank_og, plank_position, plank_rotation, tform);
                plank.transform.localScale = new Vector3(10f, .3f, 2f);
                plank.tag = "plank";
                plank.transform.GetComponent<Rigidbody>().useGravity = true;
                plank.transform.GetComponent<Rigidbody>().isKinematic = false;

                


            }










        }
        else if (rightCollision == false && leftCollision == false)
        {
            
            wakandaMotion = false;
            //Debug.Log("WakandaMotionFalse");


           
            


        }
    }

    
}
