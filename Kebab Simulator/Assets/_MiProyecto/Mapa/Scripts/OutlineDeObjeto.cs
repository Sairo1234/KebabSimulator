using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OutlineDeObjeto : MonoBehaviour
{
    Outline outline;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        outline.enabled = false;
    }

    private void OnMouseEnter()
    {
        if (this.enabled)
        {
            outline.enabled = true;
        }
    }

    private void OnMouseExit()
    {
        if (this.enabled)
        {
            outline.enabled = false;
        }
    }
    private void OnDisable()
    {
        outline.enabled = false;
    }
}
