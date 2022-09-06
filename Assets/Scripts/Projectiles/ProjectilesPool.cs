using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesPool : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;

    [SerializeField] private Queue<Projectile> projectileQueue = new Queue<Projectile>(50);
    int capacity = 50;

    public static ProjectilesPool instance;

    private const string PlayerLayer = "PlayerBullet";
    private const string EnemyLayer = "EnemyBullet";
    void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
            instance = this;

        for (int i = 0; i < capacity; i++)
        {
            Projectile aux = Instantiate(projectilePrefab, this.transform);
            aux.gameObject.SetActive(false);
            projectileQueue.Enqueue(aux);

        }
    }
    public Projectile BulletSpawn(Transform bulletSpawn, bool isPlayer)
    {
        if (projectileQueue.Count != 0)
        {
            if (isPlayer)
            {
                Projectile aux = projectileQueue.Dequeue();
                aux.gameObject.GetComponent<Projectile>().projectileSpawn = bulletSpawn;
                aux.gameObject.layer = LayerMask.NameToLayer(PlayerLayer);

                aux.gameObject.SetActive(true);
                return aux;
            }
            else
            {
                Projectile aux = projectileQueue.Dequeue();
                return aux;
            }
        }
        else
        {
            Debug.LogError("Fila de objetos vazia");
            return null;
        }

    }

    public void ReplenishQueue(GameObject projectileObject)
    {
        if (projectileQueue.Count != capacity)
        {
            Projectile aux = projectileObject.GetComponent<Projectile>();
            projectileObject.SetActive(false);
            projectileQueue.Enqueue(aux);
        }
        else
            return;
    }
}
