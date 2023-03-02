using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeOutAndLoad : CreditController
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
        if (img.color.a == 255)
        {
            PlayerPrefs.SetInt("Credits", creditCount);
            SceneManager.LoadScene("ScoreBoard");
        }
    }
}
