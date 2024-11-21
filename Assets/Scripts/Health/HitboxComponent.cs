using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxComponent : MonoBehaviour
{
    //[RequireComponent(typeof(Collider2D))]
    public HealthComponent health;
    Bullet bullet;

    void Start(){
        GetComponent<Collider2D>().isTrigger = true;
    }

    public void Damage(Bullet bullet){
        health.subtractHealth(bullet.damage);
    }

    public void Damage(int damage){
        health.subtractHealth(damage);
    }

    void Update()
    {
        
    }
}
