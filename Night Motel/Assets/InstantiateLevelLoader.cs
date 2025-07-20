using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevelLoader : MonoBehaviour
{


    [SerializeField]private GameObject levelLoaderPrefab;   

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Instantiate", 1f);
    }

    private void Instantiate()
    {
        Instantiate(levelLoaderPrefab, Vector3.zero, Quaternion.identity);
    }
}
