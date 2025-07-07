using Unity.VisualScripting;
using UnityEngine;

public class DarkShadowJumpScare : MonoBehaviour
{
    [SerializeField]private Computer computer;
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
            }
        }
    }
}
