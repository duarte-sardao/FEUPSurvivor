using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneFadeOutAndLoad : CreditController
{
    public SpriteRenderer img;
    public GameObject canvas;

    private void Start()
    {
        img.color = new Vector4(img.color.r, img.color.g, img.color.b, 0);
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        canvas.SetActive(false);
        img.color = new Vector4(img.color.r, img.color.g, img.color.b, img.color.a + Time.deltaTime);
        //Debug.Log(img.color.a);
        if (img.color.a >= 1)
        {
            PlayerPrefs.SetInt("Credits", creditCount);
            SceneManager.LoadScene("ScoreBoard");
        }
    }
}
