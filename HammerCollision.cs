using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// to be used in the head of the nail..
public class HammerCollision : MonoBehaviour
{
    // get hammer object
    public GameObject hammer_top;
    public GameObject hammer;
    public GameObject plank1;
    public GameObject plank2;
    public GameObject nail_head;
    public GameObject right_hand;
    public bool hammer_contact; //hammer touches nail, sets in place
    public bool hammer_hit; //hammer hits with high velocity.
    public bool plank_below; //there is one plank below the nail
    public bool two_planks_below; //there are two planks below nail
    public bool position_set; //there are two planks below nail
    public Vector3 set_position;
    public Quaternion set_rotation;
    Vector3 previous;
    public float velocity;
    


    public Rigidbody hammer_rb;
    Vector3 hammer_rb_velocity;

    public Rigidbody hand_rb;
    Vector3 hand_rb_velocity;




    // Start is called before the first frame update
    void Start()
    {
        hammer_top = GameObject.Find("Hammer_01_Top");
        hammer = GameObject.Find("Hammer_01");
        right_hand = GameObject.Find("RightHandAnchor");

        nail_head = this.transform.Find("Head").gameObject;
        hammer_contact = false;
        hammer_hit = false;
        position_set = false;
        hammer_rb = hammer.GetComponent<Rigidbody>();
        hand_rb = right_hand.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // calcualte hand transform velocity
        velocity = ((hammer_top.transform.position - previous).magnitude) / Time.deltaTime;
        previous = hammer_top.transform.position;

        

        //Debug.Log("HAMMER VELOCITY3:");
        //Debug.Log(velocity);


        // check if hammer hit at velocity, check if 2 planks are there
        if (hammer_hit == true && position_set == false)
        {
            position_set = true;
            set_position = transform.position;
            set_rotation = transform.rotation;
 
        }

        if (position_set == true)
        {
           transform.position = set_position;
           transform.rotation = set_rotation;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hammer_01_Top")
        {
            //check if bottom of nail is contacting a plank..

             //if just one plank, set nail in plank(parent nail to plank)

            

            if (velocity > 2.0)
            {
                hammer_hit = true;

            }
            hammer_contact = true;
        }
        else
        {
            // do nothing
        }


    }


}
