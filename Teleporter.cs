using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Color lineColor = Color.yellow;
    public float lineWidth = 0.01f;
    private LineRenderer lineRenderer;
    public  Vector3 hitPosition;
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
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
    

        // get the current position
        Vector3 currentPosition = transform.position;

        //check whether the button is pushed
        bool thumbstickPressed = OVRInput.Get(OVRInput.Button.PrimaryThumbstick);

        //make line renderer and get hit info point
        RaycastHit hitInfo;
        if (Physics.Raycast(currentPosition, transform.TransformDirection(Vector3.forward), out hitInfo, Mathf.Infinity))
        {
            hitPosition = hitInfo.point;
        }
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, currentPosition);
        lineRenderer.SetPosition(1, hitInfo.point);

        //if (thumbstickPressed == true)
        //{
        //    startPosition = transform.position;
        //    endPosition = startPosition + transform.rotation * new Vector3(0, 0, transitionDistance);
        //    transitionProgress = 0;
        //}
        //if (transitionProgress < 1)
        //{
        //    transitionProgress += Time.deltaTime / transitionTime;
        //    transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
        //}




    }
}