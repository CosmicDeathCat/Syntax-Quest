using System;
using DLS.Dialogue;
using DLS.Game.Scripts.Messages;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.PlayerPrefsPlus;
using DLS.Utilities;
using PlayerPrefsPlus;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace DLS.Game.Scripts.UI
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class FloatingDPad : MonoBehaviour
    {
        [field: SerializeField] private GameObject Joystick;
        [field: SerializeField] private LayerMask ObjectLayerMask;
        [field: SerializeField] private Button UpButton;
        [field: SerializeField] private Button RightButton;
        [field: SerializeField] private Button DownButton;
        [field: SerializeField] private Button LeftButton;
        private Tilemap objectLayerTilemap;
        private Tilemap objectUnderPlayerTilemap;
        private Vector2 pos;
        private TileBase objectTile;
        private TileBase objectUnderPlayerTile;
        private Collider2D colliderAtPos;
        private PlayerController player;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
            objectLayerTilemap = GameObject.Find("Object").GetComponent<Tilemap>();
            objectUnderPlayerTilemap = GameObject.Find("Object Under Player").GetComponent<Tilemap>();
        }

        private void Start()
        {
            var enableOnScreenJoystick = PPPlus.GetBool(Prefs.EnableOnScreenJoystick);
            MessageSystem.MessageManager.SendImmediate(MessageChannels.UI, new JoystickEnableMessage(enableOnScreenJoystick));
        }

        private void OnEnable()
        {
            UpButton.onClick.AddListener(() => { Move(Vector2.up, player.MoveSpeed); });
            RightButton.onClick.AddListener(() => { Move(Vector2.right, player.MoveSpeed); });
            DownButton.onClick.AddListener(() => { Move(Vector2.down, player.MoveSpeed); });
            LeftButton.onClick.AddListener(() => { Move(Vector2.left, player.MoveSpeed); });
            PPPlus.OnPrefChanged += OnPrefChanged;
            MessageSystem.MessageManager.RegisterForChannel<JoystickEnableMessage>(MessageChannels.UI, OnJoystickEnableCallback);
        }



        private void OnDisable()
        {
            UpButton.onClick.RemoveAllListeners();
            RightButton.onClick.RemoveAllListeners();
            DownButton.onClick.RemoveAllListeners();
            LeftButton.onClick.RemoveAllListeners();
            PPPlus.OnPrefChanged -= OnPrefChanged;
            MessageSystem.MessageManager.UnregisterForChannel<JoystickEnableMessage>(MessageChannels.UI, OnJoystickEnableCallback);
        }

        public void Move(Vector2 movement, float moveSpeed)
        {
            if (player != null)
            {
                pos = movement * moveSpeed;

                objectTile = objectLayerTilemap.GetTile(
                    objectLayerTilemap.WorldToCell(player.transform.position + new Vector3(-0.5f, -0.5f) + (Vector3)pos));
                objectUnderPlayerTile = objectUnderPlayerTilemap.GetTile(
                    objectUnderPlayerTilemap.WorldToCell(player.transform.position + new Vector3(-0.5f, -0.5f) + (Vector3)pos));
                colliderAtPos = Physics2D.OverlapPoint(player.transform.position + (Vector3)pos, ObjectLayerMask);

                if (movement.y > 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 180);
                }
                else if (movement.y < 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (movement.x > 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, 90);
                }
                else if (movement.x < 0)
                {
                    player.transform.rotation = Quaternion.Euler(0, 0, -90);
                }

                // Move the player
                Vector3 newPosition = player.transform.position + (Vector3)pos;

                if (objectTile != null || objectUnderPlayerTile != null ||
                    Physics2D.OverlapPoint(newPosition, ObjectLayerMask) != null)
                {
                    return;
                }

                if (pos.x != 0 && pos.y != 0)
                {
                    return;
                }

                player.transform.position = newPosition;
            }
        }

        private void OnPrefChanged(string key, object obj)
        {
            if (key.Equals(Prefs.EnableOnScreenJoystick))
            {
                Joystick.SetActive((bool)obj);
            }
        }
        
        private void OnJoystickEnableCallback(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            Joystick.SetActive(messageEnvelope.Message<JoystickEnableMessage>().Enabled);
        }
    }
}