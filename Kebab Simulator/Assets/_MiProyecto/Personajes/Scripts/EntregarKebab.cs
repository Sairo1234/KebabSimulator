using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EntregarKebab : MonoBehaviour
{
    //MOVIMIENTO A LA COCINA
    public Transform destino;
    public NavMeshAgent jugador;
    public GameObject cliente;
    private bool estaEntregandoKebab = false;

    //ENTREGAR KEBAB
    private GameObject kebabParaEntregar;
    
    SalidaCliente salida;


    private void Start()
    {
        salida = GetComponent<SalidaCliente>();

        GameObject GameObjectdestino = GameObject.FindGameObjectWithTag("PosicionAtender");
        destino = GameObjectdestino.transform;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();

    }
    private void Update()
    {
        if (estaEntregandoKebab == true)
        {
            comprobarDistaciaCliente();
        }


    }
    private void OnMouseDown()
    {
        if (this.enabled)
        {
            try
            {
                kebabParaEntregar = GameObject.FindGameObjectWithTag("KebabEnPreparacion");

                if (kebabParaEntregar.GetComponent<Kebab>().contieneCarne() == true && kebabParaEntregar.GetComponent<Kebab>().contieneVerdura() == true && kebabParaEntregar.GetComponent<Kebab>().contieneSalsa() == true)
                {

                    jugador.SetDestination(destino.position);
                    estaEntregandoKebab = true;
                    Debug.Log("Perfe mister");
                    StartCoroutine(SeVa());
                }
                
                else
                {
                    Debug.Log("El kebab no está completo");
                }
            }
            catch
            {
                Debug.Log("No hay kebab");
            }
        }

    }

    public void entregarKebab()
    {
        Destroy(kebabParaEntregar);
        Debug.Log("Se ha tirado el kebab");

    }

    private void comprobarDistaciaCliente()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(cliente.transform);
            estaEntregandoKebab = false;
            entregarKebab();
        }


    }
    IEnumerator SeVa()
    {
        yield return new WaitForSeconds(1);
        salida.enabled = true;
    }

}
