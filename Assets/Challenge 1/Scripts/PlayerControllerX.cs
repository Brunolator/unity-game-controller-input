using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float speedModifier;
    public float rotationSpeed;
    public float verticalInput;
    //public InputAction rotateAction;

    // Start is called before the first frame update
    void Start()
    {
        //rotateAction.Enable();
        speedModifier = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Gamepad.current == null)
        {
            // No controller
            verticalInput = Input.GetAxis("Vertical");
        }
        else
        {
            // Yes controller
            Vector2 analogInput = Gamepad.current.leftStick.ReadValue();
            verticalInput = analogInput.y;

            // Extra credit
            // Translate [-1, 1] to [0, 2]
            // Yes, planes can hover now
            speedModifier = analogInput.x + 1;
        }

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * speed * speedModifier);

        // tilt the plane up/down based on vertical input
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * -verticalInput);
    }
}
