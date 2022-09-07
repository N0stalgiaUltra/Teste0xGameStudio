using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    //inimigo anda em dire��o ao player e para para atirar no player, apos atirar, anda dnv
    //bullet spawn deve estar olhando para o player
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float fireRate;
    float nextFire;

    void Start()
    {
        nextFire = fireRate;
        bulletSpawn.rotation = Quaternion.Euler(0, 180, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextFire)
        {
            Shoot();
            nextFire = Time.time + fireRate;
        }
    }
    
    private void Shoot()
    {
        ProjectilesPool.instance.BulletSpawn(bulletSpawn, false);
    }
}