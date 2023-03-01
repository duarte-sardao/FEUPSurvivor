using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float maxHealth;
    public float health;
    public GameObject bloodParticle;

    protected virtual void Start()
    {
        maxHealth = health;
    }

    public virtual bool DoHeal(float val) //Increases health of object, limited by maxHealth
    {
        if (health >= maxHealth)
            return false;
        health = Mathf.Clamp(health+val, 0, maxHealth);
        return true;
    }

    private void SpawnBlood(int val, Vector3 pos) //Spawns random amount of blood particles
    {
        for(int i = 0; i < Random.Range(Mathf.CeilToInt(val/2), val+1)*3; i++) 
        {
            Instantiate(bloodParticle, pos, Quaternion.identity);
        }
    }

    public virtual void DoDamage(float val, Vector3 pos) //Decreases health of object and detects death
    {
        health -= val;
        SpawnBlood(Mathf.CeilToInt(val), pos);
        if(health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
