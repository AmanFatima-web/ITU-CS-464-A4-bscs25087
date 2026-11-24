
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused = false;

    public GameObject pausePanel;
    public GameObject resumeButton;

    void Start()
    {
        Time.timeScale = 1f;
        IsPaused = false;
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

        if (EventSystem.current != null)
            EventSystem.current.SetSelectedGameObject(resumeButton);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Restart()
    {
        Resume();
        LevelLoader.Instance.Reload();
    }

    public void QuitToMenu()
    {
        Resume();
        LevelLoader.Instance.LoadMenu();
    }
}
