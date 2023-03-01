using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : ChasingEnemy
{

    public GameObject projectile;
    public float shootRate; 
    private float shootCount; 
    public float shotIntervalRate;
    public float shotCount; //Max number of shots by enemy
    private float shotsLeft; //Shots left to shoot

    public float range;

    protected override void Start()
    {
        base.Start();
        shotsLeft = shotCount;
    }

    private void Update()
    {
        shootCount += Time.deltaTime;
        if(shootCount > shootRate && (player.transform.position-this.transform.position).magnitude < range)
        {
            shootCount = 0;
            InvokeRepeating("Shoot", 0f, shotIntervalRate); //Starts shooting every intervale rate by invoking
        }
    }

    private void Shoot()
    {
        shotsLeft--;
        var obj = Instantiate(projectile, this.transform.position, Quaternion.identity);
        obj.GetComponent<BulletController>().Move((player.transform.position - this.transform.position).normalized); //Aims bullet to player
        if(shotsLeft == 0) //Stops invoking when nr of shots reaches shotCount
        {
            shotsLeft = shotCount;
            CancelInvoke();
        }
    }
}
