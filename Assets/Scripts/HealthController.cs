using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private CharData data;
    [SerializeField] private int health;

    private void Start()
    {
        health = data.MaxHealth;
    }

    private void Update()
    {
        if (health <= data.MinHealth)
            this.gameObject.SetActive(false);
    }
    public void Damage(int damage)
    {
        if (health > data.MinHealth)
            health -= damage;
    }
}
