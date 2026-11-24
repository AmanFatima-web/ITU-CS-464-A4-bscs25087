
using UnityEngine;
using UnityEngine.Audio;

public class SfxPlayer : MonoBehaviour
{
    public static SfxPlayer Instance;

    [Header("Audio Sources")]
    public AudioSource[] audioSources;
    public AudioMixerGroup sfxGroup;

    [Header("Sound Effects")]
    public AudioClip clickSound;
    public AudioClip pickupSound;
    public AudioClip damageSound;
    public AudioClip guardSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioClip heartSound;

    private int sourceIndex = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        foreach (AudioSource source in audioSources)
        {
            if (source != null)
            {
                source.outputAudioMixerGroup = sfxGroup;
                source.playOnAwake = false;
                source.loop = false;
            }
        }
    }

    public void Play(AudioClip clip)
    {
        if (clip == null || audioSources == null ||
            audioSources.Length == 0)
            return;

        AudioSource source = audioSources[sourceIndex];

        if (source == null)
            return;

        sourceIndex = (sourceIndex + 1) % audioSources.Length;

        float randomSemitones = Random.Range(-2f, 2f);
        source.pitch = Mathf.Pow(2f, randomSemitones / 12f);

        source.PlayOneShot(clip);
    }

    public void PlayClickSound()
    {
        Play(clickSound);
    }

    public void PlayPickupSound()
    {
        Play(pickupSound);
    }

    public void PlayDamageSound()
    {
        Play(damageSound);
    }

    public AudioClip GetGuardSound()
    {
        return guardSound;
    }

    public void PlayWinSound()
    {
        Play(winSound);
    }

    public void PlayLoseSound()
    {
        Play(loseSound);
    }

    public void PlayHeartSound()
    {
        Play(heartSound);
    }
}
