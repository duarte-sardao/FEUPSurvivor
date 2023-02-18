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

    public bool DoHeal(float val)
    {
        if (health >= maxHealth)
            return false;
        health = Mathf.Clamp(health+val, 0, maxHealth);
        return true;
    }

    private void SpawnBlood(int val, Vector3 pos)
    {
        for(int i = 0; i < Random.Range(Mathf.CeilToInt(val/2), val+1)*3; i++)
        {
            Instantiate(bloodParticle, pos, Quaternion.identity);
        }
    }

    public void DoDamage(float val, Vector3 pos)
    {
        health -= val;
        SpawnBlood(Mathf.CeilToInt(val), pos);
        if(health <= 0)
        {
            //destroy and do something particles idk
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(this.gameObject);
    }
}
