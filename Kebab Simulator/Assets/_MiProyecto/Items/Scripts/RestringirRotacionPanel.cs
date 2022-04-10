using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestringirRotacionPanel : MonoBehaviour
{

    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0.0f, -100, this.transform.parent.rotation.z * -1.0f);
    }
}
