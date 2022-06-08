using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMejorasIngredienteVerdura : MonoBehaviour
{
    [Header("Ingrediente")]
    public Verdura ingredienteVerdura;
    public GameObject[] modelosIngredientes;

    void Update()
    {
        comprobarNivelIngrediente();
    }

    public void comprobarNivelIngrediente()
    {
        if (ingredienteVerdura.estaComprado == true && ingredienteVerdura.estaDesbloqueado == true)
        {
            switch (ingredienteVerdura.nivel)
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
