using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditController : MonoBehaviour
{
    protected static int creditCount = 0; //Score count
    static TMPro.TMP_Text text;
    static GameObject hat;
    static AudioSource sound;

    private void Start()
    {
        if(text == null)
        {
            text = GameObject.Find("Canvas/ScoreText").GetComponent<TMPro.TMP_Text>(); //Score text
            hat = GameObject.Find("Player/PlayerCap");
            sound = GameObject.Find("Sounds/Credit").GetComponent<AudioSource>();
            hat.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            sound.Play();
            creditCount++;
            UpdateText();
            if (creditCount == 300)
                hat.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void UpdateText()
    {
        text.text = creditCount + " ECTS";
    }
}
