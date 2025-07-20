using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovingSound : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        bool isWalkingKeyPressed = Input.GetKey(KeyCode.W)
                            || Input.GetKey(KeyCode.A)
                            || Input.GetKey(KeyCode.S)
                            || Input.GetKey(KeyCode.D);

        if (isWalkingKeyPressed)
        {
            SoundManager.PlayLoopSound(SoundType.Walking, 1f);
        }
        else
        {
            SoundManager.StopLoopSound();
        }

    }
}
