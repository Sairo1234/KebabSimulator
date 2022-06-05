using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoButtonsCarne : MonoBehaviour
{
    ////----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Carne")]
    public Carne ingredienteCarne;

    [Header("Textos")]
    public Text headerIngrediente;
    public Text cantidadAlmacen;
    public Text nivelMejora;
    public Text costeUnidades;
    public Text costeMejora;

    [Header("Imagenes")]
    public Sprite[] backgroundIngrediente;
    public Sprite[] imagenesIngrediente;
    public GameObject imagenIngrediente;

    [Header("Jugador")]
    public GameObject jugador;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Update()
    {
        mostrarInformacionDeIngrediente();
    }

    public void mostrarInformacionDeIngrediente()
    {
        //Textos
        headerIngrediente.text = ingredienteCarne.nombre;
        cantidadAlmacen.text = "Almacén: <b>" + ingredienteCarne.unidadesAlmacen.ToString() + "</b>";
        nivelMejora.text = ingredienteCarne.DesbloqueoMejora.ToString();

        //Precios
        costeUnidades.text = ingredienteCarne.costeCompraUnidades.ToString();
        costeMejora.text = ingredienteCarne.costeMejora.ToString();

        actualizarImagenes();

    }

    public void actualizarImagenes()
    {
        switch (ingredienteCarne.nivel)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[0];
                //imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[0];
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[1];
                //imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[1];
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[2];
                //imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[2];
                break;
        }
    }
}
