using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;
    public float clampMinY;
    public float clampMaxY;
    public float clampMinX;
    public float clampMaxX;

    void FixedUpdate()
    {
        var speed = Mathf.Sqrt(Mathf.Pow(this.transform.position.x - player.transform.position.x, 2) + Mathf.Pow(this.transform.position.y - player.transform.position.y, 2))*2;
        var x = Mathf.Clamp(Mathf.Lerp(this.transform.position.x, player.transform.position.x, Time.deltaTime * speed), clampMinX, clampMaxX);
        var y = Mathf.Clamp(Mathf.Lerp(this.transform.position.y, player.transform.position.y, Time.deltaTime * speed), clampMinY, clampMaxY);
        this.transform.position = new Vector3(x, y, -10);
    }
}
