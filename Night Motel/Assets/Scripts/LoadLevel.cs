using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField]private DialogueManager dialogueManager;
    // Update is called once per frame
    void Update()
    {
        Invoke("LoadNextLevel", 20f);
    }

    void LoadNextLevel()
    {
        LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.LoadNextLevel();
    }
}
