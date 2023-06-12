using System.Collections;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] [Range(0f, 50f)] int poolSize = 5;
    [SerializeField] [Range(0.1f, 30f)] float spawnTimer = 1f;

    GameObject[] pool;

    void Awake()
    {
        PopulatePool();   
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for (var i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            EnableObjectInPool();
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        foreach (var enemy in pool)
        {
            if (!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return;
            }
        }
    }
}
