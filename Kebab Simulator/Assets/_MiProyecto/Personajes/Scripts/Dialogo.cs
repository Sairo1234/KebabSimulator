using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogo : MonoBehaviour
{
    //Cuadro de diálogo
    public GameObject PanelDialogo;
   
    public void mostrarDialogo()
    {
        this.gameObject.GetComponent<PacienciaCola>().enabled = false;
        PanelDialogo.SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().enabled = false;
    }

    public void ocultarDialogo()
    {
        PanelDialogo.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Mov>().enabled = true;

    }

}
