using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float jumpForce = 250f;
    [SerializeField] float movementForce = 10f;

    Vector2 input;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 move = transform.TransformDirection(new Vector3(input.x, 0f, input.y)) * movementForce;
        rb.AddForce(move);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        // Debug.Log("Move input: " + input);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
            rb.AddForce(Vector3.up * jumpForce);
    }
}
