using UnityEngine;

public class Transition : MonoBehaviour
{
    public float transitionTime = 0.1f;
    public float transitionDistance = 2.0f;

    Vector3 startPosition = Vector3.zero;
    Vector3 endPosition = Vector3.zero;
    float transitionProgress = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            startPosition = transform.position;
            endPosition = startPosition + transform.rotation * new Vector3(0, 0, transitionDistance);
            transitionProgress = 0;
        }

        if (transitionProgress < 1)
        {
            transitionProgress += Time.deltaTime / transitionTime;
            transform.position = Vector3.Lerp(startPosition, endPosition, transitionProgress);
        }
    }
}

