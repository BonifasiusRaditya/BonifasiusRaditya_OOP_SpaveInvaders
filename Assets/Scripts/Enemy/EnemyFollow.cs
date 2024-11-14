using UnityEngine;

public class EnemyFollow : Enemy
{
    float distance;
    public float distanceBetween;
    public float speed = 2f; // Speed at which the enemy follows the player

    void Start(){
    }

    void Update()
    {
        GameObject player = GameObject.Find("Player");
        if (player != null){
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            if (distance < distanceBetween) transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    void selfDestruct(){
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        if(transform.position.x < min.x){
            Destroy(gameObject);
        }
    }
}
