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
        speed = Random.Range(speed - speed*0.05f, speed + speed*0.05f);
    }

    void FixedUpdate()
    {
        Chase();
    }

    protected virtual void Chase()
    {
        rb.velocity = (player.transform.position - this.transform.position).normalized * speed;
    }
}
