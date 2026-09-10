using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private float jumpPower = 5f;
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAction;
    private CharacterController characterControl;
    private Vector2 playerInput;
    private Vector3 moveDirection;
    private float xMovement;
    private float zMovement;
    private float verticalVelocity;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterControl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (characterControl.isGrounded && verticalVelocity < 0)
        {
            verticalVelocity = -2f;
        }

        if (characterControl.isGrounded && jumpAction.action.WasPressedThisFrame())
        {
            verticalVelocity = jumpPower;
        }
        verticalVelocity += gravity * Time.deltaTime;

        playerInput = moveAction.action.ReadValue<Vector2>();
        xMovement = playerInput.x * speed;
        zMovement = playerInput.y * speed;
        moveDirection = (xMovement * transform.right) + (zMovement * transform.forward);
        moveDirection.y = (verticalVelocity);

        characterControl.Move(moveDirection * Time.deltaTime);
        
    }
}
