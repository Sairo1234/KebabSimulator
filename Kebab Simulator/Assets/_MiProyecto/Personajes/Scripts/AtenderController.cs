using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtenderController : MonoBehaviour
{
    public Transform spawnKebab;
    
    void Update()
    {
            ComprobarMano();
    }

    public void ComprobarMano()
    {
        if (this.gameObject.transform.childCount != 0)
        {
            if (Vector3.Distance(this.gameObject.transform.position, this.gameObject.transform.GetChild(0).transform.position) < 0.6)
            {
                //this.gameObject.transform.GetChild(0).transform.GetChild(2).GetComponent<OutlineDeObjeto>().enabled = true;
                if (spawnKebab.childCount > 0)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<DesplazamientoPunto>().enabled = false;
                    
                }
                else if (spawnKebab.childCount == 0)
                {
                    this.gameObject.transform.GetChild(0).GetComponent<DesplazamientoPunto>().enabled = true;
                }
            }
        }
        
        
    }
}
