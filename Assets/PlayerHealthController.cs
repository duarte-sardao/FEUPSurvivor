using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : HealthController
{
    public GameObject fade;

    protected override void Die()
    {
        fade.SetActive(true);
        base.Die();
    }
}
