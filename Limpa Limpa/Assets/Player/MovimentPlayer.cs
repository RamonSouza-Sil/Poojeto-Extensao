using System.Collections;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D rb;

    float directionMove = 0.0f;

    bool isRight = true;

    [Header("Moviment")]
    [SerializeField] float speedMove = 2.0f;

    private GameSystemActions playerConstrols;
    private InputAction move;



    private void Awake()
    {
        playerConstrols = new GameSystemActions();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        
    }

    private void OnEnable()
    {
        move = playerConstrols.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        directionMove = move.ReadValue<float>();

        FlipPlayer();
        
    }

    private void FlipPlayer()
    {
        if ((isRight && directionMove < 0f) || (!isRight && directionMove > 0f)) 
        {
            isRight = !isRight;

            GetComponent<SpriteRenderer>().flipX = !isRight;


        };
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(directionMove * speedMove, rb.linearVelocity.y);
    }
}
