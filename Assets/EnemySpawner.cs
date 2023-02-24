using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BasicSpawner
{
    public int credLevel = 0;

    protected override GameObject GetObject()
    {
        var nmb = raffle[Random.Range(0, raffle.Count)];
        if (nmb > credLevel) nmb = 0;
        return spawnables[nmb].obj;
    }
}
