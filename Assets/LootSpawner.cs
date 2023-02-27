using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LootSpawner : BasicSpawner
{

    public Tilemap tilemapBack;
    public Tilemap tilemapFront;
    public List<Vector3> tileWorldLocations;

    private int layerMask;
    protected override void Start()
    {
        //int WallLayer = 10;
        int BlockLayer = 11;

        //int Mask1 = 1 << WallLayer;
        int Mask2 = 1 << BlockLayer;

        //layerMask = Mask1 | Mask2; //Layer mask represents occupied space that cant be occupied by loot
        layerMask = Mask2;

        //add background tiles
        foreach (var pos in tilemapBack.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemapBack.CellToWorld(localPlace);
            if (tilemapBack.HasTile(localPlace))
            {
                tileWorldLocations.Add(place);
            }
        }
        //remove tiles if theres foreground tiles
        foreach (var pos in tilemapBack.cellBounds.allPositionsWithin)
        {
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemapBack.CellToWorld(localPlace);
            if (tilemapBack.HasTile(localPlace) && tileWorldLocations.Contains(localPlace))
            {
                tileWorldLocations.Remove(place);
            }
        }

        base.Start();
    }
    protected override Vector3 GetPosition()
    {
        Vector3 pos;
        bool valid;
        do
        {
            pos = tileWorldLocations[Random.Range(0, tileWorldLocations.Count - 1)];
            pos = new Vector3(pos.x, pos.y, 0);
            RaycastHit2D hit = Physics2D.GetRayIntersection(new Ray(pos, -Vector3.forward), Mathf.Infinity, layerMask);
            valid = hit.collider == null;
        } while (!valid); //Finds new position for Loot by getting random pos until unnocupied pos
        return pos;
    }
}
