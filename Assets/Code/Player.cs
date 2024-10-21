using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PauseMenu pauseMenu;

    private float upForce = 250f;
    private Rigidbody rb;
    private Vector2 move;

    private CutomActionsController cutomActionsController;

    // Start is called before the first frame update
    void Awake()
    {
        cutomActionsController = new CutomActionsController();

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y) * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void OnEnable()
    {
        cutomActionsController.Player.Enable();
        cutomActionsController.Player.Move.performed += OnMove;
        cutomActionsController.Player.Move.canceled += OnMove;
        cutomActionsController.Player.Jump.performed += OnJump;

        cutomActionsController.PauseMenu.Enable();
        cutomActionsController.PauseMenu.Pause.performed += pauseMenu.OnPause;
    }

    private void OnDisable()
    {
        cutomActionsController.Player.Disable();

        cutomActionsController.Player.Move.performed -= OnMove;
        cutomActionsController.Player.Move.canceled -= OnMove;
        cutomActionsController.Player.Jump.performed -= OnJump;

        cutomActionsController.PauseMenu.Disable();

        cutomActionsController.PauseMenu.Pause.performed -= pauseMenu.OnPause;
    }


    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        rb.AddForce(Vector3.up * upForce);
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        move = callbackContext.ReadValue<Vector2>();
    }
}
