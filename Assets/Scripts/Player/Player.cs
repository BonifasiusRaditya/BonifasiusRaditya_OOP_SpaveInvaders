using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    PlayerMovement playerMovement;
    Animator animator;

    private void Awake(){
        if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start(){
        playerMovement = GetComponent<PlayerMovement>();
        animator = GameObject.Find("EngineEffect").GetComponent<Animator>();
    }

    void FixedUpdate(){
        playerMovement.Move();
        playerMovement.MoveBound();
    }

    void LateUpdate(){
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}