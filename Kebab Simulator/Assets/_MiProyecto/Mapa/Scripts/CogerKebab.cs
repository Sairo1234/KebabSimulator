using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CogerKebab : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Posicion SpawnKebab
    private Transform puntoSpawnKebab;

    //Kebab que se va a coger
    private GameObject kebabParaCoger;

    //MOVIMIENTO A LA MESA
    public Transform destinoMesa;
    private NavMeshAgent jugador;
    private GameObject kebab;
    private bool estaDesplazandose = false;

    //Animacion CogerKebab
    public Animator animatorJugador;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    private void Start()
    {
        kebab = this.gameObject;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>();
        destinoMesa = GameObject.FindGameObjectWithTag("MesaPunto").transform;
        animatorJugador = GameObject.FindGameObjectWithTag("ModeloJugador").GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        if (this.enabled)
        {
            jugador.GetComponent<Player_Mov>().enabled = false;
            jugador.SetDestination(destinoMesa.position);
            estaDesplazandose = true;
        }
    }


    //--------------------------------------------------------------------------//
    //----------------------------- DESPLAZAR A MESA ---------------------------//

    private void Update()
    {
        if (estaDesplazandose == true)
        {
            comprobarDistaciaMesa();
        }
    }

    private void comprobarDistaciaMesa()
    {
        if (jugador.remainingDistance == 0)
        {
            jugador.transform.LookAt(kebab.transform);
            estaDesplazandose = false;
            colocarKebabEnJugador();
            jugador.GetComponent<Player_Mov>().enabled = true;
        }
    }

    //--------------------------------------------------------------------------//
    //----------------------- COLOCAR KEBAB EN JUGADOR -------------------------//

    public void colocarKebabEnJugador()
    {
        kebabParaCoger = this.gameObject;
        buscarSpawnKebab();
        if (puntoSpawnKebab.childCount == 0)
        {
            Destroy(this.gameObject);
            animatorJugador.SetTrigger("CogePlatoMesa");
            GameObject KebabEnJugador = Instantiate(kebabParaCoger, puntoSpawnKebab);
            KebabEnJugador.tag = "KebabEnPreparacion";
            KebabEnJugador.GetComponent<OutlineDeObjeto>().enabled = true;
            KebabEnJugador.GetComponent<CogerKebab>().enabled = false;
            KebabEnJugador.GetComponent<MostrarIngredientesKebab>().enabled = true;
        }
        else
        {
            Debug.Log("Tienes un kebab en la mano");
        }

    }

    public void buscarSpawnKebab()
    {
        GameObject SpawnKebab = GameObject.FindGameObjectWithTag("SpawnKebab");
        puntoSpawnKebab = SpawnKebab.transform;
    }

}
