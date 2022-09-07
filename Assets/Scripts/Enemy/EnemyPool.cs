using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesType = new List<GameObject>(2);
    [SerializeField] private List<Transform> spawnPosition = new List<Transform>(6);

    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    public static EnemyPool instance;
    public int enemyCount;
    [SerializeField] private float timeToSpawn;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        else
            instance = this;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject aux = Instantiate(enemiesType[Random.Range(0, 2)], spawnPosition[Random.Range(0, 6)]);
            aux.transform.localPosition = Vector3.zero;
            aux.transform.parent = this.transform;
            aux.SetActive(false);
            enemyPool.Enqueue(aux);
        }

        StartCoroutine(DequeueEnemies());

    }



    IEnumerator DequeueEnemies()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            enemyPool.Dequeue().SetActive(true);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
    public void DeactivateEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
    }
}
