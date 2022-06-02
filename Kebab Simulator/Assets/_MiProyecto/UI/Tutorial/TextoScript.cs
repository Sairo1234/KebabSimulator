using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class TextoScript : MonoBehaviour
{
    public Text messageText;
    private TextWriter.TextWriterSingle textWriterSingle;
    private AudioSource tutorialAudioSource;
    private void Awake()
    {
        messageText = transform.Find("Mensaje").transform.Find("TutorialText").GetComponent<Text>();
        tutorialAudioSource = transform.Find("SonidoMensaje").GetComponent<AudioSource>();

        transform.Find("Mensaje").GetComponent<Button_UI>().ClickFunc = () =>
        {
            if (textWriterSingle != null && textWriterSingle.IsActive())
            {
                //Currently active TextWriter
                textWriterSingle.WriteAllAndDestroy();
            }
            else
            {
                string[] messageArray = new string[]
                {
                "Mi cara cuando yo",
                "El xevi, sensillamente el xevi",
                "La vida la vida la vida, que tene que tene la cosaaa",
                "Chicos mirad mi pantalla un momento por favor, esto es muy importante, os voy a enseñar a hacer click con el raton",
                "Os he contado alguna vez el chiste de los bolos y los rolex?",
                };
                string message = messageArray[Random.Range(0, messageArray.Length)];
                StartSound();
                textWriterSingle = TextWriter.AddWriter_Static(messageText, message, 0.01f, true, true, StopSound);
            }
        };
    }
    private void StartSound()
    {
        tutorialAudioSource.Play();
    }
    private void StopSound()
    {
        tutorialAudioSource.Stop();
    }
    private void Start()
    {
        //messageText.text = "Saludos Adrian Cumeador";
        //TextWriter.AddWriter_Static(messageText, "Saludos Adrian Cumeador Saludos Adrian Cumeador Saludos Adrian Cumeador Saludos Adrian Cumeador", 0.05f, true);
    }
}
