using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ReputacionDinero : MonoBehaviour
{

    //-------------------------------------------------------------------------------------//
    //----------------------------------- REPUTACIÓN --------------------------------------//

    int maxReputacion;
    public float Reputacion = 0;
    public Image BarraReputacion;
    public Text texto_Nivel;
    int Nivel = 1;

    //----------------------------------------------------------------------------------//
    //----------------------------------- DINERO --------------------------------------//

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
        }
        else if(Reputacion == 0 && Nivel !=0 )
        {
            Nivel--;
            Reputacion = 99;
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
