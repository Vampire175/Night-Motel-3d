using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogue : MonoBehaviour
{
    [SerializeField] private DialogueTrigger dialogue;
    [SerializeField]private GameObject dialogueCanvas;
    [SerializeField]private GameObject player;
    
    // Update is called once per frame
    void Start()
    {
        Invoke("DialogueStart", 11f);// Start the dialogue after 11 seconds
    }

    void DialogueStart()
    {
        dialogue.TriggerDialogue();
        dialogueCanvas.SetActive(true); // Show the dialogue canvas
        Debug.Log("Dialogue started");
        
    }

   
   
}
