using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        anim.SetTrigger("Moving");
    }

    // Update is called once per frame
    void Update()
    {

        if(playerTransform != null)
        {
            if (playerTransform.transform.position.x > this.transform.position.x)
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
            else if (playerTransform.transform.position.x < this.transform.position.x)
                this.transform.rotation = Quaternion.Euler(Vector3.zero);

            this.transform.position = Vector2.MoveTowards(this.transform.position, playerTransform.position, speed * Time.deltaTime);
        }

        //colocar isso no pool
        if (!this.gameObject.activeSelf)
            anim.SetTrigger("Idle");
    }
}
