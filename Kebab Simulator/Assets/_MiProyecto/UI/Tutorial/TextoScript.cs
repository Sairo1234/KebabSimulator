using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoScript : MonoBehaviour
{
    public Text messageText;
    private void Awake()
    {
        messageText = transform.Find("TutorialText").GetComponent<Text>();
    }
    private void Start()
    {
        //messageText.text = "Saludos Adrian Cumeador";
        TextWritter.AddWriter_Static(messageText, "Saludos Adrian Cumeador Saludos Adrian Cumeador Saludos Adrian Cumeador Saludos Adrian Cumeador", 0.05f, true);
    }
}
