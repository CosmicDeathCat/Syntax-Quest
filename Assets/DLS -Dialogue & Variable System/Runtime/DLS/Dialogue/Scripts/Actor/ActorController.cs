using System;
using DLS.Dialogue;
using DLS.Utilities;
using UnityEngine;
using MessageChannels = DLS.Dialogue.MessageChannels;

namespace DLS.Core
{
    /// <summary>
    /// Abstract base class for controlling an actor in the game.
    /// </summary>
    public abstract class ActorController : MonoBehaviour, IActorData
    {
        [SerializeField]
        protected Guid id;
        [SerializeField]
        protected string actorName;
        [SerializeField]
        protected Sprite portrait;
        [SerializeField]
        protected bool isInteracting;
        [SerializeField]
        protected bool isMovementDisabled;
        [SerializeField]
        protected DialogueManager dialogueManager;
        protected GameObject targetGameObject;

        /// <summary>
        /// Unique identifier for the actor.
        /// </summary>
        public Guid ID { get => id; set => id = value; }

        /// <summary>
        /// The GameObject associated with the actor.
        /// </summary>
        public GameObject GameObject { get; }

        /// <summary>
        /// The name of the actor.
        /// </summary>
        public string ActorName { get => actorName; set => actorName = value; }

        /// <summary>
        /// Indicates whether the actor is currently interacting with a target.
        /// </summary>
        public bool IsInteracting { get => isInteracting; set => isInteracting = value; }

        /// <summary>
        /// Indicates whether movement is disabled for the actor.
        /// </summary>
        public bool IsMovementDisabled { get => isMovementDisabled; set => isMovementDisabled = value; }

        /// <summary>
        /// The portrait of the actor.
        /// </summary>
        public Sprite Portrait { get => portrait; set => portrait = value; }

        /// <summary>
        /// The dialogue manager responsible for handling actor dialogues.
        /// </summary>
        public DialogueManager DialogueManager { get => dialogueManager; set => dialogueManager = value; }

        /// <summary>
        /// The GameObject that the actor is currently targeting for interaction.
        /// </summary>
        public GameObject TargetGameObject { get => targetGameObject; set => targetGameObject = value; }

        protected virtual void OnEnable()
        {
            MessageSystem.MessageManager.RegisterForChannel<DialogueInteractMessage>(MessageChannels.DialogueInteract, OnDialogueInteract);
            MessageSystem.MessageManager.RegisterForChannel<DialogueEndedMessage>(MessageChannels.DialogueEnd, OnDialogueEnded);
        }

        protected virtual void OnDisable()
        {
            MessageSystem.MessageManager.UnregisterForChannel<DialogueInteractMessage>(MessageChannels.DialogueInteract, OnDialogueInteract);
            MessageSystem.MessageManager.UnregisterForChannel<DialogueEndedMessage>(MessageChannels.DialogueEnd, OnDialogueEnded);
        }


        /// <summary>
        /// Interacts with the current target GameObject.
        /// </summary>
        public virtual void Interact()
        {
            if (targetGameObject != null)
            {
                MessageSystem.MessageManager.SendImmediate(MessageChannels.DialogueInteract, new DialogueInteractMessage(gameObject, targetGameObject));
            }
        }

        protected virtual void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.GetComponent<IActorData>() == null) { return; }
            targetGameObject = col.gameObject;
        }

        protected virtual void OnTriggerExit2D(Collider2D col)
        {
            if (targetGameObject != col.gameObject) { return; }
            targetGameObject = null;
        }

        protected virtual void OnDialogueInteract(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            if (gameObject != messageEnvelope.Message<DialogueInteractMessage>().Target) return;
            if (dialogueManager == null) return;
            if (isInteracting) return;
            if (!dialogueManager.StartDialogue()) return;
            DialogueUi.Instance.HideInteractionText();
        }
        
        protected virtual void OnDialogueEnded(MessageSystem.IMessageEnvelope messageEnvelope)
        {
            isInteracting = false;
            isMovementDisabled = false;
            DialogueUi.Instance.HideInteractionText();
        }
    }
}
