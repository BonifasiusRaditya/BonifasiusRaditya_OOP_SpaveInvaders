 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public float speed;
    void Start(){
        level = 3;
    }

    void Update(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        EnemyMove(speed, 0);
        if(transform.position.x < min.x || transform.position.x > max.x) speed = -speed;
        getKilled();
    }

    void getKilled(){
        if(GetComponent<HitboxComponent>().health.Health <= 5){
            spawner.getKilled();
            combatmanager.OnEnemyKilled();
        }
    }
}
