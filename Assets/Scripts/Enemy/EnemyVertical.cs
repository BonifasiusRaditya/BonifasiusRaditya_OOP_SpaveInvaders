 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVertical : Enemy
{
    public float speed;
    void Start(){
    }

    void Update(){
        EnemyMove(0, speed);
        selfDestruct();
    }

    void selfDestruct(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if(transform.position.y < min.y){
            Destroy(gameObject);
        }
    }
}
