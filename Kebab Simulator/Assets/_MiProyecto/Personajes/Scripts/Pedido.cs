using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedido : MonoBehaviour
{
    //----------------------------------------------------------------------------------------//
    //--------------------------------------- ATRIBUTOS -------------------------------------//

    [Header("Ingredientes")]
    public List<Carne> ingredientesCarne = new List<Carne>();
    public List<Verdura> ingredientesVerdura = new List<Verdura>();
    public List<Salsa> ingredientesSalsa = new List<Salsa>();

    [Header("Desbloqueados")]
    public List<Carne> ingredientesCarneComprados = new List<Carne>();
    public List<Verdura> ingredientesVerduraComprados = new List<Verdura>();
    public List<Salsa> ingredientesSalsaComprados = new List<Salsa>();

    [Header("Pedido")]
    public Carne carnePedido;
    public Verdura verduraPedido;
    public Salsa salsaPedido;

    [Header("Dialogo")]
    public Text texto_dialogo;

    ///----------------------------------------------------------------------------------------//
    //----------------------------------------- MÉTODOS --------------------------------------//

    void Start()
    {
        pedidoAleatorio();
        mostrarPedidoDialogo();
    }


    //--------------------------------------------------------------------------//
    //------------------------- ALEATORIEDAD PEDIDO ----------------------------//

    private void pedidoAleatorio()
    {
        selectingredientesComprados();
        carnePedido = ingredientesCarneComprados[Random.Range(0, ingredientesCarneComprados.Count)];
        verduraPedido = ingredientesVerduraComprados[Random.Range(0, ingredientesVerduraComprados.Count)];
        salsaPedido = ingredientesSalsaComprados[Random.Range(0, ingredientesSalsaComprados.Count)];
    }

    public void selectingredientesComprados()
    {
        for (int i = 0; i <= ingredientesCarne.Count - 1; i++)
        {
            if (ingredientesCarne[i].estaComprado == true)
            {
                ingredientesCarneComprados.Add(ingredientesCarne[i]);
            }
        }

        for (int i = 0; i <= ingredientesVerdura.Count - 1; i++)
        {
            if (ingredientesVerdura[i].estaComprado == true)
            {
                ingredientesVerduraComprados.Add(ingredientesVerdura[i]);
            }
        }

        for (int i = 0; i <= ingredientesSalsa.Count - 1; i++)
        {
            if (ingredientesSalsa[i].estaComprado == true)
            {
                ingredientesSalsaComprados.Add(ingredientesSalsa[i]);
            }
        }
    }

    //--------------------------------------------------------------------------//
    //---------------------- MOSTRAR PEDIDO EN DIALOGO -------------------------//

    private void mostrarPedidoDialogo()
    {
        texto_dialogo.text = "Hola, quiero un kebab con " + "<color=#008080ff><b> carne de " + carnePedido.nombre + "</b></color>"
            + ", <color=#008080ff><b>" + verduraPedido.nombre + "</b></color> y <color=#008080ff><b>salsa " + salsaPedido.nombre + "</b></color>.";
    }
}