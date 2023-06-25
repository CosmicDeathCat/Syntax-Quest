using System;
using UnityEngine;

namespace DLS.Core
{
    /// <summary>
    /// This interface represents the actor data.
    /// </summary>
    public interface IActorData : IDialogue
    {
        /// <summary>
        /// The GUID of the actor.
        /// </summary>
        Guid ID { get; set; }
        
        /// <summary>
        /// The name of the actor.
        /// </summary>
        string ActorName { get; set; }
        
        /// <summary>
        /// The GameObject associated with the actor.
        /// </summary>
        GameObject GameObject { get; }

        /// <summary>
        /// Indicates whether movement is disabled for the actor.
        /// </summary>
        bool IsMovementDisabled { get; set; }
    }
}