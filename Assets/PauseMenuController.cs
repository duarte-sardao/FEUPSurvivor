using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuController : MonoBehaviour
{
    private bool paused = false;
    public InputActionAsset actions;

    void Start()
    {
        InputActionMap map = actions.FindActionMap("menu", true);
        map.FindAction("open/close").performed += PauseUnpause;
    }

    private void PauseUnpause(InputAction.CallbackContext context)
    {
        Debug.Log("blaaah");
        if (paused)
            Pause();
        else
            Unpause();
    }

    private void Pause()
    {
        Time.timeScale = 0;
    }

    private void Unpause()
    {
        Time.timeScale = 1;
    }
}
