using System.Collections;
using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class MovimentPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animPlayer;


    float directionMove = 0.0f;

    bool isRight = true;

    [Header("Moviment")]
    [SerializeField] float speedMove = 2.0f;

    [Header("Jumping")]
    [SerializeField] float jumpForce = 2.0f;
    DialogueSystem dialogueSystem;

    private GameSystemActions playerConstrols;
    private InputAction move;
    private InputAction jump;



    private void Awake()
    {

        dialogueSystem = FindObjectOfType<DialogueSystem>();
        playerConstrols = new GameSystemActions();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();

                
    }

    private void OnEnable()
    {
        move = playerConstrols.Player.Move;
        move.Enable();
        jump = playerConstrols.Player.Jump;
        jump.Enable();
        jump.performed += jumpPlayer;

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

    void jumpPlayer(InputAction.CallbackContext context)
    {
        rb.AddForce(Vector2.up * jumpForce);
        
    }

    private void FlipPlayer()
    {
        if ((isRight && directionMove < 0f) || (!isRight && directionMove > 0f)) 
        {
            isRight = !isRight;

            GetComponent<SpriteRenderer>().flipX = !isRight;


        }

        animPlayer.SetBool("isRunning", directionMove != 0);
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(directionMove * speedMove, rb.linearVelocity.y);
    }
}
