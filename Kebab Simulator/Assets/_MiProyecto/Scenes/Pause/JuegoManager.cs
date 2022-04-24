using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class JuegoManager : MonoBehaviour
{
    public GameObject pantallaPausa;

 
    void Update()
    {
        Pausa();
    }
    
    public void Pausa()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            pantallaPausa.SetActive(true);
            Time.timeScale = 0;
            
        }
    }

    public void Continuar()
    {
        pantallaPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void volverInicio()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
}
