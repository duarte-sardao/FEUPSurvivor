using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : HealthController
{
    public float damage;
    protected HealthController player;
    public GameObject corpse;
    private AudioSource hurtSound;

    protected override void Start()
    {
        base.Start(); //calls Health controller
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>();
        hurtSound = this.GetComponent<AudioSource>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player.DoDamage(Time.deltaTime * damage, collision.GetContact(0).point); //Damage to player when colliding with enemies
        }
    }

    public override void DoDamage(float val, Vector3 pos)
    {
        hurtSound.Play();
        base.DoDamage(val, pos);
    }


    protected override void Die()
    {
        var obj = Instantiate(corpse, this.transform.position, Quaternion.identity);
        obj.transform.localScale = this.transform.localScale;
        obj.GetComponent<SpriteRenderer>().sprite = this.GetComponent<SpriteRenderer>().sprite;
        obj.GetComponent<AudioSource>().pitch = hurtSound.pitch + Random.Range(-0.1f, 0.1f);
        Destroy(gameObject);
    }
}
