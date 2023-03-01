using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFadeOutAndLoad : MonoBehaviour
{
    public SpriteRenderer img;

    private void Start()
    {
        img.color = new Vector4(img.color.r, img.color.g, img.color.b, 0);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a + Time.deltaTime);
        //if(img.color.a == 1)
            //load scene
    }
}
