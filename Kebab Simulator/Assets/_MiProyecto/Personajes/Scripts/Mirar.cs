using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mirar : MonoBehaviour
{
    // Start is called before the first frame update
 
        NavMeshAgent agent;
        public Camera camaraPrincipal;
        public Camera camaraSecundaria;
        public GameObject cliente;
        
        
     void Start()
     {
       camaraSecundaria.gameObject.SetActive(false);
       
    }
    // Update is called once per frame
    void Update()
    {   
       
    if (Input.GetMouseButtonDown(0)) {  
      Ray ray = camaraPrincipal.ScreenPointToRay(Input.mousePosition);   
      RaycastHit hit;  
      if (Physics.Raycast(ray, out hit)) {  
        //Select stage    
        if (hit.transform.name == cliente.name) {  
          
          camaraSecundaria.gameObject.SetActive(true);
          camaraPrincipal.gameObject.SetActive(false);
          
          
        }  
        else{
          camaraSecundaria.gameObject.SetActive(false);
          camaraPrincipal.gameObject.SetActive(true);
          
        }
          
    }
   
       
          
          
          
       
       
    }
        
      
}
    }

