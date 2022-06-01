using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class NPCExterior : MonoBehaviour
{
    //Create a list of transforms
    public List<Transform> listaTransform;

    public Animator animatorCliente;
    public int num;
    void Start()
    {
        num = Random.Range(0, 3);
        GameObject[] listaPuntosGameObject = GameObject.FindGameObjectsWithTag("DispawnExterior");
        //put every transform of the element of listaPuntosGameObject in listaTrasnform

        foreach (GameObject punto in listaPuntosGameObject)
        {
            listaTransform.Add(punto.transform);
        }

        //listaTransform.Add(GameObject.FindGameObjectWithTag("DispawnExterior").transform);
        this.gameObject.GetComponent<NavMeshAgent>().SetDestination(listaTransform[num].position);

    }
    private void Update()
    {
        if (animatorCliente == null)
        {
            animatorCliente = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
            animatorCliente.SetBool("Andando", true);
        }
        comprobarDistacia();

    }

    //Function that destroys this gameobject when it reaches any gameobject in the list listaPuntosGameobject
    public void comprobarDistacia()
    {
        if (Vector3.Distance(this.transform.position, this.gameObject.GetComponent<NavMeshAgent>().destination) < 1)
        {
            Destroy(this.gameObject);
        }
    }

}
