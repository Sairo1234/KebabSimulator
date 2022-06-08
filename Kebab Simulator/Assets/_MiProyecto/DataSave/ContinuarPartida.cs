using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ContinuarPartida : MonoBehaviour
{
    public Button continuar;
    public EventTrigger eventTriggerHover;

    [Header("DataInfo")]
    public DataPlayerInfo infoJugador;

    private void Update()
    {
        if(infoJugador.partidaEmpezada == true)
        {
            eventTriggerHover.enabled = true;
            continuar.GetComponent<Button>().interactable = true;
            continuar.GetComponent<BotonHover>().enabled = true;
        }
        else
        {
            eventTriggerHover.enabled = false;
            continuar.transform.GetChild(0).GetComponent<Text>().color = new Color(41f / 255f, 41f / 255f, 41f / 255f, 119f/255f);
            continuar.GetComponent<Button>().interactable = false;
            continuar.GetComponent<BotonHover>().enabled = false;
        }
    }
}
