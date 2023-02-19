using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : ChasingEnemy
{

    public GameObject projectile;
    public float shootRate;
    private float shootCount;
    public float shotIntervalRate;
    public float shotCount;
    private float shotsLeft;

    protected override void Start()
    {
        base.Start();
        shotsLeft = shotCount;
    }

    private void Update()
    {
        shootCount += Time.deltaTime;
        if(shootCount > shootRate)
        {
            shootCount = 0;
            InvokeRepeating("Shoot", 0f, shotIntervalRate);
        }
    }

    private void Shoot()
    {
        shotsLeft--;
        Instantiate(projectile, this.transform.position, Quaternion.identity);
        if(shotsLeft == 0)
        {
            shotsLeft = shotCount;
            CancelInvoke();
        }
    }
}
