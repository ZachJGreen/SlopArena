using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float sensitivity = 0.1f;

    private PlayerInput playerInput;
    private InputAction lookAction;

    private float cameraPitch = 0f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();

        lookAction = playerInput.actions["Look"];

        Cursor.lockState = CursorLockMode.Locked; // Lock Cursor to center screen
        Cursor.visible = false; // Hide Cursor
    }

    private void Update()
    {
        Vector2 mouseDelta = lookAction.ReadValue<Vector2>();

        // Records the change in mouse movement and s
        float mouseX = mouseDelta.x * sensitivity;
        float mouseY = mouseDelta.y * sensitivity;

        // Looking up/down
        cameraPitch -= mouseY;

        // Keeps the User from flipping the camera upside down by locking down the Y-axis.
        // -90f means the user can look directly upwards
        // 60f means the user can look 60 degrees downward
        cameraPitch = Mathf.Clamp(
            cameraPitch,
            -90f,
            60f
        );

        // Looking Up/Down. Don't ask me what a quaternion is, I think it's some physics thing
        // Keeps from there being weird behavior when looking up or down
        playerCamera.localRotation =
            Quaternion.Euler(cameraPitch, 0f, 0f);

        // Looking left/right
        transform.Rotate(Vector3.up * mouseX);
    }
}