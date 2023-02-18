using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeUp : MonoBehaviour
{
    SpriteRenderer sprite;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.75f);
    }


    void Update()
    {
        transform.Translate(new Vector3(0, Time.deltaTime, 0));
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, sprite.color.a - Time.deltaTime);
        if (sprite.color.a <= 0.1f)
            Destroy(gameObject);
    }
}
