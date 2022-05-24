using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pantallaPausa;

    int numDia = 1;
    public int clientesContador = 0;
    public int clientesMax = 0;
    public int clientesEnPantalla = 0;
    public float next_spawn_time;
    public float intervalo;
    public GameObject cliente;
    public GameObject jugador;
    public Transform puntoSpawn;
    public GameObject panel;
    public GameObject HUDprincipal;
    // Start is called before the first frame update
    void Start()
    {
        nuevoDia();

        //increment next_spawn_time
        next_spawn_time += siguienteSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        Pausa();

        if (Time.time > next_spawn_time && clientesContador < clientesMax)
        {
            //do stuff here (like instantiate)
            spawnCliente();

            //increment next_spawn_time
            next_spawn_time += siguienteSpawn();
        }

        clientesEnPantalla = GameObject.FindGameObjectsWithTag("Cliente").Length;

        if (clientesContador == clientesMax && clientesEnPantalla == 0)
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            HUDprincipal.SetActive(false);
        }
    }
    public void nuevoDia()
    {
        //puntoDespawn.GetComponent<DespawnCliente>().clientesDespawneados = 0;
        panel.SetActive(false);
        HUDprincipal.SetActive(true);
        Time.timeScale = 1;
        numDia++;
        clientesContador = 0;
        spawnCliente();
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
    public void spawnCliente()
    {
        Instantiate(cliente, puntoSpawn.transform);

        clientesContador++;
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

    public void Pausa()
    {
        if (Input.GetKeyUp(KeyCode.Backspace))
        {
            pantallaPausa.SetActive(true);
            Time.timeScale = 0;

        }
    }

    public void Continuar()
    {
        pantallaPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
