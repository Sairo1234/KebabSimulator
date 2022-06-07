using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public Canvas[] listaCanvas;

    public List<Button> siguiente;

    private int contador = 0;

    private void Start()
    {

        Time.timeScale = 0;

        listaCanvas = GetComponentsInChildren<Canvas>();

        foreach (Canvas canvas in listaCanvas)
        {
            siguiente.Add(canvas.GetComponentInChildren<Button>());

            canvas.enabled = false;
        }

        listaCanvas[0].enabled = true;

        for (int i = 0; i < siguiente.Count - 1; i++)
        {
            siguiente[i].onClick.AddListener(() =>
            {
                listaCanvas[contador].enabled = false;
                contador++;
                listaCanvas[contador].enabled = true;
            });
        }

        siguiente[siguiente.Count - 1].GetComponentInChildren<Text>().text = "Cerrar";
        siguiente[siguiente.Count - 1].onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);

            Time.timeScale = 1;
        });
    }
}