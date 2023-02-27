using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalMove = 0f;
    public float verticalMove = 0f;
    public float runSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private SpriteRenderer hatSprite;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        hatSprite = transform.GetChild(3).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
        if (horizontalMove != 0)
        {
            sprite.flipX = (horizontalMove < 0); //For displaying correct player orientation
            hatSprite.flipX = sprite.flipX;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, verticalMove);
        animator.SetFloat("Speed", rb.velocity.magnitude);
    }
}
