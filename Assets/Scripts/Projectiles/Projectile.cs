using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;

    public Transform projectileSpawn;
    void Start()
    {
        transform.localPosition = projectileSpawn.position;
        transform.rotation = projectileSpawn.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.activeSelf)
            rb.AddForce(transform.right * speed, ForceMode2D.Impulse);
    }
}
