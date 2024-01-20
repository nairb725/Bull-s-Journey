using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float SpeedCharacter;

    [SerializeField]
    private Animator m_Animator;

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
            m_Animator.SetFloat("x", _movement.x);
            m_Animator.SetFloat("y", _movement.y);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            Destroy(collider.gameObject);
        }
    }
}