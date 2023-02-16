using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float delay = 0.5f;
    public GameObject bullet;
    public GameObject piercebullet;
    public bool triple;
    public bool pierce;
    private float last = 0f;
    public GameObject attackCountdown;
    public float cooldownTime;
    private float coolTime = 0;

    private void Update()
    {
        last += Time.deltaTime;
        coolTime = Mathf.Clamp(coolTime-Time.deltaTime, 0, cooldownTime);
        if(last > delay && Input.GetButton("Fire1"))
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
        if(coolTime <= 0 && Input.GetButton("Fire2")){
            coolTime = cooldownTime;

        }
        attackCountdown.transform.localScale = new Vector3(coolTime/cooldownTime, attackCountdown.transform.localScale.y, 1);
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
