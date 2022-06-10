using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControllerAlmacenVerdura : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingrediente de Verdura")]
    public Verdura ingredienteVerdura;
    public GameObject prefabIngrediente;

    [Header("Elementos boton")]
    public Text textoCantidadAlmacen;
    public Text textoCantidadCocina;
    public GameObject headerNombreIngrediente;
    public GameObject imagenIngrediente;
    public GameObject iconoAgotado;

    [Header("Backgrouds Tarjeta")]
    public Sprite[] backgrounds;
    public Sprite backgroundBloqueado;

    [Header("Imagenes")]
    public Sprite[] imagenesIngrediente;

    //----------------------------------------------------------------------------------------//
    //----------------------------------------- M�TODOS --------------------------------------//

    private void Update()
    {
        comprobarCompraIngrediente();
    }

    public void comprobarCompraIngrediente()
    {
        if (ingredienteVerdura.estaComprado == true)
        {
            //Activar textos
            this.gameObject.GetComponent<Button>().interactable = true;
            headerNombreIngrediente.SetActive(true);
            imagenIngrediente.SetActive(true);
            textoCantidadCocina.gameObject.SetActive(true);
            textoCantidadAlmacen.gameObject.SetActive(true);

            setInfoIngrediente();
        }
        else
        {
            this.gameObject.GetComponent<Button>().interactable = false;
            headerNombreIngrediente.SetActive(false);
            imagenIngrediente.SetActive(false);
            textoCantidadCocina.gameObject.SetActive(false);
            textoCantidadAlmacen.gameObject.SetActive(false);

            this.gameObject.GetComponent<Image>().sprite = backgroundBloqueado;
        }
    }
    public void setInfoIngrediente()
    {
        headerNombreIngrediente.transform.GetChild(0).GetComponent<Text>().text = ingredienteVerdura.nombre;
        textoCantidadAlmacen.text = ingredienteVerdura.unidadesAlmacen.ToString();
        setColorCantidadAlmacen();
        textoCantidadCocina.text = "Cocina: " + prefabIngrediente.GetComponent<A�adirVerdura>().cantidad + "/" + ingredienteVerdura.capacidadMaxIngrediente.ToString();
        setBackgroundIngrediente();
    }

    public void setBackgroundIngrediente()
    {
        switch (ingredienteVerdura.nivel)
        {
            case 0:
                this.gameObject.GetComponent<Image>().sprite = backgrounds[0];
                break;
            case 1:
                this.gameObject.GetComponent<Image>().sprite = backgrounds[1];
                break;
            case 2:
                this.gameObject.GetComponent<Image>().sprite = backgrounds[2];
                break;
        }
    }

    public void setImagenIngrediente()
    {
        switch (ingredienteVerdura.nivel)
        {
            case 0:
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[0];
                break;
            case 1:
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[1];
                break;
            case 2:
                imagenIngrediente.GetComponent<Image>().sprite = imagenesIngrediente[2];
                break;
        }
    }

    public void setColorCantidadAlmacen()
    {
        if (ingredienteVerdura.unidadesAlmacen == 0)
        {
            iconoAgotado.SetActive(true);
            textoCantidadAlmacen.GetComponent<Text>().color = new Color(222f / 255f, 42f / 255f, 34f / 255f);
        }
        else
        {
            iconoAgotado.SetActive(false);
            textoCantidadAlmacen.GetComponent<Text>().color = new Color(120f / 255f, 100f / 255f, 54f / 255f);
        }
    }
}
