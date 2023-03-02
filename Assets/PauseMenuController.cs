using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    private bool paused = false;
    private bool helpopen = false;
    public GameObject pauseMenu;
    public GameObject help;
    public InputActionAsset actions;
    public InputActionMap attack;
    public InputActionMap move;

    void Start()
    {
        InputActionMap map = actions.FindActionMap("menu", true);
        map.FindAction("open/close").performed += PauseUnpause;
        map.Enable();
        attack = actions.FindActionMap("shooting", true);
        move = actions.FindActionMap("movement", true);
        help.SetActive(false);
        pauseMenu.SetActive(false);
    }

    private void PauseUnpause(InputAction.CallbackContext context)
    {
        if (helpopen)
            CloseHelp();
        else if (!paused)
            Pause();
        else
            Unpause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
        paused = true;
        attack.Disable();
        move.Disable();
        pauseMenu.SetActive(true);
    }

    private void Unpause()
    {
        Time.timeScale = 1;
        paused = false;
        attack.Enable();
        move.Enable();
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Unpause();
        SceneManager.LoadScene("GameScene");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void OpenHelp()
    {
        help.SetActive(true);
        helpopen = true;
    }
    public void CloseHelp()
    {
        help.SetActive(false);
        helpopen = false;
    }
}
