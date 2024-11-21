using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    Vector2 newPostion;
    bool isPickedUp = false;

    void Awake(){
    }

    void Start(){
        ChangePosition();
    }

    void Update(){
        isPickedUp = (Player.Instance.GetComponentInChildren<Weapon>() != null);
        GetComponent<SpriteRenderer>().enabled = isPickedUp; 
        GetComponent<CircleCollider2D>().enabled = isPickedUp; 

        if(Player.Instance != null && isPickedUp == true){
            if(Vector2.Distance(transform.position, newPostion) < 0.5f) ChangePosition();
            transform.position = Vector2.MoveTowards(transform.position, newPostion, speed * Time.deltaTime);
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && other.GetComponentInChildren<Weapon>() != null){
            Debug.Log("Next Level");
            if (GameManager.Instance != null && GameManager.Instance.LevelManager != null) GameManager.Instance.LevelManager.LoadScene("Main");
        }
    }

    void ChangePosition(){
        newPostion = new Vector2(Random.Range(-Camera.main.orthographicSize * Camera.main.aspect, Camera.main.orthographicSize * Camera.main.aspect), Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
    }
}
