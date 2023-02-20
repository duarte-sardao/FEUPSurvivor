using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public struct Spawnable
    {
        public Spawnable(GameObject obj, int points)
        {
            this.obj = obj;
            this.points = points;
        }
        public GameObject obj;
        public int points;
    }

    public Spawnable[] spawnables;
    private List<int> raffle = new List<int>();

    public float x_range;
    public float y_range;
    public float min_time;
    public float max_time;
    private float targ_time;
    private float acc_time;

    protected virtual void Start()
    {
        for (int i = 0; i < spawnables.Length; i++)
        {
            for (int j = 0; j < spawnables[i].points; j++)
                raffle.Add(i);
        }

        GetTime();
    }

    protected void Update()
    {
        acc_time += Time.deltaTime;
        if (acc_time > targ_time)
        {
            GetTime();
            Spawn();
        }
    }

    protected virtual Vector3 GetPosition()
    {
        return new Vector3(Random.Range(-x_range, x_range), Random.Range(-y_range, y_range), 0f);
    }

    protected void Spawn()
    {
        Vector3 pos = GetPosition();

        var spawn = spawnables[raffle[Random.Range(0, raffle.Count)]].obj; //get a random index from raffle, then get obj it corresponds to

        Instantiate(spawn, pos, Quaternion.identity);

    }

    protected void GetTime()
    {
        targ_time = Random.Range(min_time, max_time);
        acc_time = 0;
    }
}
