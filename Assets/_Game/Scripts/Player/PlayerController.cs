using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 movement;
    private PlayerInputActions playerInput;
    private void Awake()
    {
        playerInput = new PlayerInputActions();
    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Move.performed += Move_performed;
        playerInput.Player.Move.canceled += Move_canceled;
    }

  

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Move.performed -= Move_performed;
        playerInput.Player.Move.canceled -= Move_canceled;
    }
    private void Update()
    {
        transform.position += (Vector3)movement * Time.deltaTime * moveSpeed;
    }
    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext input)
    {
       movement = Vector2.zero;
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext input)
    {
      movement = input.ReadValue<Vector2>();
    }
}