using UnityEngine;

public enum SoundType
{
    TelephoneRingSound,
    PickupandHangupSound,
    Click
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(SoundType soundType,float volume)
    {
        instance.audioSource.PlayOneShot(instance.clips[(int)soundType], volume);
    }
}
