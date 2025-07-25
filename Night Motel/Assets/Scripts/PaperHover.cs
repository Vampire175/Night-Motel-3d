using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperHover : MonoBehaviour
{
    [SerializeField] private GameObject Killer;
    public bool hasKillerSpawned = false;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hover;
        if (Physics.Raycast(ray, out hover, 30f))
        {
            
            if (hover.collider.tag=="Paper")
            {
               SpawnKiller();
            }
        }
    }

    void SpawnKiller()
    {
     
        Debug.Log("Hovering over paper");
        Killer.SetActive(true);
        hasKillerSpawned = true;
    }
}
