using System;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.PlayerPrefsPlus;
using PlayerPrefsPlus;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace DLS.Game.Scripts.UI
{
    [RequireComponent(typeof(RectTransform))]
    [DisallowMultipleComponent]
    public class FloatingDPad : MonoBehaviour
    {
        [SerializeField] private GameObject joystick;
        [SerializeField] private LayerMask objectLayerMask;
        [SerializeField] private Button upButton;
        [SerializeField] private Button rightButton;
        [SerializeField] private Button downButton;
        [SerializeField] private Button leftButton;
        private Tilemap objectLayerTilemap;
        private Tilemap objectUnderPlayerTilemap;
        private Vector2 pos;
        private TileBase objectTile;
        private TileBase objectUnderPlayerTile;
        private Collider2D colliderAtPos;
        private PlayerController player;
        public static Action<bool> OnJoystickEnable;

        private void Awake()
        {
            player = FindObjectOfType<PlayerController>();
            objectLayerTilemap = GameObject.Find("Object").GetComponent<Tilemap>();
            objectUnderPlayerTilemap = GameObject.Find("Object Under Player").GetComponent<Tilemap>();
        }

        private void Start()
        {
            var enableOnScreenJoystick = PPPlus.GetBool(Prefs.EnableOnScreenJoystick);
            JoystickEnable(enableOnScreenJoystick);
        }

        private void OnEnable()
        {
            upButton.onClick.AddListener(() => { Move(Vector2.up, player.MoveSpeed); });
            rightButton.onClick.AddListener(() => { Move(Vector2.right, player.MoveSpeed); });
            downButton.onClick.AddListener(() => { Move(Vector2.down, player.MoveSpeed); });
            leftButton.onClick.AddListener(() => { Move(Vector2.left, player.MoveSpeed); });
            PPPlus.OnPrefChanged += OnPrefChanged;
            OnJoystickEnable += OnJoystickEnableCallback;
        }

        private void OnDisable()
        {
            upButton.onClick.RemoveAllListeners();
            rightButton.onClick.RemoveAllListeners();
            downButton.onClick.RemoveAllListeners();
            leftButton.onClick.RemoveAllListeners();
            PPPlus.OnPrefChanged -= OnPrefChanged;
            OnJoystickEnable -= OnJoystickEnableCallback;
        }

        public void Move(Vector2 movement, float moveSpeed)
        {
            if (player != null)
            {
                pos = movement * moveSpeed;

                objectTile = objectLayerTilemap.GetTile(
                    objectLayerTilemap.WorldToCell(player.transform.position + new Vector3(-0.5f, -0.5f) +
                                                   (Vector3)pos));
                objectUnderPlayerTile = objectUnderPlayerTilemap.GetTile(
                    objectUnderPlayerTilemap.WorldToCell(player.transform.position + new Vector3(-0.5f, -0.5f) +
                                                         (Vector3)pos));
                colliderAtPos = Physics2D.OverlapPoint(player.transform.position + (Vector3)pos, objectLayerMask);

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
                    Physics2D.OverlapPoint(newPosition, objectLayerMask) != null)
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
                joystick.SetActive((bool)obj);
            }
        }

        private void OnJoystickEnableCallback(bool enabled)
        {
            joystick.SetActive(enabled);
        }

        public static void JoystickEnable(bool enabled)
        {
            OnJoystickEnable?.Invoke(enabled);
        }
    }
}