using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheKiller : MonoBehaviour
{
    [SerializeField]private PlayerInteractWithKnife playerInteractWithKnife;
    [SerializeField]private GameObject killer; // Reference to the killer GameObject
    [SerializeField] private GameObject BlackScreen;
    

    private void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            Kill();
        }
    }

    private void Kill()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (playerInteractWithKnife.hasKnifepickedUp && hit.collider.CompareTag("Killer"))
            {
                Debug.Log("Killer Killed");
                // Add logic to destroy or disable the killer
                killer.SetActive(false); // Assuming this script is attached to the killer GameObject
                BlackScreen.SetActive(true); // Activate the black screen
                SoundManager.PlaySound(SoundType.ScreamingSound, 1f);
                SoundManager.StopLoopSound();
                Cursor.lockState=CursorLockMode.None; // Unlock the cursor
            }
        }
    }
}
