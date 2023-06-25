using System;
using DLS.Core;
using DLS.Dialogue;
using DLS.Game.Scripts.Messages;
using DLS.Game.Scripts.Npcs;
using DLS.Game.Scripts.Prompts;
using DLS.Utilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.Tilemaps;

namespace DLS.Game.Scripts.Player
{
    public class PlayerController : ActorController
    {
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private LayerMask objectLayerMask;
        [SerializeField] private ProgrammingLanguages availableLanguages;
        [SerializeField] private ProgrammingLanguages currentLanguage;
        private Tilemap objectLayerTilemap;
        private Tilemap objectUnderPlayerTilemap;
        private Animator anim;
        private SpriteRenderer sr;
        private Vector2 movement;
        private PlayerInputActions playerInput;
        private Finger moveFinger;

        private Vector2 pos;
        private TileBase objectTile;
        private TileBase objectUnderPlayerTile;
        private Collider2D colliderAtPos;
        
        public float MoveSpeed
        {
            get => moveSpeed;
            set => moveSpeed = value;
        }

        public LayerMask ObjectLayerMask
        {
            get => objectLayerMask;
            set => objectLayerMask = value;
        }

        public ProgrammingLanguages AvailableLanguages
        {
            get => availableLanguages;
            set => availableLanguages = value;
        }

        public ProgrammingLanguages CurrentLanguage
        {
            get => currentLanguage;
            set => currentLanguage = value;
        }

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
            base.OnEnable();
            playerInput.Enable();
            playerInput.Player.Move.performed += Move_performed;
            playerInput.Player.Move.canceled += Move_canceled;
            playerInput.Player.Interact.performed += Interact_performed;
            MessageSystem.MessageManager.RegisterForChannel<PauseMessage>(MessageChannels.GameFlow, PauseHandler);
        }




        private void OnDisable()
        {
            base.OnDisable();
            playerInput.Disable();
            playerInput.Player.Move.performed -= Move_performed;
            playerInput.Player.Move.canceled -= Move_canceled;
            playerInput.Player.Interact.performed -= Interact_performed;
        }

        private void Move_canceled(UnityEngine.InputSystem.InputAction.CallbackContext input)
        {
            movement = Vector2.zero;
        }

        private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext input)
        {
            movement = input.ReadValue<Vector2>().normalized;
            pos = movement * moveSpeed;

            objectTile = objectLayerTilemap.GetTile(
                    objectLayerTilemap.WorldToCell(transform.position + new Vector3(-0.5f, -0.5f) + (Vector3)pos));
            objectUnderPlayerTile = objectUnderPlayerTilemap.GetTile(
                objectUnderPlayerTilemap.WorldToCell(transform.position + new Vector3(-0.5f, -0.5f) + (Vector3)pos));
            colliderAtPos = Physics2D.OverlapPoint(transform.position + (Vector3)pos, objectLayerMask);

            // Update the character rotation based on the movement direction
            if (movement.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (movement.y < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (movement.x > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (movement.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }

            // Move the player
            Vector3 newPosition = transform.position + (Vector3)pos;

            if (objectTile != null || objectUnderPlayerTile != null ||
                Physics2D.OverlapPoint(newPosition, objectLayerMask) != null)
            {
                return;
            }

            if (pos.x != 0 && pos.y != 0)
            {
                return;
            }

            transform.position = newPosition;
        }
        
        private void Interact_performed(InputAction.CallbackContext input)
        {
            Interact();
        }
        
        private void PauseHandler(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            if (messageEnvelope.Message<PauseMessage>().Paused)
            {
                playerInput.Disable();
            }
            else
            {
                playerInput.Enable();

            }
        }

        protected override void OnDialogueInteract(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            if (gameObject != messageEnvelope.Message<DialogueInteractMessage>().Target) return;
            var npc = targetGameObject.GetComponent<Npc>();
            if(npc == null) return;
            if (isInteracting) return;
            if (dialogueManager == null)
            {
                CodePromptDisplay.ShowLearningPrompt(this, npc.PromptDifficulty);
            }
            else
            {
                if (!dialogueManager.StartDialogue()) return;
            }
            DialogueUi.Instance.HideInteractionText();
        }
    }
}