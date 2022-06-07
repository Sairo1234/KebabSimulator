using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIngrediente : MonoBehaviour
{
    [Header("Desplazamiento")]
    public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    private void OnMouseDown()
    {
        gameManager.GetComponent<SetTutorial>().PonerTutorialIngredientes();
    }
}
