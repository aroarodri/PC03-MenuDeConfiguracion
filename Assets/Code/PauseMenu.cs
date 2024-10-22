using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    // Varuables
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Slider slider;
    [SerializeField] private Player player;

    private bool isPaused = false;

    // Desactiva el menu de pausa y actualiza el speed del jugador y en el texto.
    void Awake()
    {
        pauseMenu.SetActive(false);
        slider.value = player.MoveSpeed;
        speedText.text = "Player speed: " + slider.value.ToString();

        slider.onValueChanged.AddListener(ChangeSpeed);
    }

    // Actualiza el texto de la velocidad.
    private void ChangeSpeed(float value)
    {
        player.MoveSpeed = value;
        speedText.text = "Player speed: " + value.ToString();
    }

    // Función para pausarlo o resumir el juego.
    public void OnPause(InputAction.CallbackContext callbackContext)
    {
        if (isPaused)
            Resume();
        else
            Pause();
    }

    // Función para pausar el juego y enseñar el menu de pausa.
    private void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
    }

    // Función para despausar el juego y ocultar el menu de pausa.
    public void Resume()
    {
        isPaused = false;

        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
    }

    // Función para salir del juego.
    public void Quit()
    {
        Application.Quit();
    }
}
