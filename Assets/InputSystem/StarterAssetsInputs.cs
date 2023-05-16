using System;
using UnityEngine;
using Random = UnityEngine.Random;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")] public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool buttonX;
        public bool _buttonY;
        public bool Q, E;

        public bool buttonY
        {
            get
            {
                if (_buttonY && Random.Range(0, 100) > 98)
                    jump = true;
                return _buttonY;
            }
            set { _buttonY = value; }
        }

        [Header("Movement Settings")] public bool analogMovement;

#if !UNITY_IOS || !UNITY_ANDROID
        [Header("Mouse Cursor Settings")] public bool cursorLocked = true;
        public bool cursorInputForLook = true;
        private Gamepad _gamepad;
#endif

        private void Awake()
        {
            _gamepad = UnityEngine.InputSystem.Gamepad.current;
        }

        private void Update()
        {
            if (_gamepad != null)
            {
                buttonX = _gamepad.buttonWest.isPressed;
                buttonY = _gamepad.buttonNorth.isPressed;
            }
        }
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
        public void OnAttack1(InputValue value)
        {
            Attack1Input(value.isPressed);
        }
        public void OnAttack2(InputValue value)
        {
            Attack2Input(value.isPressed);
        }
#else
	// old input sys if we do decide to have it (most likely wont)...
    public void AttackOldInput()
    {
            if (Input.GetKeyDown(KeyCode.Q) && !Q)
                Q = true;
            if (Input.GetKeyUp(KeyCode.Q) && Q)
                Q = false;
            if (Input.GetKeyDown(KeyCode.E) && !E)
                E = true;
            if (Input.GetKeyUp(KeyCode.E) && E)
                E = false;
    }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            sprint = newSprintState;
        }
        public void Attack1Input(bool newAttackState)
        {
            buttonX = newAttackState;
        }
        public void Attack2Input(bool newAttackState)
        {
            buttonY = newAttackState;
        }

#if !UNITY_EDITOR

        private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        private void SetCursorState(bool newState)
        {
           Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }

#endif
    }
}