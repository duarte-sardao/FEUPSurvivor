using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpPickup : PickupController
{
    public int power;
    public override void Act(GameObject pl)
    {
        var a = pl.GetComponent<PlayerAttack>();
        a.SetPower(power);
        Destroy(this.gameObject);
    }
}
