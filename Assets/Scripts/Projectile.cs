using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField]
    private Vector2 m_SpeedRangeX;

    [SerializeField]
    private Vector2 m_SpeedRangeY;

    [SerializeField]
    private SpriteRenderer m_Renderer;

    private Vector3 _speed;
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();

        _speed = new Vector2(Random.Range(m_SpeedRangeX.x, m_SpeedRangeX.y), Random.Range(m_SpeedRangeY.x, m_SpeedRangeY.y));
        if (_speed.x > 0)
        {
            m_Renderer.flipX = true;
        }
        _rigidBody.AddForce(_speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (transform.position.y < -10) Destroy(gameObject);
    }
}
