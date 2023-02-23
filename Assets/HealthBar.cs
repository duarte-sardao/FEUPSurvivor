using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Image healthBar;
    public HealthController healthScript;

    void Start()
    {
        healthBar = GetComponent<Image>();
    }


    void Update()
    {
        healthBar.fillAmount = healthScript.health / 100; //Updates health bar
    }
}
