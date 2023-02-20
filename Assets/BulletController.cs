using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public int damage;
    public bool pierce;
    public float velocity;
    private float killTime = 0f;
    public float timeAlive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            var health = collision.gameObject.GetComponent<HealthController>();
            health.DoDamage(damage, collision.GetContact(0).point);
            if (!pierce)
                Destroy(this.gameObject);
        }
        catch (System.Exception) {
            Destroy(this.gameObject);
        };
    }

    public void Move(Vector3 dir)
    {
        this.GetComponent<Rigidbody2D>().velocity = dir * velocity;
        this.transform.right = dir;
    }
    protected void Update(){
        killTime += Time.deltaTime;
        if (killTime > timeAlive){
            Destroy(this.gameObject);
        }
    }
}
