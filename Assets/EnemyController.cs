using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HealthController
{
    public float damage;
    protected HealthController player;

    protected override void Start()
    {
        base.Start(); //calls Health controller
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.DoDamage(Time.deltaTime * damage, collision.GetContact(0).point); //Damage to player when colliding with enemies
        }
    }


    protected override void Die()
    {
        var obj = new GameObject(); //For fading ghosts when killed
        obj.transform.position = this.transform.position;
        obj.transform.localScale = this.transform.localScale;
        obj.AddComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        obj.AddComponent<FadeUp>();
        Destroy(gameObject);
    }
}
