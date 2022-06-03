using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoResumenDia : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("GameObject")]
    public GameObject gameManager;

    [Header("Textos")]
    public Text headerResumen;
    public Text textoKebabsPerfectos;
    public Text textoKebabsIncorrectos;
    public Text textoClientesPerdidos;
    public Text textoClientesRechazados;
    public Text textoDineroGanado;

    [Header("Estrellas")]
    public GameObject estrellaUno;
    public GameObject estrellaDos;
    public GameObject estrellaTres;

    [Header("Datos")]
    public int numTotalClientes;
    public int numClientesSatisfechos;
    public double porcentaje;

    [Header("Audio")]
    public AudioSource SonidoEstrella;


    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//


    private void OnEnable()
    {
        calcularResultadoDia();
        mostrarInformacionDia();
    }
    private void OnDisable()
    {
        estrellaUno.SetActive(false);
        estrellaDos.SetActive(false);
        estrellaTres.SetActive(false);
    }


    void Update()
    {


    }

    public void mostrarInformacionDia()
    {
        //Header del Resumen
        headerResumen.text = "RESUMEN  DIA " + gameManager.GetComponent<GameManager>().numDia.ToString();

        //Textos clientes
        textoClientesPerdidos.text = gameManager.GetComponent<GameManager>().clientesPerdidos.ToString();
        textoClientesRechazados.text = gameManager.GetComponent<GameManager>().clientesRechazados.ToString();

        //Textos kebabs
        textoKebabsPerfectos.text = gameManager.GetComponent<GameManager>().numKebabsPerfectos.ToString();
        textoKebabsIncorrectos.text = gameManager.GetComponent<GameManager>().numKebabsIncorrectos.ToString();

        //Texto dinero
        textoDineroGanado.text = gameManager.GetComponent<GameManager>().dineroGanado.ToString();

        StartCoroutine(mostrarEstrellaUno());
        StartCoroutine(mostrarEstrellaDos());
        StartCoroutine(mostrarEstrellaTres());
        SonidoEstrella.pitch = 1f;
    }

    public void calcularResultadoDia()
    {
        numTotalClientes = gameManager.GetComponent<GameManager>().clientesMax;
        numClientesSatisfechos = gameManager.GetComponent<GameManager>().numKebabsPerfectos;
        porcentaje = ((float)numClientesSatisfechos / (float)numTotalClientes) * 100;
    }

    IEnumerator mostrarEstrellaUno()
    {
        yield return new WaitForSeconds(2);

        if (porcentaje == 0)
        {
            estrellaUno.SetActive(true);
            SonidoEstrella.pitch = 1f;
            SonidoEstrella.Play();
        }


    }
    IEnumerator mostrarEstrellaDos()
    {
        yield return new WaitForSeconds(2.5f);

        if (porcentaje == 0)
        {
            estrellaDos.SetActive(true);
            SonidoEstrella.pitch = 1.2f;
            SonidoEstrella.Play();
        }
    }
    IEnumerator mostrarEstrellaTres()
    {
        yield return new WaitForSeconds(3);

        if (porcentaje == 0)
        {
            estrellaTres.SetActive(true);
            SonidoEstrella.pitch = 1.4f;
            SonidoEstrella.Play();
        }

    }
}