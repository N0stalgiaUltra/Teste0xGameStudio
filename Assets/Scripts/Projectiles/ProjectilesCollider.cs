using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesCollider : MonoBehaviour
{
    [SerializeField] private ProjectilesData data;

    void GetHit(HealthController objHealth)
    {
        objHealth.Damage(data.damage);
        ProjectilesPool.instance.ReplenishQueue(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Player"))
        {
            HealthController aux = collision.gameObject.GetComponent<HealthController>();
            GetHit(aux);
        }
    }
}
