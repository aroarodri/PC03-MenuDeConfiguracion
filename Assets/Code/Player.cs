using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Variables
    [SerializeField] private PauseMenu pauseMenu;

    private float _moveSpeed = 5f;
    private float upForce = 250f;
    private Rigidbody rb;
    private Vector2 move;
    private CutomActionsController cutomActionsController;

    // Getter y setter
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    // Inicializa el CustomActionsController y el RigidBody.
    void Awake()
    {
        cutomActionsController = new CutomActionsController();

        rb = GetComponent<Rigidbody>();
    }

    // Actualiza la posición del jugador.
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y) * MoveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // Activa los ActionMaps y se suscriben a ellos.
    private void OnEnable()
    {
        cutomActionsController.Player.Enable();
        cutomActionsController.PauseMenu.Enable();

        cutomActionsController.Player.Move.performed += OnMove;
        cutomActionsController.Player.Move.canceled += OnMove;
        cutomActionsController.Player.Jump.performed += OnJump;
        cutomActionsController.PauseMenu.Pause.performed += pauseMenu.OnPause;
    }

    // Desactiva los ActionMaps y se desuscriben a ellos.
    private void OnDisable()
    {
        cutomActionsController.Player.Disable();
        cutomActionsController.PauseMenu.Disable();

        cutomActionsController.Player.Move.performed -= OnMove;
        cutomActionsController.Player.Move.canceled -= OnMove;
        cutomActionsController.Player.Jump.performed -= OnJump;
        cutomActionsController.PauseMenu.Pause.performed -= pauseMenu.OnPause;
    }

    // Función para hacer que salte el jugador.
    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        rb.AddForce(Vector3.up * upForce);
    }

    // Función para mover al jugador.
    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }
}
