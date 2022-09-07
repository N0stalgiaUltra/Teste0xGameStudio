using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float fireRate;
    float nextFire;

    GameObject player;
    Rigidbody2D rb;
    void Start()
    {
        nextFire = fireRate;
        bulletSpawn.rotation = Quaternion.Euler(0, 180, 0);
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      

        if (Time.time > nextFire)
        {
            Shoot();
            RotateShoot();
            nextFire = Time.time + fireRate;
        }
        
    }

    private void RotateShoot()
    {
        Vector3 direction = player.transform.position - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bulletSpawn.rotation = Quaternion.Euler(0,0, angle);
    }

    private void Shoot()
    {
        ProjectilesPool.instance.BulletSpawn(bulletSpawn, false);
    }
}
