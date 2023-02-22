using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;
    public PlayerAttack pl;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            var health = collision.gameObject.GetComponent<HealthController>();
            health.DoDamage(damage*pl.MeleeMult(), collision.GetContact(0).point);
        }
        catch (System.Exception) { };
    }
}
