using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacienciaCola : MonoBehaviour
{
    public float timeRemaining = 45;

    [Header("Animator Cliente")]
    public Animator animatorCliente;
    private bool aunNoSeHaQuejado = true;

    void Update()
    {
        
        if(aunNoSeHaQuejado && timeRemaining<=20)
        {
            animatorCliente.SetTrigger("Impaciente");
            timeRemaining -= Time.deltaTime;
            aunNoSeHaQuejado = false;
            
        }
        else if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            this.gameObject.GetComponent<SalidaCliente>().rechazoPedido();
            this.gameObject.GetComponent<SalidaCliente>().salir();
            this.enabled = false;
        }
    }

}
