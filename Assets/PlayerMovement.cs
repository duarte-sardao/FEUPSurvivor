using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public InputActionAsset actions;
    public InputAction movement;


    public Vector2 moved;

    public float runSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer hatSprite;
    private Animator animator;

    void Start()
    {
        movement = actions.FindActionMap("movement", true).FindAction("move", true);


        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hatSprite = transform.GetChild(3).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moved = movement.ReadValue<Vector2>() * runSpeed;
        if (moved.x != 0)
        {
            sprite.flipX = (moved.x < 0); //For displaying correct player orientation
            hatSprite.flipX = sprite.flipX;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = moved;
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }
}
