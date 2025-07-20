using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    #region Variables
    [SerializeField]private DialogueTrigger dialogueTrigger;
    [SerializeField]private GameObject dialogueCanvas;
    [SerializeField] private TelephoneRing Telephoneobj;
    [SerializeField] private TextMeshProUGUI downtext;
    [SerializeField] private GameObject downtextobj;
    #endregion
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
                    downtextobj.SetActive(true);
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

            #region Bed Interaction
            if(hit.collider.tag == "Bed")
            {
                Interatable interatable = hit.collider.GetComponent<Interatable>();

                if (interatable.isInteractable)
                {
                    Debug.Log("You are interact with the bed right now.");
                    Bed(hit);
                }

                else
                {
                    Debug.Log("Tu mujhe pagal samajhta hai kya:)");
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

    #region Bed Interaction Method
    private void Bed(RaycastHit bedcollide)
    {
        Bed bed = bedcollide.collider.GetComponent<Bed>();
        if (bed != null)
        {
            bed.Interact();
        }
        else
        {
            Debug.LogError("No Bed component found on this object: " + bedcollide.collider.name);
        }
    }
    #endregion

    private void ClearText()
    {
        downtext.text = "";
        downtextobj.SetActive(false);
    }

    #endregion
}


