using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDialougue : MonoBehaviour
{
    [SerializeField]private DialogueManager dialogueManager;
    [SerializeField]private GameObject Infocanvas;

    // Update is called once per frame
    void Update()
    {
        if(dialogueManager.dialogueEnded)
        {
           Infocanvas.SetActive(true); // Show the info canvas when dialogue ends\
          
        }

        Invoke("DestroyCanavs", 5f); // Call DestroyCanavs after 5 secondsS
    }

    void DestroyCanavs()
    {
        Infocanvas.SetActive(false); // Hide the info canvas when dialogue ends
    }
   
}
