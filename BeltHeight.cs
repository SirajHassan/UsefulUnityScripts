using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltHeight : MonoBehaviour
{
    // Start is called before the first frame update
    public bool onbelt;
    public Transform p;
    public Vector3 start;
    public Quaternion startrot;
    void Start()
    {
        onbelt = true;
        Debug.Log("HERE");
        start = this.transform.position;
        startrot = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 current_pos = this.transform.position;
        Debug.Log("HERE1");
        p = this.transform.parent;
        if (p.name == "Belt" || p.name == null )
        {
            Debug.Log("ONBELT");
            Vector3 newpos = new Vector3(current_pos.x, start.y, current_pos.z) ;
            this.transform.position = newpos;
            this.transform.rotation = startrot;
            onbelt = true;
        }
        else
        {
            Debug.Log("NOT ON BELT");
            onbelt = false;
            
        }
    }
}
