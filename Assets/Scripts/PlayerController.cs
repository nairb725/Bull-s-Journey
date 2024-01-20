using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SpeedCharacter;

    private Rigidbody2D rb;

    [SerializeField]
    private bool _isFacingLeft;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Input handling
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Movement calculation
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize(); // Ensure consistent speed in all directions

        // Applying movement
        rb.velocity = movement * SpeedCharacter;
    }
}