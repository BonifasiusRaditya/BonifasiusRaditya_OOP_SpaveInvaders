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
}
