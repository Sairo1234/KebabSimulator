using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    //Pantallas
    [Header("Pantallas")]
    public GameObject HUDprincipal;
    public GameObject pantallaPausa;
    public GameObject pantallaDiaTerminado;
    public GameObject pantallaResumenDia;
    public GameObject pantallaTienda;
    public GameObject pantallaDiaNuevo;

    //Datos
    [Header("Datos Clientes")]
    public int clientesContador = 0;
    public int clientesMax = 0;
    public int clientesEnPantalla = 0;
    public float next_spawn_time;
    public float intervalo;

    [Header("Datos Generales")]
    public int numDia;
    public bool haTerminadoDia = false;

    [Header("GameObjects de la escena")]
    public GameObject cliente;
    public GameObject jugador;
    public Transform puntoSpawn;
    public Transform puntoComienzo;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Start()
    {
        nuevoDia();
        next_spawn_time += siguienteSpawn();
    }

    void Update()
    {
        Pausa();

        if (Time.time > next_spawn_time && clientesContador < clientesMax)
        {
            spawnCliente();
            next_spawn_time += siguienteSpawn();
        }

        //clientesEnPantalla = GameObject.FindGameObjectsWithTag("Cliente").Length; 
        contadorClientesEnPantalla();

        if (clientesContador == clientesMax && clientesEnPantalla == 0 && haTerminadoDia == false)
        {
            haTerminadoDia = true;
            TerminarDia();
        }

    }

    //------------------------------------------------------------------------------------------------//
    //---------------------------------------- Gestion de Dias ---------------------------------------//

    public void nuevoDia()
    {
        //puntoDespawn.GetComponent<DespawnCliente>().clientesDespawneados = 0;

        pantallaTienda.SetActive(false);
        resetearEscena();
        PantallaNuevoDia();
        reanudarTiempo();
        clientesContador = 0;
        numDia++;
        setClientesMax();
        haTerminadoDia = false;
    }

    public void TerminarDia()
    {
        //Desactivar movimiento
        jugador.GetComponent<Player_Mov>().enabled = false;
        jugador.transform.GetChild(0).GetComponent<Animator>().SetBool("Andando", false);
        GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();

        //Mostrar pantallas
        HUDprincipal.SetActive(false);
        pantallaDiaTerminado.SetActive(true);
        StartCoroutine(ResumenDia());
    }

    public void resetearEscena()
    {
        //Resetear Posicion del jugador
        jugador.GetComponent<NavMeshAgent>().SetDestination(puntoComienzo.position);
        jugador.transform.LookAt(GameObject.FindGameObjectWithTag("MainCamera").transform);

        //EliminarKebabs de la mesa
        GameObject[] kebabsMesa = GameObject.FindGameObjectsWithTag("KebabEnMesa");

        foreach(GameObject kebabMesa in kebabsMesa)
        {
            Destroy(kebabMesa);
        }

        //EliminarKebab en mano
        GameObject kebabEnPreparacion = GameObject.FindGameObjectWithTag("KebabEnPreparacion");
        if (kebabEnPreparacion != null)
        {
            Destroy(kebabEnPreparacion);
            jugador.transform.GetChild(0).GetComponent<Animator>().SetTrigger("DejaPlato");
        }
        
       
    }

    //------------------------------------------------------------------------------------------------//
    //-------------------------------------- Gestion de Clientes -------------------------------------//

    public void spawnCliente()
    {
        Instantiate(cliente, puntoSpawn.transform);
        clientesContador++;
    }

    public void setClientesMax()
    {
        switch (jugador.GetComponent<ReputacionDinero>().Nivel)
        {
            case 0:
                clientesMax = 5;
                break;
            case 1:
                clientesMax = 5;
                break;
            case 2:
                clientesMax = 7;
                break;
            case 3:
                clientesMax = 8;
                break;
            case 4:
                clientesMax = 10;
                break;
            case 5:
                clientesMax = 12;
                break;
            case 6:
                clientesMax = 13;
                break;
            case 7:
                clientesMax = 15;
                break;
            case 8:
                clientesMax = 16;
                break;
            case 9:
                clientesMax = 18;
                break;
            case 10:
                clientesMax = 20;
                break;
        }
    }

    public float siguienteSpawn()
    {

        switch (jugador.GetComponent<ReputacionDinero>().Nivel)
        {
            case 0:
                intervalo = Random.Range(30.0f, 45.0f);
                break;
            case 1:
                intervalo = Random.Range(25.0f, 40.0f);
                break;
            case 2:
                intervalo = Random.Range(25.0f, 35.0f);
                break;
            case 3:
                intervalo = Random.Range(20.0f, 35.0f);
                break;
            case 4:
                intervalo = Random.Range(25.0f, 35.0f);
                break;
            case 5:
                intervalo = Random.Range(25.0f, 35.0f);
                break;
            case 6:
                intervalo = Random.Range(25.0f, 35.0f);
                break;
            case 7:
                intervalo = Random.Range(25.0f, 30.0f);
                break;
            case 8:
                intervalo = Random.Range(20.0f, 30.0f);
                break;
            case 9:
                intervalo = Random.Range(25.0f, 30.0f);
                break;
            case 10:
                intervalo = Random.Range(20.0f, 25.0f);
                break;

        }
        return intervalo;
    }

    public void contadorClientesEnPantalla()
    {
        int numClientesCola = GameObject.FindGameObjectsWithTag("Cliente").Length;
        int numClientesEspera = GameObject.FindGameObjectsWithTag("ClienteEsperando").Length;
        int numClientesSaliendo = GameObject.FindGameObjectsWithTag("ClienteSaliendo").Length;
        clientesEnPantalla = numClientesCola + numClientesEspera + numClientesSaliendo;
    }

    //------------------------------------------------------------------------------------------------//
    //------------------------------------- Gestion de Pantallas -------------------------------------//

    public void Pausa()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            pantallaPausa.SetActive(true);
            pararTiempo();

            //Desctivar desplazamiento
            jugador.GetComponent<Player_Mov>().enabled = false;
            GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
        }
    }

    public void Continuar()
    {
        pantallaPausa.SetActive(false);
        reanudarTiempo();
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("MainMenu");
        reanudarTiempo();
    }

    public void PantallaNuevoDia()
    {
        pantallaDiaNuevo.SetActive(true);
        StartCoroutine(timerNuevoDia());
    }

    IEnumerator ResumenDia()
    {
        yield return new WaitForSeconds(4);
        //pararTiempo();
        pantallaDiaTerminado.SetActive(false);
        pantallaResumenDia.SetActive(true);
    }

    public void Tienda()
    {
        pantallaResumenDia.SetActive(false);
        pantallaTienda.SetActive(true);
        resetearEscena();
        jugador.GetComponent<Player_Mov>().enabled = false;
        GetComponent<DesplazamientoController>().desactivarDesplazamientoPunto();
    }

    //------------------------------------------------------------------------------------------------//
    //------------------------------------- Gestion de Tiempo ----------------------------------------//

    private void pararTiempo()
    {
        Time.timeScale = 0;
    }

    private void reanudarTiempo()
    {
        Time.timeScale = 1;
        jugador.GetComponent<Player_Mov>().enabled = true;
        GetComponent<DesplazamientoController>().activaDesplazamientoPunto();
    }

    IEnumerator timerNuevoDia()
    {
        yield return new WaitForSeconds(3.5f);
        HUDprincipal.SetActive(true);
        pantallaDiaNuevo.SetActive(false);
        spawnCliente();
    }

    //----------------------------------------------------------------------------------------//
    //----------------------------------------------------------------------------------------//
}
