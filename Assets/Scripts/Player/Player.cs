using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    PlayerMovement playerMovement;
    Animator animator;

    // Static instance of the Player class
    public static Player Instance { get; private set; }

    private void Awake()
    {
        // Check if an instance already exists
        if (Instance == null)
        {
            // If not, set this object as the instance
            Instance = this;
            // Make sure the instance is not destroyed on scene load
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy any additional instances
            Destroy(gameObject);
        }
    }

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        GameObject engineEffect = GameObject.Find("EngineEffect");
        animator = engineEffect.GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        playerMovement.Move();
    }

    void LateUpdate()
    {
        animator.SetBool("IsMoving", playerMovement.IsMoving());
    }
}