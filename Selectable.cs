using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        var render = GetComponent<Renderer>();
        render.material.SetColor("_Color", Color.red);

    }

    // Update is called once per frame
    void Update()
    {
        var render = GetComponent<Renderer>();
        // reset color..
        if (isSelected == false)
        {
            render.material.SetColor("_Color", Color.red);
        }
        else
        {
            render.material.SetColor("_Color", Color.yellow);
        }



    }

    public  void Select()
    {  
         isSelected = true;
        
    }

    public void Deselect()
    {
        isSelected = false;
    }


}

