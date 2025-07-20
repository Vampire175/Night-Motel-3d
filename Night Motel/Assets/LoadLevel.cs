using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]private DialogueManager dialogueManager;
    // Update is called once per frame
    void Update()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        switch(dialogueManager.dialogueEnded)
        {
            case true:
                levelLoader.LevelLoaded = true;
                break;
            case false:
                return;
                
        }
    }
}
