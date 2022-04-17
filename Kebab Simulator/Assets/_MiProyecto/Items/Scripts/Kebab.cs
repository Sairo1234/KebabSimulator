using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kebab : MonoBehaviour
{
    //KebabInfo
    public Carne carne;
    public Verdura verdura;
    public Salsa salsa;


    //----------------------------------------------------//
    //------------------- ContieneCarne ------------------//


    public bool contieneCarne()
    {
        if (this.carne == null)
        {
            return false;
        }
        return true;
    }


    //----------------------------------------------------//
    //------------------ ContieneVerdura -----------------//

    public bool contieneVerdura()
    {
        if (this.verdura == null)
        {
            return false;
        }
        return true;
    }


    //----------------------------------------------------//
    //------------------- ContieneSalsa ------------------//

    public bool contieneSalsa()
    {
        if (this.salsa == null)
        {
            return false;
        }
        return true;
    }
    
}
