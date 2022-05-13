using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Velocidad de la camara
    public float panSpeed = 20f;

    //Limite en pantalla
    public Vector2 panLimit;

    // Update is called once per frame
    void Update()
    {
        //Posicion de la camara
        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos.y += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s"))
        {
            pos.y -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a"))
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d"))
        {
            pos.z += panSpeed * Time.deltaTime;
        }

        //Limites de la pantalla
        pos.z = Mathf.Clamp(pos.z, -panLimit.y+30, panLimit.y);
        pos.y = Mathf.Clamp(pos.y, -panLimit.x+15, panLimit.x+25);


        transform.position = pos;
    }
}
