using System;
using DLS.Dialogue;
using UnityEngine;

namespace DLS.Core
{
    public interface IDialogue : IInteractable
    {
        /// <summary>
        /// The name of the actor.
        /// </summary>
        string ActorName { get; set; }
        
        /// <summary>
        /// The portrait sprite of the actor.
        /// </summary>
        Sprite Portrait { get; set; }
        
        /// <summary>
        /// The dialogue manager responsible for handling actor dialogues.
        /// </summary>
        DialogueManager DialogueManager { get; set; }

    }
}