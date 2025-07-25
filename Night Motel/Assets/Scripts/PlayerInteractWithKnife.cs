using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractWithKnife : MonoBehaviour
{
    public bool hasKnifepickedUp = false;
    [SerializeField] private PaperHover phover;    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
        }
    }

    private void Interact()
    {
        Debug.Log("Mouse Clicked");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Knife")
            {
                if (phover.hasKillerSpawned)
                {
                    hasKnifepickedUp = true;
                    Destroy(hit.collider.gameObject); // Destroy the knife GameObject
                }
                else
                {
                    Debug.Log("Mere mathe pe C likha hai, Killer ko pehle spawn kar");
                }
            }
            
        }
    }
}
