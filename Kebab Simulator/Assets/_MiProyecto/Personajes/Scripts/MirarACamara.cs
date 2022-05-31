using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarACamara : MonoBehaviour
{
    public Transform camara;

    // Update is called once per frame
    void Update()
    {
        try
        {
            if (this.gameObject.transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).gameObject.active == true)
            {

                this.gameObject.transform.GetChild(0).transform.LookAt(camara);
            }

        }
        catch { }
    }
}
