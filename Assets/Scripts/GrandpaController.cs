using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaController : MonoBehaviour
{

    [SerializeField] float SpeedCharacter;
    [SerializeField] int LifePoint;
    [SerializeField] Animator m_Animator;
    private bool _isGoingRight = false;

    public void StartGame()
    {
        Invoke(nameof(GoingRight), 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGoingRight)
        {
            transform.Translate(SpeedCharacter * Time.smoothDeltaTime * Vector3.right);
        } else 
        {       
            transform.Translate(SpeedCharacter * Time.smoothDeltaTime * Vector3.down);
        }
    }

    private void GoingRight()
    {
        _isGoingRight = true;
        m_Animator.SetBool("IsTurningRight", true);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("WinCon"))
        {
            GameManager.Instance.ChangeState(GameState.Win);
        }
    }
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Projectile"))
        {
            GameManager.Instance.ChangeState(GameState.Lose);
        }
    }
}
