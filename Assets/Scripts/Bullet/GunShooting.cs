using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShooting : MonoBehaviour
{
    public float fireDelay = 0.01f;
    float cooldownTimer = 0;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        cooldownTimer -= Time.deltaTime;
        if(cooldownTimer <= 0){
            cooldownTimer = fireDelay;
            Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            Instantiate(prefab, spawnPosition, transform.rotation);
        }
    }
}
