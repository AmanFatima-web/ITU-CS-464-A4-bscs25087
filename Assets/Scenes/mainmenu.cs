
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject mainMenuPanel;
    public GameObject levelSelectionPanel;
    public GameObject settingsPanel;

    [Header("Audio")]
    public AudioMixer audioMixer;
    public AudioSource musicSource;
    public AudioSource sfxSource;

    private bool musicOn = true;
    private bool sfxOn = true;

    private float musicVolume = 1f;
    private float sfxVolume = 1f;

    private void Start()
    {
        ApplyMusicVolume();
        ApplySFXVolume();
    }

    // PANELS

    public void ShowLevels()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false);
        levelSelectionPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        levelSelectionPanel.SetActive(false);
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // LEVELS

    public void PlayLevel(int levelNumber)
    {
        string[] levelNames =
        {
            "level01",
            "level02",
            "level03",
            "level04",
            "level 5"
        };

        if (levelNumber < 1 || levelNumber > 5)
            return;

        SceneManager.LoadScene(levelNames[levelNumber - 1]);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level01");
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // MUSIC SLIDER

    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        ApplyMusicVolume();
    }

    private void ApplyMusicVolume()
    {
        if (audioMixer == null) return;

        float db = musicOn
            ? Mathf.Lerp(-40f, 0f, musicVolume)
            : -80f;

        audioMixer.SetFloat("MyExposedParam", db);
    }

    // MUSIC ON/OFF

    public void ToggleMusic()
    {
        musicOn = !musicOn;
        ApplyMusicVolume();
    }

    // SFX SLIDER

    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        ApplySFXVolume();
    }

    private void ApplySFXVolume()
    {
        if (audioMixer == null) return;

        float db = sfxOn
            ? Mathf.Lerp(-40f, 0f, sfxVolume)
            : -80f;

        audioMixer.SetFloat("MyExposedParam 1", db);
    }

    // SFX ON/OFF

    public void ToggleSFX()
    {
        sfxOn = !sfxOn;
        ApplySFXVolume();
    }

    // BUTTON CLICK SOUND

    public void PlaySFX()
    {
        if (sfxSource != null && sfxOn && sfxSource.clip != null)
        {
            sfxSource.PlayOneShot(sfxSource.clip);
        }
    }

    // TEST MUSIC

    public void TestMusic()
    {
        if (musicSource != null)
        {
            musicSource.Play();
        }
    }
}
