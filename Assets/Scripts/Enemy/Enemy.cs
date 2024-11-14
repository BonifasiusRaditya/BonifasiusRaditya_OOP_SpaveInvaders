using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject prefab;
    public int option;
    public float spawnDelay = 2f;
    void Start(){
        //Invoke ("SpawnEnemy", spawnDelay);
    }

    /*void Awake(){
        InvincibilityComponent invincibilityComponent = GetComponent<InvincibilityComponent>();
        if (invincibilityComponent == null){
            invincibilityComponent = gameObject.AddComponent<InvincibilityComponent>();
        }

        Material enemyFlashMaterial = Resources.Load<Material>("EnemyFlashMaterial");
        if (enemyFlashMaterial != null){
            invincibilityComponent.SetBlinkMaterial(enemyFlashMaterial);
        }
        else{
            Debug.LogWarning("EnemyFlashMaterial nggak ketemu. Pastikan material ada di folder Resources.");
        }
    }*/

    // Update is called once per frame
    void Update(){
    }

    public void EnemyMove(float speed_horizontal, float speed_vertical){
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed_horizontal * Time.deltaTime, -speed_vertical * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    /*void SpawnEnemy(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        GameObject enemy = (GameObject)Instantiate(prefab);
        if(option == 1){
            enemy.transform.position = new Vector2(max.x, Random.Range(min.y + (max.y - min.y) / 2, max.y));
            ScheduleNextEnemySpawn();
        }
        else if(option == 2){
            enemy.transform.position = new Vector2(Random.Range(min.x + (max.x - min.x) / 2, max.x), max.y);
            ScheduleNextEnemySpawn();
        }
        else if(option == 3){
            enemy.transform.position = new Vector2(Random.Range(min.x + (max.x - min.x) / 2, max.x), Random.Range(min.y + (max.y - min.y) / 2, max.y));
        }
        else{
            enemy.transform.position = new Vector2(max.x, Random.Range(min.y + (max.y - min.y) / 2, max.y));
        }
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
    }*/
}
