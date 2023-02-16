using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    public float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        try
        {
            var health = collision.gameObject.GetComponent<HealthController>();
            health.DoDamage(damage, collision.GetContact(0).point);
        }
        catch (System.Exception) { };
    }
}
