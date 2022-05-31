using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MesaController : MonoBehaviour
{
    [Header("Espacios de la mesa")]
    public List<Transform> EspaciosMesaKebab = new List<Transform>();

    [Header("Spawn Kebab")]
    public Transform spawnKebab;

    void Update()
    {
        ComprobarMesa();
    }

    public void ComprobarMesa()
    {
        if (spawnKebab.childCount > 0 )
        {
            bool comprobacionMesa = ComprobarMaximaCapacidadMesa();

            if (comprobacionMesa == false) 
            {
                //Debug.Log("Hay huecos");
                this.gameObject.GetComponent<DesplazamientoPunto>().enabled = true;
                this.gameObject.GetComponent<OutlineDeObjeto>().enabled = true;
            }
            else if(comprobacionMesa == true)
            {
                //Debug.Log("Mesa llena");
                this.gameObject.GetComponent<DesplazamientoPunto>().enabled = false;
                this.gameObject.GetComponent<OutlineDeObjeto>().enabled = false;
            }
        }
        else if (spawnKebab.childCount == 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = false;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = false;
        }
    }

    public bool ComprobarMaximaCapacidadMesa()
    {
        int espaciosOcupados = 0;

        
        for(int i=0; i <= EspaciosMesaKebab.Count - 1;i++)
        {
            if (EspaciosMesaKebab[i].GetChildCount() == 1)
            {
                espaciosOcupados++;
            }
        }

        if (espaciosOcupados == 8)
        {
            return true;
        }

        return false;
    }

}

