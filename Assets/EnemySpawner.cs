using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay;
    public GameObject spawnObj;
    public float spawnRange;
    private float accTime = 0f;

    private void Update()
    {
        accTime += Time.deltaTime;
        if(accTime > spawnDelay)
        {
            accTime = 0f;
            var spawnPoint = new Vector3(this.transform.position.x + Random.Range(-spawnRange,spawnRange), this.transform.position.y + Random.Range(-spawnRange,spawnRange), 0);
            Instantiate(spawnObj, spawnPoint, Quaternion.identity);
        }
    }

}
