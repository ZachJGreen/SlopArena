using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 12f;
    [SerializeField] private float gravity = 9.8f;
    [SerializeField] private InputActionReference moveAction;
    private CharacterController characterControl;
    private Vector2 playerInput;
    private Vector3 moveDirection;
    private float xMovement;
    private float zMovement;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterControl = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        playerInput = moveAction.action.ReadValue<Vector2>();
        xMovement = playerInput.x;
        zMovement = playerInput.y;
        moveDirection = (xMovement * transform.right) + (zMovement * transform.forward);
        characterControl.Move(moveDirection * speed * Time.deltaTime);
    }
}
