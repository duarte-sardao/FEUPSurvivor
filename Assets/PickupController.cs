using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupController : MonoBehaviour
{
    public LootSpawner spawner;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Act(collision.gameObject);
        }
    }
    public abstract void Act(GameObject pl);

    public void Consume()
    {
        spawner.lootCount--;
        Destroy(this.gameObject);
    }
}
