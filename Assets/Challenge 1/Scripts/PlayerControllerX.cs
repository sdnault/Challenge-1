using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100f;
    public Vector2 moveInput;

    public InputAction MoveAction;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        moveInput = MoveAction.ReadValue<Vector2>();

        // change the speed depending on moveInput on the x axis
        // Mathf.Max guards against going backwards
        float currentSpeed = Mathf.Max(0f, speed + moveInput.x * 5f);

        // move the plane forward at the calculated speed
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        // tilt the plane up/down based on vertical input
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * moveInput.y);
       
    }
}
