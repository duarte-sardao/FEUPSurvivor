using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMenuController : MonoBehaviour
{
    public void StartGame()
    {
        CreditController creditController = new CreditController();
        creditController.Reset();
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
