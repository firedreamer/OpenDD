using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InputManager inputManager;
    PlayerLocomotion playerLocomotion;
    CameraMan cameraMan;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
        cameraMan = FindObjectOfType<CameraMan>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
    }

    private void Update()
    {
        inputManager.UltimateInputHandler();
    }

    private void FixedUpdate()
    {
        playerLocomotion.UltimateMovementHandler();
    }

    private void LateUpdate() 
    {
        cameraMan.UniversalCameraHandler();        
    }
}
