using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class atenderCliente : MonoBehaviour
{
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cliente;
    public GameObject vista;
    public Camera camaraPrincipal;
    public Camera camaraSecundaria;

    private void Start()
    {
        vista.SetActive(false);
        camaraSecundaria.gameObject.SetActive(false);
    }

    private void LateUpdate()
    {
        if (jugador.remainingDistance >= 0.001 && jugador.remainingDistance <= 0.2)
        {
            vista.SetActive(true);

            Ray ray = camaraPrincipal.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(cliente.name + " " + hit.transform.name);

                //Select stage    
                if (hit.transform.name == cliente.name)
                {
                    camaraSecundaria.gameObject.SetActive(true);
                    camaraPrincipal.gameObject.SetActive(false);
                }
                else
                {
                    camaraSecundaria.gameObject.SetActive(false);
                    camaraPrincipal.gameObject.SetActive(true);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        jugador.SetDestination(destino.position);
    }
}
