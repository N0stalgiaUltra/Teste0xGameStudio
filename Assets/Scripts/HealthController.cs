using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public enum CharType
    {
        Player,
        Enemy
    }

    public CharType charType;
    [SerializeField] private CharData data;
    [SerializeField] private int health;

    private void Start()
    {
        health = data.MaxHealth;
    }

    private void Update()
    {
        if (health <= data.MinHealth)
            Die();
    }
    public void Damage(int damage)
    {
        if (health > data.MinHealth)
            health -= damage;
    }
    
    public void Die()
    {
        if(this.charType == CharType.Enemy)
        {
            EnemyPool.instance.DeactivateEnemy(this.gameObject);
        }
        this.gameObject.SetActive(false);

    }
}
