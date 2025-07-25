using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakePaperVisble : MonoBehaviour
{
    [SerializeField]private GameObject paper;
    void Update()
    {
        paper.SetActive(true);
        SoundManager.PlaySound(SoundType.PaperFloating, 1f);

        
        
    }
}
