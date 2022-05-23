using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtenderController : MonoBehaviour
{
    public Transform spawnKebab;
    // Update is called once per frame
    private void Start()
    {
        spawnKebab = GameObject.FindGameObjectWithTag("SpawnKebab").transform;
    }
    void Update()
    {
        ComprobarMano();
    }
    public void ComprobarMano()
    {
        if (spawnKebab.childCount > 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = false;
        }
        else if (spawnKebab.childCount == 0)
        {
            this.gameObject.GetComponent<DesplazamientoPunto>().enabled = true;
        }
    }
}
