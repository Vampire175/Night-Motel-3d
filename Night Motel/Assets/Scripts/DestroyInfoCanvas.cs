using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInfoCanvas : MonoBehaviour
{
    [SerializeField] private GameObject InfoCanvas;
    [SerializeField] private GameObject levelLoader;
    // Update is called once per frame
    void Update()
    {

        Destroy(InfoCanvas, 2f); // Destroys the info canvas if the level loader object is destroyed
        Destroy(levelLoader, 5f); // Destroys the level loader object after 5 seconds
    }
}
