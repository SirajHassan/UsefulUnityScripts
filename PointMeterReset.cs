using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMeterReset : MonoBehaviour
{
    public GameObject PointMeter;
    public AudioSource Sound;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if point meter is colliding with the point Goal.. 
    }

    public void OnTriggerEnter(Collider other)
    { 

        if (other.name == "PointMeter") //collisions cannot happen within one second of eachother...
        {
            PointMeter = GameObject.Find("PointMeter");
            Sound = GetComponent<AudioSource>();
            Sound.Play();
            Vector3 pmCurrentPos = PointMeter.transform.position;
            pmCurrentPos.y = 0.1f;
            PointMeter.transform.position = pmCurrentPos;

        }
    }
}

