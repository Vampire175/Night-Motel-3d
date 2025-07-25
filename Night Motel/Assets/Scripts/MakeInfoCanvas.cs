using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeInfoCanvas : MonoBehaviour
{
    [SerializeField]private GameObject infoCanvas;
    [SerializeField]private LevelLoader levelLoader;

    private void Update()
    {
        if(levelLoader.LevelLoaded)
        {
            infoCanvas.SetActive(true);
            levelLoader.LevelLoaded = false; // Reset the flag to prevent reactivation
        }
    }
}
