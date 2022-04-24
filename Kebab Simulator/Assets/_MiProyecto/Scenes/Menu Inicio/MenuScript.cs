using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void escenaJuego()
    {
        SceneManager.LoadScene("greyBoxingInicio");
    }

    public void salir()
    {
        Debug.Log("Has salido");
        Application.Quit();
    }
}
