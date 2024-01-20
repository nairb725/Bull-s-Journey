using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingCamera : MonoBehaviour
{
    private bool _isTracking = false;
    [SerializeField] GameObject m_TargetTracking;

    public void Track() => _isTracking = true;

    public void Untrack() => _isTracking = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isTracking)
            transform.position = new Vector3(m_TargetTracking.transform.position.x, m_TargetTracking.transform.position.y, transform.position.z);
        
    }
}
