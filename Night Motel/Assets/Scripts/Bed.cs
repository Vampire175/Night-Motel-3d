using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
   
    [SerializeField] private Interatable interatable;
    [SerializeField] private DialogueManager dialogueManager;

    public void Interact()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        Debug.Log("Loading Level");
        if (levelLoader == null)
        {
            Debug.LogError("LevelLoader not found in the scene.");
            return;
        }

        else
        {
            levelLoader.LoadNextLevel();
        }
    }

    private void Update()
    {
        DetermineInteraction();
    }

    private void DetermineInteraction()
    {
        if (!dialogueManager.dialogueEnded)
        {
            interatable.isInteractable = false;
        }

        else
        {
            interatable.isInteractable = true;
        }
    }
}
