using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float maxHealth;
    public float health;

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

    public void DoDamage(float val)
    {
        health -= val;
        if(health < 0)
        {
            //destroy and do something particles idk
            Destroy(this.gameObject);
        }
    }
}
