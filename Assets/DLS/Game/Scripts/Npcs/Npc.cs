using System.Collections.Generic;
using System.Linq;
using DLS.Core;
using DLS.Dialogue;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.Prompts;
using DLS.Game.Scripts.UI;
using DLS.Utilities;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DLS.Game.Scripts.Npcs
{
    public class Npc : ActorController
    {
        [field: SerializeField] public int PromptDifficulty { get; set; } = 1;

        protected override void OnTriggerEnter2D(Collider2D col)
        {
            base.OnTriggerEnter2D(col);
            if (dialogueManager != null)
            {
                if(dialogueManager.Interactions.All(x=> x.DialogueCompleted && !x.RepeatableDialogue)) return;
            }
            if (col.CompareTag("Player"))
            {
                DialogueUi.Instance.ShowInteractionText($"Press E to Establish Connection with {actorName}");
            }
            
        }

        protected override void OnTriggerExit2D(Collider2D col)
        {
            base.OnTriggerExit2D(col);
            if (col.CompareTag("Player"))
            {
                DialogueUi.Instance.HideInteractionText();
            }
        }

        protected override void OnDialogueInteract(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            if (gameObject != messageEnvelope.Message<DialogueInteractMessage>().Target) return;
            var player = messageEnvelope.Message<DialogueInteractMessage>().Source.GetComponent<PlayerController>();
            if (isInteracting) return;
            if (dialogueManager == null)
            {
                CodePromptDisplay.ShowLearningPrompt(player, PromptDifficulty);
            }
            else
            {
                if (!dialogueManager.StartDialogue()) return;
            }
            DialogueUi.Instance.HideInteractionText();
        }
    }
}