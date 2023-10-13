using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwan : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float spawnTimer = 1f;
    [SerializeField] int poolSize = 5;

    GameObject[] pool;

    private void Awake()
    {
        PopulatePool();
    }

    void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for(int i = 0; i < pool.Length; i++)
        {
            pool[i] = Instantiate(enemy, transform);
            pool[i].active = false;
        }

    }
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void enableObjectInPool()
    {
        foreach (GameObject enemy in pool)
        {
            if (!enemy.active)
            {
                enemy.active = true;
                return;
            }
        }
    }

    IEnumerator SpawnEnemy()
    {
        while (Application.isPlaying)
        {
            enableObjectInPool(); 
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
