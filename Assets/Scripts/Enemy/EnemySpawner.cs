using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Prefabs")]
    public Enemy spawnedEnemy;

    [SerializeField] private int minimumKillsToIncreaseSpawnCount = 3;
    public int totalKill = 0;
    [SerializeField] private float spawnInterval = 3f;

    [Header("Spawned Enemies Counter")]
    public int spawnCount = 0;
    public int defaultSpawnCount = 1;
    public int spawnCountMultiplier = 1;
    public int multiplierIncreaseCount = 1;
    public CombatManager combatManager;
    public bool isSpawning = false;

    void start(){
        spawnCount = defaultSpawnCount;
    }

    public void Begin(){
        if(!isSpawning && spawnedEnemy.level < combatManager.waveNumber){
            Debug.Log("Spawning " + spawnedEnemy.name + " Level " + spawnedEnemy.level + " from " + spawnedEnemy.GetType().Name);
            isSpawning = true;
            StartCoroutine(Spawn());
            combatManager.totalEnemies += spawnCount;
        }
    }

    private IEnumerator Spawn(){
        while(isSpawning){
            for(int i = 0; i < spawnCount; i++){
                SpawnEnemy();
                yield return new WaitForSeconds(spawnInterval);
            }
        }
    }

    private void SpawnEnemy(){
        if(spawnedEnemy != null){
            Enemy temp_enemy = Instantiate(spawnedEnemy);
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
            if(spawnedEnemy.option == 1) temp_enemy.transform.position = new Vector2(max.x, Random.Range(min.y + (max.y - min.y) / 2, max.y));
            else if(spawnedEnemy.option == 2) temp_enemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);
            else if(spawnedEnemy.option == 3) temp_enemy.transform.position = new Vector2(Random.Range(min.x + (max.x - min.x) / 2, max.x), Random.Range(min.y + (max.y - min.y) / 2, max.y));
            else temp_enemy.transform.position = new Vector2(max.x, Random.Range(min.y + (max.y - min.y) / 2, max.y));
            temp_enemy.GetComponent<Enemy>().combatmanager = combatManager;
            temp_enemy.GetComponent<Enemy>().spawner = this;
        }
    }

    public void getKilled(){
        spawnCount--;
        totalKill++;
        if(totalKill >= minimumKillsToIncreaseSpawnCount){
            totalKill = 0;
            spawnCount = defaultSpawnCount + spawnCountMultiplier * multiplierIncreaseCount;
            multiplierIncreaseCount++;
        }
    }
}