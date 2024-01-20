using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectile : MonoBehaviour
{
    [SerializeField] Projectile m_Proj;
    [SerializeField] float m_SpawnRate;
    [SerializeField] float m_Width;

    private float _lastSpawn;

    private void Start()
    {
        //Init
        _lastSpawn = Time.time;
    }
    void Update()
    {
        if (Time.time - _lastSpawn >= 1f / m_SpawnRate) Spawn();
    }

    void Spawn()
    {
        Projectile instance = Instantiate(m_Proj, transform);
        float x = Random.Range(transform.localPosition.x - (m_Width * 0.5f), transform.localPosition.x + (m_Width * 0.5f));
        instance.transform.localPosition = new Vector2(x, 0);
        _lastSpawn = Time.time;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawLine(transform.position - new Vector3(m_Width * 0.5f, 0, 0), transform.position + new Vector3(m_Width * 0.5f, 0, 0));
    }
}
