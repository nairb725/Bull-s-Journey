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
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * SpeedCharacter * Time.smoothDeltaTime);

    }
}
