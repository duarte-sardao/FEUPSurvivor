using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickupController
{
    public float value;
    public override void Act(GameObject pl)
    {
        var h = pl.GetComponent<HealthController>();
        if (h.DoHeal(value))
            Destroy(this.gameObject);
    }
}
