using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesCollider : MonoBehaviour
{
    [SerializeField] private ProjectilesData data;
    void GetHit()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Enemy"))
            GetHit();

        //adicionar do player tb
    }
}
