using UnityEngine;

namespace NaughtyCharacter
{
	public class PlayerInput : MonoBehaviour
	{
		public float MoveAxisDeadZone = 0.2f;
		public float sensitivity = 0.2f;
		
		public global::InputManager inputManager;
		public Vector2 MoveInput { get; private set; }
		public Vector2 LastMoveInput { get; private set; }
		public Vector2 CameraInput { get; private set; }
		public bool JumpInput { get; private set; }

		public bool HasMoveInput { get; private set; }

		public void UpdateInput()
		{
			// Update MoveInput
			Vector2 moveInput = inputManager.movementInput;
			if (Mathf.Abs(moveInput.x) < MoveAxisDeadZone)
			{
				moveInput.x = 0.0f;
			}

			if (Mathf.Abs(moveInput.y) < MoveAxisDeadZone)
			{
				moveInput.y = 0.0f;
			}

			bool hasMoveInput = moveInput.sqrMagnitude > 0.0f;

			if (HasMoveInput && !hasMoveInput)
			{
				LastMoveInput = MoveInput;
			}

			MoveInput = moveInput;
			HasMoveInput = hasMoveInput;

			// Update other inputs
			CameraInput = inputManager.cameraInput * sensitivity;
			JumpInput = Input.GetButton("Jump");
		}
	}
}
