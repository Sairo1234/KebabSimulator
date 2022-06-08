using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMejorasIngredientesCarne : MonoBehaviour
{
    [Header("Ingrediente")]
    public Carne ingredienteCarne;
    public GameObject[] modelosIngredientes;

    void Update()
    {
        comprobarNivelIngrediente();
    }

    public void comprobarNivelIngrediente()
    {
        if (ingredienteCarne.estaComprado == true && ingredienteCarne.estaDesbloqueado == true)
        {
            switch (ingredienteCarne.nivel)
            {
                case 0:
                    modelosIngredientes[0].SetActive(true);
                    modelosIngredientes[1].SetActive(false);
                    modelosIngredientes[2].SetActive(false);
                    break;
                case 1:
                    modelosIngredientes[0].SetActive(false);
                    modelosIngredientes[1].SetActive(true);
                    modelosIngredientes[2].SetActive(false);
                    break;
                case 2:
                    modelosIngredientes[0].SetActive(false);
                    modelosIngredientes[1].SetActive(false);
                    modelosIngredientes[2].SetActive(true);
                    break;

            }
        }
        
    }
}
