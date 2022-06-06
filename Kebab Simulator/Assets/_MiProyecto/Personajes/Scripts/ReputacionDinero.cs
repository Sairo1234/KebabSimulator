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
    public Text texto_Dinero;
    public float Dinero = 0;

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
        else if(Reputacion == 0 && Nivel !=0 )
        {
            Nivel--;
            Reputacion = 99;
            GUIbajarNivel.SetActive(true);
        }
        else if(Reputacion == 0 && Nivel == 0)
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
        Dinero += dinero;
    }

    void MostrarDinero()
    {
        texto_Dinero.text = Dinero.ToString();
    }


}
