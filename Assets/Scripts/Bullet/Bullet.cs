using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Stats")]
    public float bulletSpeed = 20;
    public int damage = 10;
    public float lifeTime = 0.0010f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        BulletMove();
        selfDestruct();
    }

    void BulletMove(){
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, bulletSpeed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
    }

    void selfDestruct(){
        lifeTime -= Time.deltaTime;
        if(lifeTime <= 0) Destroy(gameObject);
    }
}
