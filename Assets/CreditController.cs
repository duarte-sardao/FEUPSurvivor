using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditController : PickupController
{
    protected static int creditCount = 0; //Score count
    static TMPro.TMP_Text text;
    static GameObject hat;
    static AudioSource sound;

    private void Start()
    {
        if(text == null)
        {
            text = GameObject.Find("Hud/ScoreText").GetComponent<TMPro.TMP_Text>(); //Score text
            hat = GameObject.Find("Player/PlayerCap");
            sound = GameObject.Find("Sounds/Credit").GetComponent<AudioSource>();
            hat.SetActive(false);
        }
    }

    public override void Act(GameObject pl)
    {
        sound.pitch = Random.Range(0.95f, 1.05f);
        sound.Play();
        creditCount++;
        UpdateText();
        if (creditCount == 300)
            hat.SetActive(true);
        if(creditCount < 300)
            spawner.lootMax += 3;
        base.Consume();
    }

    public void Reset()
    {
        creditCount = 0;
    }

    private void UpdateText()
    {
        text.text = creditCount + " ECTS";
    }
}
