using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAnimator : MonoBehaviour
{
    public Animator animator;
    
    void Update()
    {
        //Asignar animator
        if (animator == null)
        {
            animator = this.gameObject.transform.GetChild(2).gameObject.GetComponent<Animator>();
            this.gameObject.GetComponent<EntradaCliente>().animatorCliente=animator;
            this.gameObject.GetComponent<SalidaCliente>().animatorCliente = animator;
            this.gameObject.GetComponent<PacienciaCola>().animatorCliente = animator;
        }
    }
}
