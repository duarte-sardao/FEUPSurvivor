using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    void FixedUpdate()
    {
        var speed = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2))*2;
        this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime * speed),
                                               Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.deltaTime * speed), -10);
    }
}
