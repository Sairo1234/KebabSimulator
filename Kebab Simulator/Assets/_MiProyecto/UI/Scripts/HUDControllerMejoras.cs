using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDControllerMejoras : MonoBehaviour
{
    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Botones de Mejora")]
    public Button[] botonesMejora;

   
    void Update()
    {
        setBotonMejora();
    }

    public void setBotonMejora()
    {
        if (ingredienteCarne.nivel == 1)
        {
            botonesMejora[0].gameObject.SetActive(false);
            botonesMejora[1].gameObject.SetActive(true);
        }
        else if (ingredienteCarne.nivel == 2)
        {
            botonesMejora[1].enabled = false;
        }
    }

    public void mejoraDesbloqueada()
    {

    }
}
