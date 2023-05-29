using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    [SerializeField] private LayerMask objectLayerMask;
    private Tilemap objectLayerTilemap;
    private Tilemap objectUnderPlayerTilemap;
    private Animator anim;
    private SpriteRenderer sr;
    private Vector2 movement;
    private PlayerInputActions playerInput;
    public static Action<bool> OnPaused;
    private void Awake()
    {
        playerInput = new PlayerInputActions();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        objectLayerTilemap = GameObject.Find("Object").GetComponent<Tilemap>();
        objectUnderPlayerTilemap = GameObject.Find("Object Under Player").GetComponent<Tilemap>();

    }
    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Move.performed += Move_performed;
        playerInput.Player.Move.canceled += Move_canceled;
        OnPaused += OnPausedHandler;
    }

    private void OnDisable()
    {
        playerInput.Disable();
        playerInput.Player.Move.performed -= Move_performed;
        playerInput.Player.Move.canceled -= Move_canceled;
        OnPaused -= OnPausedHandler;
    }
    

    private void OnPausedHandler(bool paused)
    {
        if (paused)
        {
            playerInput.Disable();
        }
        else
            playerInput.Enable();
    }

    private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext input)
    {
       movement = Vector2.zero;
    }

    private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext input)
    {
      movement = input.ReadValue<Vector2>();
      var pos = movement * moveSpeed;
      var objectTile = objectLayerTilemap.GetTile(Vector3Int.FloorToInt((Vector2)transform.position + new Vector2(-0.5f,-0.5f) + pos));
      var objectUnderPlayerTile = objectUnderPlayerTilemap.GetTile(Vector3Int.FloorToInt((Vector2)transform.position + new Vector2(-0.5f,-0.5f) + pos));
      var colliderAtPos = Physics2D.OverlapPoint((Vector2)transform.position + pos,objectLayerMask);
      if (movement.y > 0)
      {
          transform.rotation = new Quaternion(0, 0, 180, 0);
      }
      else if (movement.y < 0)
      {
          transform.rotation = quaternion.identity;
      }
      
      if (movement.x > 0)
      {
          transform.rotation = Quaternion.Euler(0,0,90);
      }
      else if (movement.x < 0)
      {
          transform.rotation = Quaternion.Euler(0,0,-90);
      }

      if ((movement.x == 0 || movement.y != 0) && (movement.y == 0 || movement.x != 0)) return;
      if(objectTile != null || objectUnderPlayerTile != null || colliderAtPos != null) { return; }
      transform.position += (Vector3)movement * moveSpeed;

    }

    public static bool Paused(bool isPaused)
    {
        OnPaused.Invoke(isPaused);
        return isPaused;
    }



}