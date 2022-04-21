using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class EsperaCliente : MonoBehaviour
{
    public List<Transform> transformsEspera = new List<Transform>();
    public GameObject[] gameObjectsEspera;
    NavMeshAgent agent;

    public GameObject Pared;

    private bool esta = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //Busqueda de los Transform Cola
        gameObjectsEspera = GameObject.FindGameObjectsWithTag("Espera").OrderBy(go => go.name).ToArray();
        Pared = GameObject.FindGameObjectWithTag("paredFondo");

        for (int i = 0; i < gameObjectsEspera.Length; i++)
        {
            transformsEspera.Insert(i, gameObjectsEspera[i].transform);

        }

        for (int i = transformsEspera.Count; i > 0; i--)
        {
            if (transformsEspera[i - 1].childCount == 0)
            {
                agent.SetDestination(transformsEspera[i - 1].position);
                this.gameObject.transform.SetParent(transformsEspera[i - 1]);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {

        if (esta == true)
        {
            comprobarDistacia();
        }
    }

    private void comprobarDistacia()
    {
        if (agent.remainingDistance == 0)
        {
            agent.transform.LookAt(Pared.transform);
            esta = false;

        }
    }
}
