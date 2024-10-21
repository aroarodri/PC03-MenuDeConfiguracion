using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider slider;
    [SerializeField] private Player player;

    private bool isPaused = false;


    // Start is called before the first frame update
    void Awake()
    {
        pauseMenu.SetActive(false);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    private void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
    }

    private void Resume()
    {
        isPaused = false;

        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
    }
}
