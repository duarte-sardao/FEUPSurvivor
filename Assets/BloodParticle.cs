using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    public float timeToFade;
    private float timeAcc;
    void Start()
    {
        var size = Random.Range(0.05f, 0.15f);
        this.transform.localScale = new Vector3(size, size, 0);
        this.transform.position = new Vector3(this.transform.position.x + Random.Range(-0.1f, 0.1f), this.transform.position.y + Random.Range(-0.1f, 0.1f), -1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0);
    }

    void Update()
    {
        timeAcc += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (timeAcc > timeToFade)
        {
            this.transform.localScale = this.transform.localScale * 0.9f;
            if (this.transform.localScale.x < 0.005f)
                Destroy(this.gameObject);
        }
    }
}
