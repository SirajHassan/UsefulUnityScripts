using UnityEngine;

public class Selector : MonoBehaviour
{


    public Color lineColor = Color.yellow;
    public Color lineColorSelect = Color.green;
    public float lineWidth = 0.01f;
    private LineRenderer lineRenderer;
    public new Selectable[] selected;
    public new Selectable[] lastSelected;
    public bool isReleased;
    
    public GameObject rHand;
    public GameObject lHand;
    public float lastDistance = 0.0f;





    // Start is called before the first frame update
    void Start()
    {
        // create a line renderer and add it to the current game object
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.positionCount = 2;
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        lineRenderer.widthMultiplier = lineWidth;
        lineRenderer.enabled = false; //edit 1, make false
        selected = new Selectable[1];
        lastSelected = new Selectable[1];
        isReleased = true; //tracks whether the trigger has been released after push
        

        rHand = GameObject.Find("RightHandAnchor");
        lHand = GameObject.Find("LeftHandAnchor");

    }

    // Update is called once per frame
    void Update()
    {
        // set the selectable object to null initially
        Selectable selectable = null;
      
        Selectable sky = null;

        // get the current position
        Vector3 currentPosition = transform.position;

        // perform a physics raycast in the forward direction
        // if we hit an object, get the selectable component
        RaycastHit hitInfo;
        if (Physics.Raycast(currentPosition, transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
        {
            selectable = hitInfo.transform.GetComponent<Selectable>();
            name = hitInfo.transform.name;
        }

        // if the raycast hit a selectable object, draw a line to the collision point
        // otherwise, make the line invisible
        if (selectable != null || selectable == null)
        {


            // check if pointing at sky
            if (name == "WorldContainer")
            {
                lineRenderer.enabled = false;
            }

            if (selectable != null)
            {
                lineRenderer.startColor = lineColorSelect;
                lineRenderer.endColor = lineColorSelect;

                //check if trigger is being pushed..
                bool triggerLeft = OVRInput.Get(OVRInput.RawButton.LIndexTrigger);
                bool triggerRight = OVRInput.Get(OVRInput.RawButton.RIndexTrigger);

                //change size of selected object as distance between hands changes
                if (selected[0] != null && triggerLeft == true)
                {
                    Vector3 rPos = rHand.transform.position;
                    Vector3 lPos = lHand.transform.position;
                    Vector3 heading = rPos - lPos;
                    var distance = heading.magnitude;
                    var sign = 0;

                    if (distance <= lastDistance)
                    {
                        sign = -1;
                    }
                    else { sign = 1; }

                    //scale object by some magnitude
                    float x = 0.1f;
                    float y = 0.1f;
                    float z = 0.1f;

                    selected[0].transform.localScale += (sign * distance) * new Vector3(x, y, z);

                    lastDistance = distance;
                      
                }



                if (triggerRight == false)
                {
                    isReleased = true;
                }

                
                if (triggerRight == true && isReleased == true)
                {
                    isReleased = false;
                    if (selected[0] != null) //something has been selected before
                    {
                        Debug.Log("1");
                        selected[0].GetComponent<Selectable>().Deselect();



                        if ((selected[0] != null) && string.Equals(selected[0].name, selectable.name)) //selecting same object as before
                        {
                            Debug.Log("2");
                            //selected[0].GetComponent<Selectable>().Deselect();
                            selected[0] = null;
                        }

                        else // looking at a new object
                        {
                            Debug.Log("3");
                            selected[0] = selectable; // set new selected object
                            selectable.GetComponent<Selectable>().Select(); //run Select() function in selectable

                        }



                    }

                    else // nothing has been selected yet
                    {
                        selectable.GetComponent<Selectable>().Select();
                        selected[0] = selectable;
                    }




                }

            }
            else
            {
                lineRenderer.startColor = lineColor;
                lineRenderer.endColor = lineColor;

            }

            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, currentPosition);
            lineRenderer.SetPosition(1, hitInfo.point);
        }
        else
        {
            //lineRenderer.enabled = false; //edit1
        }
    }
}



//make a child object and make its Z direction out the front of the cylinder then add the selector script.
//make box collider on outside world. // how to have objects inside it the sphere but not screw everything up?