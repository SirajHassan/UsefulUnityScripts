using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpawner : MonoBehaviour
{
    public bool spawnAtBelt;
    public Vector3 location;
  

    // Start is called before the first frame update
    void Start()
    {
        spawnAtBelt = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnAtBelt == true && this.gameObject.GetComponent<RightHandGrab>().rightHandGrabbing == false)
        {
            if (this.gameObject.name == ("Hammer_02"))
            {
                this.transform.position = GameObject.Find("Belt").GetComponent<HoldTools>().bigHammerSpawn;
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.localRotation = Quaternion.Euler(-90, 90, 0);
            }

            if (this.gameObject.name == ("Hammer_01")){
                this.transform.position = GameObject.Find("Belt").GetComponent<HoldTools>().littleHammerSpawn;
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.localRotation = Quaternion.Euler(-90, 0, 0);
            }

            if (this.gameObject.name == ("Nail")){
                this.transform.position = GameObject.Find("Belt").GetComponent<HoldTools>().nailSpawn;
                this.GetComponent<Rigidbody>().isKinematic = true;
                this.transform.localRotation = Quaternion.Euler(0, 0, 0);
            }


        }
        else
        {
            this.GetComponent<Rigidbody>().isKinematic = false;
        }

       

    }
}
