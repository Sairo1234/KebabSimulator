using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PacienciaCola : MonoBehaviour
{
    public float timeRemaining = 45;

    [Header("Animator Cliente")]
    public Animator animatorCliente;
    public bool activado = false;

    void Update()
    {
        
        if(timeRemaining>=20 && timeRemaining<=21)
        {
            animatorCliente.SetTrigger("Impaciente");
            timeRemaining -= Time.deltaTime;
            activado = true;
            
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
