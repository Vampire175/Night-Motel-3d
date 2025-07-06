using Unity.Mathematics;
using UnityEngine;

public class TelephoneRing : MonoBehaviour
{
    private bool wasRinging;
    public bool isRinging;

    private void Start()
    {
        wasRinging = isRinging;

        if (isRinging)
        {
            InvokeRepeating("TelephoneRingSound", 1f, 2f);
        }
        else
        {
            SoundManager.PlaySound(SoundType.PickupandHangupSound, 1f);
        }
    }

    private void Update()
    {
        if (wasRinging && !isRinging)
        {
            // Just switched from ringing to NOT ringing:
            SoundManager.PlaySound(SoundType.PickupandHangupSound, 1f);
            CancelInvoke("TelephoneRingSound");
        }

        if (!wasRinging && isRinging)
        {
            // Just switched from NOT ringing to ringing:
            InvokeRepeating("TelephoneRingSound", 1f, 2f);
        }

        // Update last state
        wasRinging = isRinging;

        if (!isRinging)
        {
            Interatable interactable=gameObject.GetComponent<Interatable>();
            interactable.isInteractable = false;
        }
    }

    private void TelephoneRingSound()
    {
        SoundManager.PlaySound(SoundType.TelephoneRingSound,1f);
    }

    
}
