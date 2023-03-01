using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BasicSpawner
{
    public int credLevel = 0;
    public float extraDelay = 0;

    protected override void GetTime()
    {
        base.GetTime();
        targ_time += extraDelay;
        //Debug.Log(targ_time);
    }

    protected override GameObject GetObject()
    {
        var nmb = raffle[Random.Range(0, raffle.Count)];
        if (nmb > credLevel) nmb = 0;
        return spawnables[nmb].obj;
    }
}
