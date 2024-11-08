using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed, timeToFullSpeed, timeToStop, stopClamp;
    Vector2 moveDirection, moveVelocity, moveFriction, stopFriction, frictionForce;
    Rigidbody2D rb;
    public Camera MainCamera;
    private Vector2 screenBounds;
    float shipBoundary = 0.5f;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }
    
    public void Move(){
        moveVelocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * maxSpeed;
        //moveVelocity +=  Time.deltaTime * GetFriction();
        rb.velocity = new Vector2(Mathf.Clamp(moveVelocity.x, -maxSpeed.x, maxSpeed.x), Mathf.Clamp(moveVelocity.y, -maxSpeed.y, maxSpeed.y)); 
        if(Mathf.Abs(rb.velocity.x) < stopClamp.x && Mathf.Abs(rb.velocity.y) < stopClamp.y) rb.velocity = Vector2.zero;
    }

    Vector2 GetFriction(){
        if(rb.velocity != Vector2.zero) return moveFriction;
        else return stopFriction;
    }

    public void MoveBound(){
        Vector3 pos = transform.position;
        if(pos.y + shipBoundary > Camera.main.orthographicSize) pos.y = Camera.main.orthographicSize - shipBoundary;
        if(pos.y - shipBoundary < -Camera.main.orthographicSize) pos.y = -Camera.main.orthographicSize + shipBoundary;
        if(pos.x + shipBoundary > Camera.main.orthographicSize * Camera.main.aspect) pos.x = Camera.main.orthographicSize * Camera.main.aspect - shipBoundary;
        if(pos.x - shipBoundary < -Camera.main.orthographicSize * Camera.main.aspect) pos.x = -Camera.main.orthographicSize * Camera.main.aspect + shipBoundary;
        transform.position = pos;
    }

    public bool IsMoving(){
        return rb.velocity != Vector2.zero;
    }
}