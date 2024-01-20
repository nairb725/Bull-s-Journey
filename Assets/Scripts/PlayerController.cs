using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SpeedCharacter;

    private Vector2 _movement;
    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.velocity = new Vector2(_movement.x * SpeedCharacter, _movement.y * SpeedCharacter);
    }

    public void OnMove(InputValue value)
    {
        if (GameManager.Instance.IsEndGame())
        {
            _movement = Vector2.zero;
        }
        else
        {
            // Walk Sound
            _movement = value.Get<Vector2>();
        }
    }
}