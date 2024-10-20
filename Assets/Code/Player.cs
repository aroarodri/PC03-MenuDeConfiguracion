using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float upForce = 250f;
    [SerializeField] private float moveSpeed = 5f;

    private Rigidbody rb;
    private Vector2 move;

    private CutomActionsController cutomActionsController;
    private PauseMenu pauseMenu;

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
        cutomActionsController.Player.Jump.performed += OnJump;
        cutomActionsController.Player.Move.performed += OnMove;
        cutomActionsController.Player.Move.canceled += OnMove;

        cutomActionsController.PauseMenu.Enable();
        cutomActionsController.PauseMenu.Pause.performed += pauseMenu.OnPause;
    }


    public void OnJump(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            rb.AddForce(Vector3.up * upForce);
        }
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.performed)
        {
            move = callbackContext.ReadValue<Vector2>();
        }
    }
}
