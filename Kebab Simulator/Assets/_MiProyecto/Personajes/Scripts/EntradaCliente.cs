using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EntradaCliente : MonoBehaviour
{
    public List<Transform> transformsCola = new List<Transform>();
    public GameObject[] gameObjectsCola;

    NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Busqueda de los Transform Cola
        gameObjectsCola = GameObject.FindGameObjectsWithTag("Cola").OrderBy(go => go.name).ToArray();

        for (int i = 0; i < gameObjectsCola.Length; i++)
        {
            transformsCola.Insert(i, gameObjectsCola[i].transform);

        }

        consultarCola();
    }

    private void Update()
    {
        consultarCola();
    }

    public void consultarCola()
    {
        for (int i = transformsCola.Count; i >0 ; i--)
        {
            if (transformsCola[i-1].childCount == 0)
            {
                agent.SetDestination(transformsCola[i-1].position);
                this.gameObject.transform.SetParent(transformsCola[i-1]);
            }
        }
    }

}
