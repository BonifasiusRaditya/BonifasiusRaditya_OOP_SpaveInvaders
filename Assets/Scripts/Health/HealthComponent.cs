using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth;
    public int Health; 
    
    int getHealth(){
        return Health;
    }

    public void subtractHealth(int damage){
        Health -= damage;
    }

    // Start is called before the first frame update
    public void Start(){
        Health = maxHealth;
    }

    // Update is called once per frame
    void Update(){
        if(Health <= 0) Destroy(gameObject);
    }
}
