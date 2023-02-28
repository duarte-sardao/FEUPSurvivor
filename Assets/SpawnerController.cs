using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : CreditController
{
    public float minToSwitch;
    public float maxToSwitch;
    public GameObject[] spawners;
    void Start()
    {
        Invoke("SelectSpawners", 0f);
    }

    int[] Reshuffle(int[] pos)
    {
        for (int t = 0; t < pos.Length; t++)
        {
            int tmp = pos[t];
            int r = Random.Range(t, pos.Length);
            pos[t] = pos[r];
            pos[r] = tmp;
        }
        return pos;
    }

    private void SelectSpawners()
    {
       foreach(var sp in spawners)
       {
            sp.SetActive(false);
       }
        int[] arr = { 0, 1, 2, 3 };
        Stack<int> choices = new Stack<int>(Reshuffle(arr));
        for(int i = 0; i <= creditCount; i+=60)
        {
            var spawner = spawners[choices.Pop()];
            spawner.SetActive(true);
            var scrpt = spawner.GetComponent<EnemySpawner>();
            scrpt.credLevel = Mathf.FloorToInt(creditCount / 45);
            scrpt.extraDelay = Mathf.Floor(creditCount / 60) * 0.15f;
        }
        Invoke("SelectSpawners", Random.Range(minToSwitch, maxToSwitch));
    }
}
