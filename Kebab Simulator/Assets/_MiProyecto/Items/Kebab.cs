using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kebab : MonoBehaviour
{
    //KebabInfo

    public string Carne;
    public string Verdura;
    public string Salsa;


    //----------------------------------------------------//
    //------------------- AnyadirCarne -------------------//

    public void anyadirCarne(string carne)
    {
        this.Carne = carne;
    }


    //----------------------------------------------------//
    //------------------- AnyadirVerdura -----------------//

    public void anyadirVerdura(string verdura)
    {
        this.Verdura = verdura;
    }


    //----------------------------------------------------//
    //------------------- AnyadirSalsa -------------------//

    public void anyadirSalsa(string salsa)
    {
        this.Salsa = salsa;
    }


    //----------------------------------------------------//
    //------------------- ContieneCarne ------------------//


    public bool contieneCarne()
    {
        if (this.Carne == "-")
        {
            return false;
        }
        return true;
    }


    //----------------------------------------------------//
    //------------------ ContieneVerdura -----------------//

    public bool contieneVerdura()
    {
        if (this.Verdura == "-")
        {
            return false;
        }
        return true;
    }


    //----------------------------------------------------//
    //------------------- ContieneSalsa ------------------//

    public bool contieneSalsa()
    {
        if (this.Salsa == "-")
        {
            return false;
        }
        return true;
    }
}
