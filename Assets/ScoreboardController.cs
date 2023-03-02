using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardController : MonoBehaviour
{
    public List<string> names;
    public List<int> scores;
    public int newscore;
    public string newname;

    public TMPro.TMP_Text[] listedNames;
    public TMPro.TMP_Text[] listedScores;

    public GameObject winText;
    public GameObject loseText;
    public TMPro.TMP_Text scoreDisplay;
    public TMPro.TMP_Text gradeDisplay;

    void Start()
    {
        names.Add(PlayerPrefs.GetString("1", "Pereira"));
        scores.Add(PlayerPrefs.GetInt("1", 308));
        names.Add(PlayerPrefs.GetString("2", "Duarte"));
        scores.Add(PlayerPrefs.GetInt("2", 304));
        for(int i = 3; i <= 5; i++)
        {
            names.Add(PlayerPrefs.GetString(i.ToString(), "..."));
            scores.Add(PlayerPrefs.GetInt(i.ToString(), 0));
        }
        SetUpUI();
    }

    void SetUpUI()
    {
        var newspot = 5;
        for(int i = 0; i < 5; i++)
        {
            UpdateBoard(names[i], scores[i], i);
            if (newspot == 5 && newscore > scores[i])
                newspot = i;
        }
        int grade = 0;
        if (newspot < 5)
        {
            winText.SetActive(true);
            grade = 20 - newspot * 2;
        }
        else
            loseText.SetActive(true);
        scoreDisplay.text = newscore.ToString();
        gradeDisplay.text = grade.ToString();

    }

    void UpdateBoard(string name, int val, int pos)
    {
        listedNames[pos].text = name;
        listedScores[pos].text = val.ToString();
    }

    void Save()
    {
        for(int i = 0; i <= 4; i++)
        {
            var key = (i + 1).ToString();
            string name;
            int value;
            if(newscore > scores[i])
            {
                name = newname;
                value = newscore;
                i--;
            } else
            {
                name = names[i];
                value = scores[i];
            }
            PlayerPrefs.SetString(key, name);
            PlayerPrefs.SetInt(key, value);
            UpdateBoard(name, value, i);
        }
    }
}
