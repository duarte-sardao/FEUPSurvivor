using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float damage;
    public float velocity;
    public float timeAlive;
    public bool pierce;

    private void Start(){
        Invoke(nameof(Kill), timeAlive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            var health = collision.gameObject.GetComponent<HealthController>();
            var toRemove = health.health;
            health.DoDamage(Mathf.Min(toRemove, damage), collision.GetContact(0).point);
            RemovePoints(toRemove);
        }
        catch (System.Exception) { //in case collided object has no health component (wall)
            Destroy(this.gameObject);
        };
    }

    public void Move(Vector3 dir)
    {
        this.GetComponent<Rigidbody2D>().velocity = dir * velocity;
        if(this.gameObject.layer == 7)
            this.transform.right = dir;
    }

    protected void Kill(){
        Destroy(this.gameObject);
    }

    private void RemovePoints(float r)
    {
        damage -= r;
        if(!pierce || damage <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
