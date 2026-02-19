using UnityEngine;
using UnityEngine.InputSystem;
using System;


public class PlayerMovement : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private InputBehaviourSystem _input;
    private BoxCollider2D _boxCollider2D;
    
    public float moveSpeed = 5f;

    public float horizontalMovement;

    public enum States
    {
        RightIdle,
        LeftIdle,
        RightWalk,
        LeftWalk
    }
    
    public States state;
    public bool isMoving;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputBehaviourSystem>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        
        state = States.LeftIdle;
    }

    private void FixedUpdate()
    {
        if (_input != null)
        {
            _rigidbody2D.linearVelocityX = _input.Horizontal * moveSpeed;
        }
        
        UpdateAnimation();
        
        // Scuffed as all hell, but would make the trivia things work out.
        // essentially: movement makes the player solid, standing still makes them soft, passable.
        if (_rigidbody2D.linearVelocityX != 0)
        {
            _boxCollider2D.isTrigger = false;
        }
        else
        {
            _boxCollider2D.isTrigger = true;
        }
    }
    
    private void UpdateAnimation()
    {
        if (Math.Abs(_rigidbody2D.linearVelocityX) > 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        if (_rigidbody2D.linearVelocityX > 0)
        {
            state = States.RightWalk;
        }
        else if (_rigidbody2D.linearVelocityX < 0)
        {
            state = States.LeftWalk;
        }

        if (isMoving)
        {
            switch (state)
            {
                case States.LeftWalk:
                    _animator.Play("Walk Left");
                    break;
                case States.RightWalk:
                    _animator.Play("Walk Right");
                    break;
            }
        }
        else
        {
            switch (state)
            {
                case States.RightIdle:
                    _animator.Play("Idle Right");
                    break;
                case States.LeftIdle:
                    _animator.Play("Idle Left");
                    break;
                case States.LeftWalk:
                    _animator.Play("Idle Left");
                    break;
                case States.RightWalk:
                    _animator.Play("Idle Right");
                    break;
            }
        }
    }
    
    /*public void Move(InputAction.CallbackContext context)
    {
        horizontalMovement = context.ReadValue<Vector2>().x;
    }*/
}
