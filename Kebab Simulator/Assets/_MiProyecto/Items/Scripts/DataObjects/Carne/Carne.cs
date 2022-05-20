using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Carne", menuName = "Items del juego/Ingredientes/Carne", order =
51)]

public class Carne : ScriptableObject
{
    [Header("Propiedades Carne")]
    public string nombre;
    public string tipo;
    public int nivel;
    public int unidadesAlmacen;
    public int capacidadMaxIngrediente;
    public bool especial;
    public bool estaDesbloqueado;
    public bool estaComprado;

    [Header("Niveles de desbloqueo")]
    public int DesbloqueoMejora;
    public int DesbloqueoCompra;

    [Header("Costes")]
    public float costeCompra;
    public float costeCompraUnidades;
    public float costeMejora;
    public float precioVenta;
}
