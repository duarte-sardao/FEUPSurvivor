using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodParticle : MonoBehaviour
{
    public float timeToFade; // Amount of time a blood particle exists
    public float speedRange; 
    private float timeAcc;
    void Start()
    {
        var size = Random.Range(0.05f, 0.15f); //Randomizes blood size
        this.transform.localScale = new Vector3(size, size, 0); //Applies size to particle
        this.transform.position = new Vector3(this.transform.position.x + Random.Range(-0.1f, 0.1f), this.transform.position.y + Random.Range(-0.1f, 0.1f), -1); //Randomizes blood particles path
        this.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-speedRange, speedRange), Random.Range(-speedRange, speedRange), 0); //Randomizes blood particle velocity
    }

    void Update()
    {
        timeAcc += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        if (timeAcc > timeToFade)
        {
            this.transform.localScale = this.transform.localScale * 0.9f; //Shrinks particle until non-existance
            if (this.transform.localScale.x < 0.005f)
                Destroy(this.gameObject); //Blood particle destroyed;
        }
    }
}
