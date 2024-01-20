using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandpaWalk : MonoBehaviour
{

    [SerializeField]
    private float SpeedCharacter;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Vector3.down * SpeedCharacter * Time.smoothDeltaTime);
        Invoke("Grandpa", 2.0f);
    }

    // Update is called once per frame
    void Grandpa()
    {
        transform.Translate(Vector3.right * SpeedCharacter * Time.smoothDeltaTime);
    }
}
