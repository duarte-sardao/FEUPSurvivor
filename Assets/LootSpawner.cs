using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : MonoBehaviour
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

    private int layerMask;

    public void Start()
    {
        int WallLayer = 10;
        int BlockLayer = 11;

        int Mask1 = 1 << WallLayer;
        int Mask2 = 1 << BlockLayer;

        layerMask = Mask1 | Mask2;

        for(int i = 0; i < spawnables.Length; i++)
        {
            for (int j = 0; j < spawnables[i].points; j++)
                raffle.Add(i);
        }

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
        Vector3 pos;
        bool valid;
        do
        {
            pos = new Vector3(Random.Range(-x_range, x_range), Random.Range(-y_range, y_range), 0f);
            RaycastHit2D hit = Physics2D.GetRayIntersection(new Ray(pos, -Vector3.forward), Mathf.Infinity, layerMask);
            valid = hit.collider == null;
        } while (!valid);

        var spawn = spawnables[raffle[Random.Range(0, raffle.Count)]].obj; //get a random index from raffle, then get obj it corresponds to

        Instantiate(spawn, pos, Quaternion.identity);

    }

    private void GetTime()
    {
        targ_time = Random.Range(min_time, max_time);
        acc_time = 0;
    }
}
