using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SalidaCliente : MonoBehaviour
{

    [Header("Transforms salida")]
    public Transform TransformSalida;
    public GameObject gameObjectSalida;

    NavMeshAgent agent;

    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        gameObjectSalida = GameObject.FindGameObjectWithTag("Salida");
        TransformSalida = gameObjectSalida.transform;

        agent.SetDestination(TransformSalida.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0)
        {
            Destroy(parentObject);

        }

    }

}
