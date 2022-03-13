using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SalidaCliente : MonoBehaviour
{

    public Transform destino;

    NavMeshAgent agent;

    MaquinaFSM maquina;
    EntradaCliente entrada;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(destino.position);
        maquina = GetComponent<MaquinaFSM>();
        entrada = GetComponent<EntradaCliente>();
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance == 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnEnable()
    {
        agent.SetDestination(destino.position);
    }
}
