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
        carnePedido = ingredientesCarne[Random.Range(0 , ingredientesCarne.Count-1)];
        verduraPedido = ingredientesVerdura[Random.Range(0, ingredientesVerdura.Count - 1)];
        salsaPedido = ingredientesSalsa[Random.Range(0, ingredientesSalsa.Count - 1)];
    }

    //--------------------------------------------------------------------------//
    //---------------------- MOSTRAR PEDIDO EN DIALOGO -------------------------//

    private void mostrarPedidoDialogo()
    {
        texto_dialogo.text = "Hola, quiero un kebab con " + "<color=#008080ff><b> carne de " + carnePedido.nombre + "</b></color>"
            + ", <color=#008080ff><b>" + verduraPedido.nombre + "</b></color> y <color=#008080ff><b>salsa " + salsaPedido.nombre + "</b></color>.";
    }
}
