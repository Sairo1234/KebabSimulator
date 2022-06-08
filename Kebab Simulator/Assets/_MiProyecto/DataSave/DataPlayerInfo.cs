using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataSave", menuName = "Informacion/DataSave", order =
51)]

public class DataPlayerInfo : ScriptableObject
{
    [Header("Jugador")]
    public float dinero;
    public int nivel;
    public float reputacion;

    [Header("Dias")]
    public int numDia;

    [Header("Partida")]
    public bool partidaEmpezada;

    [Header("Tutorial")]
    public bool TGNoHaSalido;
    public bool TCNoHaSalido;
    public bool TKNoHaSalido;
    public bool TTiendaNoHaSalido;
    public bool TAlmacenNoHaSalido;
}
