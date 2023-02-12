using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : EnemyController
{
    private Rigidbody2D rb;
    public float speed;
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = (player.transform.position - this.transform.position).normalized * speed;
    }
}
