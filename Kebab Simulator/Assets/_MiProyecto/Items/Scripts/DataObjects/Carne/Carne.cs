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
    public int nivelDesbloqueoMejora;

    [Header("Costes")]
    public float costeCompra;
    public float costeMejora;
    public float precioEntrega;
}
