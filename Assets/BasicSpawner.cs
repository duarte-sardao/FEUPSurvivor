using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpawner : MonoBehaviour
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
    protected List<int> raffle = new List<int>();

    public float x_range;
    public float y_range;
    public float min_time;
    public float max_time;
    private float targ_time;
    private float acc_time;

    protected virtual void Start()
    {
        InitRaffle();
        GetTime();
    }
    public void InitRaffle()
    {
        for (int i = 0; i < spawnables.Length; i++)
        {
            for (int j = 0; j < spawnables[i].points; j++)
                raffle.Add(i);
        }
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
        return new Vector3(this.transform.position.x + Random.Range(-x_range, x_range), this.transform.position.y + Random.Range(-y_range, y_range), 0f);
    }

    protected virtual GameObject GetObject()
    {
        return spawnables[raffle[Random.Range(0, raffle.Count)]].obj; //get a random index from raffle, then get obj it corresponds to
    }

    protected void Spawn()
    {
        Instantiate(GetObject(), GetPosition(), Quaternion.identity);

    }

    protected void GetTime()
    {
        targ_time = Random.Range(min_time, max_time);
        acc_time = 0;
    }
}
