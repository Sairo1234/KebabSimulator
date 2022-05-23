using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaController : MonoBehaviour
{

    public Transform spawnKebab;
    // Update is called once per frame
    void Update()
    {
        ComprobarMano();
    }
    public void ComprobarMano()
    {
        if (spawnKebab.childCount > 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = true;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = true;
        }
        else if (spawnKebab.childCount == 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = false;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = false;
        }
    }
}
