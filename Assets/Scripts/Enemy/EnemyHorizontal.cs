using UnityEngine;

public class EnemyHorizontal : Enemy
{
    public float speed;
    void Start(){
    }

    public void Update(){
        EnemyMove(speed, 0);
        selfDestruct();
        getKilled();
    }

    void selfDestruct(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if(transform.position.x < min.x){
            StartCoroutine(spawner.Enemies());
            Destroy(gameObject);
        }
    }
}
