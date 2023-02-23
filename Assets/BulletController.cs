using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public bool pierce; 
    public float velocity;
    public float timeAlive; 

    private void Start(){
        Invoke("Kill", timeAlive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            var health = collision.gameObject.GetComponent<HealthController>();
            health.DoDamage(damage, collision.GetContact(0).point); 
            if (!pierce) //If bulled type endures even after colliding with objects
                Destroy(this.gameObject);
        }
        catch (System.Exception) { //in case collided object has no health component (wall)
            Destroy(this.gameObject);
        };
    }

    public void Move(Vector3 dir, Vector2 vel){ //For player
        Move(dir);
        this.GetComponent<Rigidbody2D>().velocity += vel; //Adds player velocity to bullet to make shooting more accurate while moving
    }

    public void Move(Vector3 dir) //For enemies
    {
        this.GetComponent<Rigidbody2D>().velocity = dir * velocity;
        this.transform.right = dir;
    }

    protected void Kill(){
        Destroy(this.gameObject);
    }
}
