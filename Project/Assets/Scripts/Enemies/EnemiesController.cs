using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private Transform enemiesSpawnPoint;
    [SerializeField] private Transform enemiesContent;
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
        player.onEnemyMiss.AddListener(AttackFirstEnemy);

        StartCoroutine(SpawnEnemies());
    }

    public IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (spawnedEnemies.Count < maxEnemiesCount)
            {
                SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }

    public void SpawnEnemy()
    {
        Enemy newEnemy = Instantiate(enemyPrefab, enemiesSpawnPoint.position, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
        //newEnemy.JumpOn(spawnedEnemies.Count);
        float targetX = player.transform.position.x + player.transform.localScale.x + ((spawnedEnemies.Count - 1) * enemiesOffset) + newEnemy.transform.localScale.x;
        newEnemy.SetTarget(new Vector2(targetX, newEnemy.transform.position.y));

        newEnemy.onDie += RemoveEnemy;
        newEnemy.transform.SetParent(enemiesContent);
    }

    public void AttackFirstEnemy()
    {
        spawnedEnemies[0].AttackPlayer(player);
    }

    private void RemoveEnemy(Enemy enemy)
    {
        enemy.onDie -= RemoveEnemy;
        spawnedEnemies.Remove(enemy);

        UpdateEnemies();
    }

    public void UpdateEnemies()
    {
        spawnedEnemies = spawnedEnemies.Where(item => item != null).ToList();

        for (int i = 0; i < spawnedEnemies.Count; i++)
        {
            if (spawnedEnemies[i] != null)
            {
                float targetX = player.transform.position.x + player.transform.localScale.x + ((i) * enemiesOffset) + spawnedEnemies[i].transform.localScale.x;
                spawnedEnemies[i].SetTarget(new Vector2(targetX, spawnedEnemies[i].transform.position.y));
            }
            else
            {
                spawnedEnemies.Remove(spawnedEnemies[i]);
            }
        }
    }
}
