using System.Collections;
using System.Collections.Generic;
using IngameDebugConsole;
using UnityEngine;

public class UIHandlerSystem : MonoBehaviour
{
    public GameObject ConsoleWindow;
    public GameObject Graphy;
    public GameObject DebugUI;
    void Start()
	{
        Cursor.lockState = CursorLockMode.Locked;
        
        //Only enable debug commands if debug build TODO: Someway to enable devmode
        if (Debug.isDebugBuild)
        {
            ConsoleWindow.SetActive(true);
            DebugUI.SetActive(true);
            Graphy.SetActive(false);
        }
        //Console Commands
		DebugLogConsole.AddCommand( "qqq", "Exit the game. ", ForceYeet );
        DebugLogConsole.AddCommand( "tpg", "Toggles performance graph.", ToggleFPSGraph );
	}

    public void ToggleFPSGraph()
    {
        if(Graphy.activeSelf)
        {
            Graphy.SetActive(false);
        }
        else Graphy.SetActive(true);
    }

    public void ForceYeet()
    {
        Application.Quit();
    }
}
