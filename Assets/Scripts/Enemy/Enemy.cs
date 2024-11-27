using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int level;
    public int option;
    public CombatManager combatmanager;
    public EnemySpawner spawner;
    public int point;

    void Start(){
    }

    // Update is called once per frame
    void Update(){
        
    }

    public void getKilled(){
        if(GetComponent<HitboxComponent>().health.Health <= 5){
            spawner.getKilled();
            combatmanager.getKilled();
        }
    }

    public void EnemyMove(float speed_horizontal, float speed_vertical){
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(speed_horizontal * Time.deltaTime, -speed_vertical * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }
}
