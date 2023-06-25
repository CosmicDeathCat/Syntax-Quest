using System.Collections.Generic;
using System.Linq;
using DLS.Core;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.Prompts;
using DLS.Game.Scripts.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DLS.Game.Scripts.Enemies
{
    public class BaseEnemy : ActorController
    {
        [field: SerializeField] public int PromptDifficulty { get; } = 1;

        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<PlayerController>();
            if (player != null)
            {
                CodePromptDisplay.ShowQuizPrompt(player, PromptDifficulty);
            }
        }
    }
}