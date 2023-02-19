using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : ChasingEnemy
{

    public float telepInterval;
    private float telSpeed;

    protected override void Start()
    {
        base.Start();
        telSpeed = speed;
        speed *= 0.1f;
        InvokeRepeating("Teleport", telepInterval, telepInterval);
        InvokeRepeating("Twitch", 0f, 0.5f);
    }

    private void Twitch()
    {
        this.transform.position += new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0);
    }
    private void Teleport()
    {
        Vector3 dist = player.transform.position - this.transform.position;
        if(dist.magnitude < telSpeed)
        {
            this.transform.position = player.transform.position;
        } else
        {
            this.transform.position += dist.normalized * telSpeed;
        }
    }
}
