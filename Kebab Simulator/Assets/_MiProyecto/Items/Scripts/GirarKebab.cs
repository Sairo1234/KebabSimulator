using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarKebab : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(0, Time.deltaTime * 25, 0);
    }
}
