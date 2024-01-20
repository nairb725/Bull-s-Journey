using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaController : MonoBehaviour
{

    [SerializeField]
    private float SpeedCharacter;

    [SerializeField]
    private int LifePoint;

    [SerializeField]
    private bool _isGoingRight = false;

    [SerializeField]
    private bool _isWining = false;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("goingRight", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGoingRight == true)
        {
            transform.Translate(Vector3.right * SpeedCharacter * Time.smoothDeltaTime);
            transform.Translate(Vector3.up * SpeedCharacter * Time.smoothDeltaTime);

        }
        {       
            transform.Translate(Vector3.down * SpeedCharacter * Time.smoothDeltaTime);
        }
    }

    void goingRight()
    {
        _isGoingRight = true;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "WinCon")
        {
            GameManager.Instance.ChangeState(GameState.Win);
        }
    }
}
