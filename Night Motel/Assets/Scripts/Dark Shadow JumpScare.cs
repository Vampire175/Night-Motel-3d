using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;

public class DarkShadowJumpScare : MonoBehaviour
{
    [SerializeField]private Computer computer;
    [SerializeField] private GameObject directionallight;
    [SerializeField] private GameObject filmGrain;
    [SerializeField] private FirstPersonController fps;
    [SerializeField]private LevelLoader levelLoader;
    [SerializeField] private GameObject levelloadobj;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit,150f))
        {
           
            if(hit.collider.tag == "DarkShadow"&&computer.hasescaped)
            {
                Debug.Log("Dark Shadow Hit");
                SoundManager.PlaySound(SoundType.JumpScare, 1f);
                filmGrain.SetActive(true);
                fps.MoveSpeed = 0f; // Stop player movement
                fps.RotationSpeed = 0f; // Stop player rotation

                Invoke("LevelLoad", 1f); // Load next level after 1 second
            }

            
        }
        if (computer.hasescaped)
        {
            directionallight.SetActive(false);
            levelloadobj.SetActive(true);
        }
    }
    public void LevelLoad()
    {
        levelLoader.LoadNextLevel();
  
    }
}
