using UnityEngine;

public class Hover : MonoBehaviour
{
    [SerializeField] private GameObject hovercircle;
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hover;
        if (Physics.Raycast(ray, out hover,150f))
        {
            Interatable interatable = hover.collider.GetComponent<Interatable>();
            if (interatable != null)
            {
                hovercircle.SetActive(true);
            }
            else
            {
                hovercircle.SetActive(false);
            }
        }
    }
}
