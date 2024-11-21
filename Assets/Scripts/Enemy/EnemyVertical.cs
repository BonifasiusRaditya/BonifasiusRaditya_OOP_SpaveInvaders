using UnityEngine;

public class EnemyVertical : Enemy
{
    public float speed;
    void Start(){
        level = 1;
    }

    void Update(){
        EnemyMove(0, speed);
        selfDestruct();
        getKilled();
    }

    void selfDestruct(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if(transform.position.y < min.y){
            Destroy(gameObject);
        }
    }

    void getKilled(){
        if(GetComponent<HitboxComponent>().health.Health <= 5){
            spawner.getKilled();
            combatmanager.totalEnemies--;
        }
    }
}
