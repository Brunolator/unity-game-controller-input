using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Controlling how fast you move and turn
    public float speed = 5.0f;
    public float turnSpeed;

    // Input gathering
    public InputAction moveAction;

    // X is left and right, and y is forward and back
    private Vector2 moveInput;

    void Start()
    {
        // Start reading input
        moveAction.Enable();
    }

    void Update()
    {
        // Update input
        moveInput = moveAction.ReadValue<Vector2>();

        // Move the vehicle forward and turn it based on input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
    }
}
