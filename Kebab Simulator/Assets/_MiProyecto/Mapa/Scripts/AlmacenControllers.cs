using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlmacenControllers : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform spawnKebab;

    void Update()
    {
        ComprobarMano();
    }

    public void ComprobarMano()
    {
        if (spawnKebab.childCount == 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = true;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = true;
        }
        else if (spawnKebab.childCount > 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = false;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = false;
        }
    }
}
