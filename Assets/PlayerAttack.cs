using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public float delay = 0.5f;
    public GameObject bullet;
    public GameObject piercebullet;
    private float last = 0f;
    public GameObject attackCountdown;
    public GameObject attackObj;
    public float cooldownTime;
    public float attackTime;
    private float attackTimeLeft = 0;
    private float coolTime = 0;

    public float powerupTime;
    private float[] powerups = { 0,0,0,0}; //0 triple, 1 pierce 2 mel 3 shi
    public Image[] powerImg;
    public GameObject shield;

    private Rigidbody2D rb;

    private void Start()
    {
        attackObj.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
    }
    public void SetPower(int p)
    {
        powerups[p] = powerupTime;       
    }
    private void UpdatePowerups()
    {
        for(int i = 0; i < powerups.Length; i++)
        {
            if (powerups[i] > 0)
            {
                powerups[i] = Mathf.Clamp(powerups[i] - Time.deltaTime, 0, powerupTime);
                powerImg[i].fillAmount = powerups[i] / powerupTime;
            }
        }
    }

    public int MeleeMult()
    {
        if (powerups[2] > 0f)
            return 3;
        return 1;
    }

    private void Update()
    {
        UpdatePowerups();
        shield.SetActive(powerups[3] > 0);
        last += Time.deltaTime;
        coolTime = Mathf.Clamp(coolTime - Time.deltaTime * MeleeMult(), 0, cooldownTime);
        if (last > delay && Input.GetButton("Fire1"))
        {
            last = 0f;
            var pos = (GetCurrentMousePosition()-this.transform.position).normalized;
            SpawnBullet(pos);
            if(powerups[0] > 0)
            {
                pos = Quaternion.AngleAxis(-20, Vector3.forward) * pos;
                SpawnBullet(pos);
                pos = Quaternion.AngleAxis(40, Vector3.forward) * pos;
                SpawnBullet(pos);
            }
        }
        if(coolTime <= 0 && Input.GetButton("Fire2")){//start secondary attack
            coolTime = cooldownTime;
            attackObj.SetActive(true);
            attackTimeLeft = attackTime;
            attackObj.transform.rotation = Quaternion.identity;
            attackObj.transform.rotation *= Quaternion.Euler(Vector3.forward*(SignedAngleBetween(new Vector3(1, 0, 0), (GetCurrentMousePosition() - this.transform.position), Vector3.forward)-75));
        }
        if(attackTimeLeft > 0)
        {
            attackObj.transform.rotation *= Quaternion.Euler(Vector3.forward * Time.deltaTime * MeleeMult() * (150 / attackTime));
            attackTimeLeft -= Time.deltaTime * MeleeMult();
            if (attackTimeLeft <= 0)
                attackObj.SetActive(false);
        }
        attackCountdown.transform.localScale = new Vector3(coolTime/cooldownTime, attackCountdown.transform.localScale.y, 1);
    }

    private void SpawnBullet(Vector3 pos)
    {
        var spawn = this.bullet;
        if (powerups[1] > 0)
            spawn = piercebullet;
        Instantiate(spawn, this.transform.position, Quaternion.identity).GetComponent<BulletController>().Move(pos, rb.velocity);
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

    private float SignedAngleBetween(Vector3 a, Vector3 b, Vector3 n)
    {
        // angle in [0,180]
        float angle = Vector3.Angle(a, b);
        float sign = Mathf.Sign(Vector3.Dot(n, Vector3.Cross(a, b)));

        // angle in [-179,180]
        float signed_angle = angle * sign;

        // angle in [0,360] (not used but included here for completeness)
        float angle360 =  (signed_angle + 360) % 360;

        return angle360;
    }
}
