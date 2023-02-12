using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Act(collision.gameObject.GetComponent<HealthController>());
        }
    }
    public abstract void Act(HealthController pl);
}
