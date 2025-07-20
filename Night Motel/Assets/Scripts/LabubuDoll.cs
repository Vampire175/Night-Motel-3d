using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabubuDoll : MonoBehaviour
{
    public bool Jumpscared = false;
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private GameObject levelloadobj;
    [SerializeField] private GameObject filmGrain;
    private void Update()
    {
       if(Jumpscared)
        {
            filmGrain.SetActive(true);

            Invoke("LevelLoad", 1f); // Load next level after 1 second
        }
    }

    private void LevelLoad()
    {
        
        levelLoader.LoadNextLevel(); 
    }
}
