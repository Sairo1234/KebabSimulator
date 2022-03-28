using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SalidaCliente : MonoBehaviour
{

    public Transform destino;

    NavMeshAgent agent;

    public GameObject parentObject;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destino.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0)
        {
            Instantiate(parentObject);
            Destroy(parentObject);
            
        }

    }

    private void OnEnable()
    {
        try { 
        agent.SetDestination(destino.position);
        }
        catch
        {
            Debug.Log("Se va");
        }
    }

}
