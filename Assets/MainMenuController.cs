using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class MainMenuController : BasicMenuController
{
    public GameObject cam;
    public Vector3 camTargPos;
    private Vector3 camtarg = new Vector3(0,0,-10);
    public Sprite ptsp;
    public Sprite engsp;
    public SpriteRenderer helpscreen;
    private bool active;

    private void Start()
    {
        ChangeLocale(PlayerPrefs.GetInt("locale", 0));
    }

    private void Update()
    {
        var diff = (camtarg - cam.transform.position);
        if(diff.magnitude > 0.05f)
        {
            diff = diff.normalized * Time.deltaTime*20;
            float newx = Mathf.Clamp(cam.transform.position.x + diff.x, 0, camTargPos.x);
            float newy = Mathf.Clamp(cam.transform.position.y + diff.y, 0, camTargPos.y);
            cam.transform.position = new Vector3(newx, newy, -10);
        }
    }
    public void Back()
    {
        camtarg = new Vector3(0, 0, -10);
    }
    public void Help()
    {
        camtarg = camTargPos;
    }

    public void ChangeLocale(int LocaleID)
    {
        if (active)
            return;
        StartCoroutine(SetLocale(LocaleID));
        PlayerPrefs.SetInt("locale", LocaleID);
        UpdateHelpSprite(LocaleID);
    }

    IEnumerator SetLocale(int _localeID)
    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }

    private void UpdateHelpSprite(int LocaleID)
    {
        if (LocaleID == 0)
            helpscreen.sprite = engsp;
        else
            helpscreen.sprite = ptsp;

    }
}
