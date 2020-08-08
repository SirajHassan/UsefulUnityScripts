using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToPlank : MonoBehaviour
{
    public GameObject plank;
    public bool linked;
    public GameObject child;
    public Material yellowMaterial;

    // Start is called before the first frame update
    void Start()
    {
        //hammer_hit = false;
        //plank_touching = false;
        linked = false;
        child = this.gameObject.transform.GetChild(0).gameObject;

        

    }

    // Update is called once per frame
    void Update()
    {
        bool hammer_hit = GetComponentInChildren<Hammer_Collision2>().hammer_hit;
        bool plank_hit = GetComponentInChildren<PlankCollision>().touching2planks;
        //Material mat = GetComponentInChildren<Renderer>();

       
        // //if linked already..Remove the fixed joint and make both objects static..
        //if (linked == true && hammer_hit)
        //{
        //    Color yellowColor = new Color(124f, 252f, 0, 1);
        //    Debug.Log("change color");
        //    plank.GetComponent<Rigidbody>().isKinematic = true;
        //    Destroy(plank.GetComponent<FixedJoint>());
        //    this.GetComponent<Rigidbody>().isKinematic = true;
        //    this.GetComponentInChildren<Rigidbody>().isKinematic = true;

        //}




        plank = GetComponentInChildren<PlankCollision>().plank;
        

        if (hammer_hit && plank_hit)
        {
            //change color of nail to yellow;
            Color yellowColor = new Color(255f, 255f, 0, 1);
            Debug.Log("change color");
            GetComponentInChildren<Renderer>().material.color = yellowColor;

            //plank.AddComponent<FixedJoint>();
            //plank.GetComponent<FixedJoint>().connectedBody = this.GetComponent<Rigidbody>();
            ///
            plank.GetComponent<Rigidbody>().isKinematic = true;
            this.GetComponent<Rigidbody>().isKinematic = true;

            ///
            Destroy(plank.GetComponent<OVRGrabbable>());
            Destroy(this.GetComponent<OVRGrabbable>());
            linked = true;

            //change color of nail to yellow;
            
            


        }
        
    }
}
