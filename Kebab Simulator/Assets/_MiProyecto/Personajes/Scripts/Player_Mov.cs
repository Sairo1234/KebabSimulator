using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player_Mov : MonoBehaviour
{

    public LayerMask whatCanBeClickedOn;
    private NavMeshAgent myAgent;
    public Animator animator;

    public Vector3 puntoDestino;
    public bool estaMoviendose = false;

    void Start()
    {
        myAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(myRay, out hitInfo, 100, whatCanBeClickedOn))
            {
                puntoDestino = hitInfo.point;
                estaMoviendose = true;
                myAgent.SetDestination(hitInfo.point);
                animator.SetBool("Andando", true);
            }
        }
        if (estaMoviendose == true)
        {
            if (Vector3.Distance(this.gameObject.transform.position, puntoDestino) < 1)
            {
                animator.SetBool("Andando", false);
            }
        }
    }

}
