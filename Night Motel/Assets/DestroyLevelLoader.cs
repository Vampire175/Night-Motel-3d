using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelLoader : MonoBehaviour
{
    [SerializeField]private GameObject levelloadobj;
    // Update is called once per frame
    void Update()
    {
        Destroy(levelloadobj, 2f); // Destroys the level loader object after 2 seconds
    }
}
