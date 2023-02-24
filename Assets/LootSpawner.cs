using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootSpawner : BasicSpawner
{
    private int layerMask;
    protected override void Start()
    {
        int WallLayer = 10;
        int BlockLayer = 11;

        int Mask1 = 1 << WallLayer;
        int Mask2 = 1 << BlockLayer;

        layerMask = Mask1 | Mask2; //Layer mask represents occupied space that cant be occupied by loot
        base.Start();
    }
    protected override Vector3 GetPosition()
    {
        Vector3 pos;
        bool valid;
        do
        {
            pos = new Vector3(Random.Range(-x_range, x_range), Random.Range(-y_range, y_range), 0f);
            RaycastHit2D hit = Physics2D.GetRayIntersection(new Ray(pos, -Vector3.forward), Mathf.Infinity, layerMask);
            valid = hit.collider == null;
        } while (!valid); //Finds new position for Loot by getting random pos until unnocupied pos
        return pos;
    }
}
