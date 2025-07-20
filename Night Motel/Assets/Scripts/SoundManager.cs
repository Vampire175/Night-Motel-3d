using UnityEngine;

public enum SoundType
{
    TelephoneRingSound,
    PickupandHangupSound,
    Click,
    JumpScare,
    Walking,
    HorrorBgWhileKilling
}

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private AudioSource oneShotAudioSource;
    private AudioSource loopAudioSource;

    [SerializeField] private AudioClip[] clips;

    void Awake()
    {
        // Singleton pattern: only one SoundManager should exist
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Optional: persist between scenes
    }

    private void Start()
    {
        // One AudioSource for PlayOneShot (short sounds)
        oneShotAudioSource = GetComponent<AudioSource>();

        // Separate AudioSource for looping sounds
        loopAudioSource = gameObject.AddComponent<AudioSource>();
        loopAudioSource.loop = true;
    }

    /// <summary>
    /// Play a one-shot sound like click, pickup, jumpscare etc.
    /// </summary>
    public static void PlaySound(SoundType soundType, float volume = 1f)
    {
        if (instance == null) return;

        AudioClip clip = instance.clips[(int)soundType];
        if (clip != null)
        {
            instance.oneShotAudioSource.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning($"SoundManager: Clip for {soundType} is missing!");
        }
    }

    /// <summary>
    /// Play a looping sound (like footsteps) until stopped.
    /// </summary>
    public static void PlayLoopSound(SoundType soundType, float volume = 1f)
    {
        if (instance == null) return;

        AudioClip clip = instance.clips[(int)soundType];
        if (clip == null)
        {
            Debug.LogWarning($"SoundManager: Clip for {soundType} is missing!");
            return;
        }

        if (instance.loopAudioSource.isPlaying && instance.loopAudioSource.clip == clip)
        {
            // Already playing this clip, do nothing
            return;
        }

        instance.loopAudioSource.clip = clip;
        instance.loopAudioSource.volume = volume;
        instance.loopAudioSource.Play();
    }

    /// <summary>
    /// Stop the current looping sound.
    /// </summary>
    public static void StopLoopSound()
    {
        if (instance == null) return;

        if (instance.loopAudioSource.isPlaying)
        {
            instance.loopAudioSource.Stop();
            instance.loopAudioSource.clip = null;
        }
    }

    /// <summary>
    /// Check if loop sound is playing.
    /// </summary>
    public static bool IsLoopSoundPlaying()
    {
        return instance != null && instance.loopAudioSource.isPlaying;
    }
}
