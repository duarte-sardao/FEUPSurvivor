using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Act(collision.gameObject);
        }
    }
    public abstract void Act(GameObject pl);
}
