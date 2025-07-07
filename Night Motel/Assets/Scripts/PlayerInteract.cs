using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField]private DialogueTrigger dialogueTrigger;
    [SerializeField]private GameObject dialogueCanvas;
    [SerializeField] private TelephoneRing Telephoneobj;
    [SerializeField] private TextMeshProUGUI downtext;
    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            Interact();
        }

    }

    #region Methods

    #region MainInteractionMethod

    public void Interact()
    {
        Debug.Log("Mouse Clicked");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.collider.name);
            #region Telephone Interaction
            if (hit.collider.tag == "Telephone")
            {
                Interatable interatable = hit.collider.GetComponent<Interatable>();

                
                if (interatable.isInteractable)
                {
                    Telephone(hit);
                }
            }
            #endregion

            #region Computer Interaction
            if (hit.collider.tag == "Computer")
            {
                Interatable interatable = hit.collider.GetComponent<Interatable>();

                if (Telephoneobj.isRinging)
                {

                    downtext.text = "The telephone is ringing, you cannot interact with the computer right now.";
                    Invoke("ClearText", 2f);
                    return; // Prevent interaction if telephone is ringing
                }

                else
                {
                    if (interatable.isInteractable)
                    {
                        Computer(hit);
                    }
                }
            }
            #endregion
        }
    }



    #endregion


    #region Telephone Interaction Method

    private void Telephone(RaycastHit telephonecollide)
    {
        telephonecollide.collider.GetComponent<TelephoneRing>().isRinging = false;
        dialogueTrigger.TriggerDialogue();
        dialogueCanvas.SetActive(true);
        Debug.Log("Phone Picked up");
    }

    #endregion

    #region Computer Interaction Method
    private void Computer(RaycastHit computercollide)
    {
        Computer computer = computercollide.collider.GetComponent<Computer>();
        computer.ComputerStart();
    }
    #endregion

    private void ClearText()
    {
        downtext.text = "";
    }

    #endregion
}


