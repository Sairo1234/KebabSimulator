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

    private bool yaEsPrimero = true;

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
        //Debug.Log(Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Cola1").transform.position));

    }

    public void consultarCola()
    {
        for (int i = transformsCola.Count; i > 0; i--)
        {
            if (transformsCola[i - 1].childCount == 0)
            {
                agent.SetDestination(transformsCola[i - 1].position);
                this.gameObject.transform.SetParent(transformsCola[i - 1]);
            }


        }
        if (Vector3.Distance(this.gameObject.transform.position, GameObject.Find("Cola1").transform.position) < 1 && yaEsPrimero)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = true;
            this.gameObject.GetComponent<OutlineDeObjeto>().enabled = true;
            yaEsPrimero = false;
        }
    }

}
