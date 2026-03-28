using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnMovement(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * StatsManager.Instance.moveSpeed * Time.fixedDeltaTime);
    }

}
