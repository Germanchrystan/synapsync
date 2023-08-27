using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private float horizontalInput;
    private float verticalInput;
    private float speed=10f;

    private Rigidbody2D rg;
	private Animator animator;

    private const string DOWN_DIRECTION = "Down";
    private const string UP_DIRECTION = "Up";
    private const string LEFT_DIRECTION = "Left";
    private const string RIGHT_DIRECTION = "Right";
    private string currentDirection = DOWN_DIRECTION;

    private bool _canMove = true;
    public bool CanMove { get => _canMove; set => _canMove = value; }

    private string currentAnimationState = "IdleUp";
    private string newAnimationState = "IdleUp";
    void Awake()
	{
    	rg=GetComponent<Rigidbody2D>();
	    animator=GetComponent<Animator>();
	}
    void Update()
    {
        if (CanMove)
		{	
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if(verticalInput < 0) currentDirection = DOWN_DIRECTION;
            if(verticalInput > 0) currentDirection = UP_DIRECTION;

            if(horizontalInput > 0) currentDirection = RIGHT_DIRECTION;
            if(horizontalInput < 0) currentDirection = LEFT_DIRECTION;

            movement = new Vector2(horizontalInput, verticalInput);
        }
    }
    void FixedUpdate()
	{	
		if (CanMove)
		{	
			Vector2 velocity = movement.normalized * speed;
			rg.velocity = velocity;
		}
        else
        {
            rg.velocity = Vector2.zero;
        }
        // Debug.Log(CanMove);

    }
    void LateUpdate()
    {
        if(movement.x != 0 || movement.y != 0)
        {
            newAnimationState = $"Walk{currentDirection}";
        }
        else
        {
            newAnimationState = $"Idle{currentDirection}";
        }
        // Debug.Log(currentAnimationState);
        ChangeAnimationState(newAnimationState);
    }
    void ChangeAnimationState(string newAnimationState)
	{
		if (currentAnimationState == newAnimationState) return;

		animator.Play(newAnimationState);

		currentAnimationState = newAnimationState;
	}
}
