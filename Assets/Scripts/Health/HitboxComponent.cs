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

    //memiliki dua method Damage (overloading) yang berguna untuk mengurangi nilai HealthComponent. Satu method menerima Bullet dan yang lain menerima integer
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
