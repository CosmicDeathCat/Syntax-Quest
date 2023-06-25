using System;
using DLS.Core;
using UnityEngine;

namespace DLS.Dialogue.Demo
{
    /// <summary>
    /// Represents the player actor in the game.
    /// </summary>
    public class PlayerActor : ActorController
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private Vector2 movement;
        private Rigidbody2D rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (Input.GetKeyDown(KeyCode.E))
            {
                Interact();
            }
        }

        /// <summary>
        /// Updates the player's position based on the movement input.
        /// </summary>
        private void FixedUpdate() => rb.position += movement * (moveSpeed * Time.fixedDeltaTime);
    }
}