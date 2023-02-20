using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : BulletController
{
    private GameObject player;
    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        InvokeRepeating("UpdateMove", 0.33f, 0.33f);
    }

    private void UpdateMove()
    {
        base.Move((player.transform.position - this.transform.position).normalized);
    }


}