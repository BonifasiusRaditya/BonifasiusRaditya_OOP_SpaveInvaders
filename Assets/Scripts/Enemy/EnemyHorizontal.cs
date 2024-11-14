 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed;
    void Start(){
        Invoke ("SpawnEnemy", spawnDelay);
    }

    void Update(){
        EnemyMove(speed, 0);
        selfDestruct();
    }

    void selfDestruct(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if(transform.position.x < min.x){
            Destroy(gameObject);
        }
    }

    void SpawnEnemy(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemy = (GameObject)Instantiate(prefab);
        enemy.transform.position = new Vector2(max.x, Random.Range(min.y + (max.y - min.y) / 2, max.y));
    }

    void ScheduleNextEnemySpawn(){
        float spawnInNSeconds;
        if(spawnDelay > 1){
            spawnInNSeconds = Random.Range(1, spawnDelay);
        }else{
            spawnInNSeconds = 1;
        }
        Invoke("SpawnEnemy", spawnInNSeconds);
    }

    void increaseSpawnRate(){
        if(spawnDelay > 1){
            spawnDelay--;
        }
        if(spawnDelay == 1){
            CancelInvoke("increaseSpawnRate");
        }
    }
}
