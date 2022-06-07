using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReputacionDinero : MonoBehaviour
{

    //-------------------------------------------------------------------------------------//
    //----------------------------------- REPUTACIÓN --------------------------------------//

    [Header("Reputacion")]
    public int Nivel = 1;
    public float Reputacion = 0;
    int maxReputacion;

    [Header("GUI Reputacion")]
    public Image BarraReputacion;
    public Text texto_Nivel;
    public GameObject GUIsubirNivel;
    public GameObject GUIbajarNivel;


    //----------------------------------------------------------------------------------//
    //----------------------------------- DINERO --------------------------------------//

    [Header("Dinero")]
    public float Dinero = 0;

    [Header("GUI Dinero")]
    public Text texto_Dinero;
    public GameObject GUIGanarDinero;
    public Text texto_dineroGanado;
    public Text GUIGastarDinero;

    //----Constante----//
    float d = 5;



    // Start is called before the first frame update
    void Start()
    {
        maxReputacion = 100;
        texto_Nivel.text = "0";
        texto_Dinero.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        MostrarDinero();
        MostrarReputacion();
    }

    //-------------------------------------------------------------------------------------//
    //----------------------------------- REPUTACIÓN --------------------------------------//

    public void TakeReputacion(float reputacion)
    {

        Reputacion += reputacion;
        Reputacion = Mathf.Clamp(Reputacion, 0, maxReputacion);

        if (Reputacion >= maxReputacion)
        {
            Nivel++;
            Reputacion = 1;
            GUIsubirNivel.SetActive(true);
        }
        else if (Reputacion == 0 && Nivel != 0)
        {
            Nivel--;
            Reputacion = 99;
            GUIbajarNivel.SetActive(true);
        }
        else if (Reputacion == 0 && Nivel == 0)
        {
            Debug.Log("Has perdido");
        }
    }

    void MostrarReputacion()
    {
        BarraReputacion.fillAmount = Reputacion / maxReputacion;
        texto_Nivel.text = Nivel.ToString();
    }



    //----------------------------------------------------------------------------------//
    //----------------------------------- DINERO --------------------------------------//

    public void TakeDinero(float dinero)
    {
        if (dinero > 0)
        {
            MostrarGanarDinero(dinero);
        }
        else if (dinero < 0)
        {
            MostrarGastarDinero(dinero);
        }

        Dinero += dinero;
    }

    //---------------------------------------------------------------//
    //-------------------------- GUI DINERO -------------------------//
    void MostrarDinero()
    {
        texto_Dinero.text = Dinero.ToString();
    }

    public void MostrarGanarDinero(float dineroGanado)
    {
        texto_dineroGanado.text = "+" + dineroGanado.ToString();
        GUIGanarDinero.SetActive(true);
        StartCoroutine(pararAnimacionGanarDinero());
    }

    IEnumerator pararAnimacionGanarDinero()
    {
        yield return new WaitForSeconds(1);
        GUIGanarDinero.SetActive(false);
        texto_dineroGanado.text = "-";
    }

    public void MostrarGastarDinero(float dineroGastado)
    {
        GUIGastarDinero.text =  dineroGastado.ToString();
        GUIGastarDinero.gameObject.SetActive(true);
        StartCoroutine(pararAnimacionGastarDinero());
    }

    IEnumerator pararAnimacionGastarDinero()
    {
        yield return new WaitForSeconds(1);
        GUIGastarDinero.gameObject.SetActive(false);
        GUIGastarDinero.text = "-";
    }

}
