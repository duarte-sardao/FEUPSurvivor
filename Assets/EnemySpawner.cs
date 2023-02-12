using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay;
    public GameObject spawnObj;
    private float accTime = 0f;

    private void Update()
    {
        accTime += Time.deltaTime;
        if(accTime > spawnDelay)
        {
            accTime = 0f;
            Instantiate(spawnObj, this.transform.position, Quaternion.identity);
        }
    }

}
