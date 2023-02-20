using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditController : MonoBehaviour
{
    static int creditCount = 0;
    static TMPro.TMP_Text text;

    private void Start()
    {
        if(text == null)
        {
            text = GameObject.Find("Canvas/ScoreText").GetComponent<TMPro.TMP_Text>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            creditCount++;
            UpdateText();
            Destroy(this.gameObject);
        }
    }

    private void UpdateText()
    {
        text.text = creditCount + " ECTS";
    }
}
