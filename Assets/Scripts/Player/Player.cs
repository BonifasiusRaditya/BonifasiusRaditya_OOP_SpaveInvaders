using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    PlayerMovement playerMovement;
    Animator animator;

    private void Awake(){
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate(){
        playerMovement.Move();
    }

    void LateUpdate(){
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}