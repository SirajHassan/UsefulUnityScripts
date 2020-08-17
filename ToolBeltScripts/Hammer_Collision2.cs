using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer_Collision2 : MonoBehaviour
{
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

        hammer_contact = false;
        hammer_hit = false;
        position_set = false;

    }

    // Update is called once per frame
    void Update()
    {
        hammer = GameObject.Find("Hammer_02");
        Debug.Log("Start1");
        // calcualte hand transform velocity
        velocity = ((hammer.transform.position - previous).magnitude) / Time.deltaTime;
        previous = hammer.transform.position;

        if (hammer_hit == true && position_set == false)
        {


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
        Debug.Log("Collision With Hammer");
        if (other.gameObject.tag == "hammer")
        {
            Debug.Log("Hammer2 Collision");

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

    private void OnTriggerExit(Collider other)
    {
        // run the check for planks?
    }

}


    
