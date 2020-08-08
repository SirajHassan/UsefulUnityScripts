using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTools : MonoBehaviour
{
    public Vector3 littleHammerSpawn;
    public Vector3 nailSpawn;
    public Vector3 sawSpawn;
    public Vector3 bigHammerSpawn;
    public GameObject littleHammer;
    public GameObject bigHammer;
    public GameObject saw;
    public GameObject nail;



    // Start is called before the first frame update
    void Start()
    {
        littleHammerSpawn = GameObject.Find("spawn1").transform.position;
        nailSpawn = GameObject.Find("spawn2").transform.position;
        sawSpawn = GameObject.Find("spawn3").transform.position;
        bigHammerSpawn = GameObject.Find("spawn4").transform.position;

        //littleHammer = GameObject.Find("Hammer_01");
        //bigHammer = GameObject.Find("Hammer_02");
        //nail = GameObject.Find("Nail");
        //nail = GameObject.Find("Saw");

    }

    // Update is called once per frame
    void Update()
    {
        littleHammerSpawn = GameObject.Find("spawn1").transform.position;
        nailSpawn = GameObject.Find("spawn2").transform.position;
        sawSpawn = GameObject.Find("spawn3").transform.position;
        bigHammerSpawn = GameObject.Find("spawn4").transform.position;

    }

	private void OnTriggerEnter(Collider other)
	{
        if (other.gameObject.tag == "tool")
        {

            Debug.Log("ENTER:");
            //Transform t = other.gameObject.GetComponent<Transform>();

            if (other.gameObject.GetComponent<RightHandGrab>().rightHandGrabbing == true) // collision w/ object and right hand
            {
                other.gameObject.GetComponent<BeltSpawner>().spawnAtBelt = false;
            }
            else
            {
                other.gameObject.GetComponent<BeltSpawner>().spawnAtBelt = true;
            }
            

   

        }


	}

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "tool")
        {
            Debug.Log("EXIT:");
            other.gameObject.GetComponent<BeltSpawner>().spawnAtBelt = false;
        }



    }
}
