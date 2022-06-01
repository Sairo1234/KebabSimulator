using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNumeroDia : MonoBehaviour
{
    
    void Update()
    {
        this.gameObject.GetComponent<Text>().text = "DIA " + GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().numDia.ToString();
    }
}
