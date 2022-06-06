using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInfoButtonsVerdura : MonoBehaviour
{
    ////----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;

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
        headerIngrediente.text = ingredienteVerdura.nombre;
        cantidadAlmacen.text = "Almacén: <b> " + ingredienteVerdura.unidadesAlmacen.ToString() + "</b>";
        nivelMejora.text = ingredienteVerdura.DesbloqueoMejora.ToString() ;

        //Precios
        costeUnidades.text = ingredienteVerdura.costeCompraUnidades.ToString();
        costeMejora.text = ingredienteVerdura.costeMejora.ToString();

        StartCoroutine(actualizarImagenes());
    }

    IEnumerator actualizarImagenes()
    {
        yield return new WaitForSeconds(2);
        switch (ingredienteVerdura.nivel)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[0];
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[0];
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[1];
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[1];
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = backgroundIngrediente[2];
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[2];
                break;
        }
    }
}
