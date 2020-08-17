using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankCollision : MonoBehaviour
{
    public bool touching2planks;
    public GameObject plank;
    // Start is called before the first frame update
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("BodyUpdate");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding");

        if (other.gameObject.tag == "plank")
        {
            Debug.Log("PlankColliding");
            // check if hit from hammer is true from nail head..
            touching2planks = true;
            plank = other.gameObject;


        }
        

    }
}
