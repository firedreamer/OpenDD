using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyCharacter;


public class InputManager : MonoBehaviour
{
    PlayerControls playerControls;
    AnimationManager animationManager;
    public Vector2 movementInput;
    public Vector2 cameraInput;
    private float moveAmount;
    public float horizontalInput;
    public float verticalInput;
    public float cameraX, cameraY;

    private void Awake()
    {
        animationManager = GetComponent<AnimationManager>();
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.Movement.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void UltimateInputHandler()
    {
        HandleMovementInput();
        HandleCameraInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animationManager.UpdateAnimatorValues(0, moveAmount);
    }

    private void HandleCameraInput()
    {
        cameraX = cameraInput.x;
        cameraY = cameraInput.y;
    }
}