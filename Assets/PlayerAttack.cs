using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float delay = 0.5f;
    public GameObject bullet;
    public GameObject piercebullet;
    public bool triple;
    public bool pierce;
    private float last = 0f;
    private void Update()
    {
        last += Time.deltaTime;
        if(last > delay && Input.GetMouseButton(0))
        {
            last = 0f;
            var pos = (GetCurrentMousePosition()-this.transform.position).normalized;
            SpawnBullet(pos);
            if(triple)
            {
                pos = Quaternion.AngleAxis(-20, Vector3.forward) * pos;
                SpawnBullet(pos);
                pos = Quaternion.AngleAxis(40, Vector3.forward) * pos;
                SpawnBullet(pos);
            }
        }
    }

    private void SpawnBullet(Vector3 pos)
    {
        var spawn = this.bullet;
        if (pierce)
            spawn = piercebullet;
        Instantiate(spawn, this.transform.position, Quaternion.identity).GetComponent<BulletController>().Move(pos);
    }

    private Vector3 GetCurrentMousePosition()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var plane = new Plane(Vector3.forward, Vector3.zero);

        float rayDistance;
        if (plane.Raycast(ray, out rayDistance))
        {
            return ray.GetPoint(rayDistance);

        }

        return new Vector3();
    }
}
