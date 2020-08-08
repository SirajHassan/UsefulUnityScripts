using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandlers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TestButton()
    {
        Debug.Log("Hello World!");
        GameObject pointLight = GameObject.Find("Point Light");
        pointLight.GetComponent<Light>().intensity = 0;
    }

    public void TestSlider(float value)
    {
        Debug.Log("Slider value: " + value);
        GameObject pointLight = GameObject.Find("Point Light");

        pointLight.GetComponent<Light>().intensity = value;

    }
}