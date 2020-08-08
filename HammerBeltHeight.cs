using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerBeltHeight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onbelt;
    public Transform p;
    public Vector3 start;
    public Quaternion startrot;
    public GameObject spawn;
    void Start()
    {
        onbelt = true;
        Debug.Log("HERE");
        spawn = GameObject.Find("spawn2");
        startrot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log("HERE1");
        p = this.transform.parent;
        if (p.name == null || p.name == "Belt" )
        {
            Debug.Log("ONBELT");
            Vector3 newpos = spawn.transform.position;
            this.transform.position = newpos;
            this.transform.rotation = startrot;
            onbelt = true;
        }
        else
        {
            Debug.Log("NOT ON BELT");
            onbelt = false;
            this.GetComponent<Rigidbody>().useGravity = true;

        }
    }
}
