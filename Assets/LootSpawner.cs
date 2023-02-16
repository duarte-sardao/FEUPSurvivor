using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
{
    public float x_range;
    public float y_range;
    public float min_time;
    public float max_time;
    private float targ_time;
    private float acc_time;

    public GameObject spawn;

    public void Start()
    {
        GetTime();
    }

    private void Update()
    {
        acc_time += Time.deltaTime;
        if(acc_time > targ_time)
        {
            GetTime();
            Spawn();
        }
    }

    private void Spawn()
    {
        var pos = new Vector3(Random.Range(-x_range, x_range), Random.Range(-y_range, y_range), 0);
        Instantiate(spawn, pos, Quaternion.identity);

    }

    private void GetTime()
    {
        targ_time = Random.Range(min_time, max_time);
        acc_time = 0;
    }
}
