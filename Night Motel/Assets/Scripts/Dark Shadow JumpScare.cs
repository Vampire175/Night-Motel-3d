using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class DarkShadowJumpScare : MonoBehaviour
{
    [SerializeField]private Computer computer;
    [SerializeField] private GameObject directionallight;
    [SerializeField] private GameObject filmGrain;
    [SerializeField] private FirstPersonController fps;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "DarkShadow"&&computer.hasescaped)
            {
                Debug.Log("Dark Shadow Hit");
                SoundManager.PlaySound(SoundType.JumpScare, 1f);
                filmGrain.SetActive(true);
                fps.MoveSpeed = 0f; // Stop player movement
                fps.RotationSpeed = 0f; // Stop player rotation
            }

            
        }
        if (computer.hasescaped)
        {
            directionallight.SetActive(false);
        }
    }
}
