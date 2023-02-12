using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickupController
{
    public float value;
    public override void Act(HealthController pl)
    {
        if (pl.DoHeal(value))
            Destroy(this.gameObject);
    }
}
