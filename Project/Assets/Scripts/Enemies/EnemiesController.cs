using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private Transform enemiesContent;
    [SerializeField] private int startEnemiesCount = 7;
    [SerializeField] private int maxEnemiesCount = 20;
    [SerializeField] private float spawnDelay = 1;
    [SerializeField] private float enemiesOffset = 0.5f;

    [SerializeField] private List<Enemy> spawnedEnemies;

    public static EnemiesController Instance;

    private void Awake()
    {
        if (Instance)
            Destroy(Instance);

        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < startEnemiesCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnEnemy()
    {
        if (spawnedEnemies.Count < maxEnemiesCount)
        {
            Enemy newEnemy = Instantiate(enemyPrefab, enemiesSpawnPoint.position, Quaternion.identity);
            spawnedEnemies.Add(newEnemy);
            //newEnemy.JumpOn(spawnedEnemies.Count);
            float targetX = player.transform.position.x + player.transform.localScale.x + ((spawnedEnemies.Count - 1) * enemiesOffset) + newEnemy.transform.localScale.x;
            newEnemy.SetTarget(new Vector2(targetX, newEnemy.transform.position.y));

            newEnemy.transform.SetParent(enemiesContent);
        }
    }

    public void RemoveEnemy(Enemy enemy)
    {
        spawnedEnemies.Remove(enemy);
    }
}
