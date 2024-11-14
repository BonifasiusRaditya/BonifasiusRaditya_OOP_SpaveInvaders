using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public int damage;
    public Bullet bullet;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
       
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika objek yang bertabrakan memiliki tag yang sama, hentikan eksekusi
        if (collision.gameObject.tag == gameObject.tag)
            return;

        // Cek apakah objek yang bertabrakan memiliki komponen Hitbox
        HitboxComponent hitbox = collision.GetComponent<HitboxComponent>();
        if (hitbox != null){
            hitbox.Damage(damage);
        }
    }
}
