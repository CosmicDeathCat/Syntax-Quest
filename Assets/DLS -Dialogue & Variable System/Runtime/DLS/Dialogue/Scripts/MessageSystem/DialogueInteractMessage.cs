using System;
using UnityEngine;

namespace DLS.Dialogue
{
    [Serializable]
    public struct DialogueInteractMessage
    {
        public GameObject Source { get; }
        public GameObject Target { get; }

        public DialogueInteractMessage(GameObject source, GameObject target)
        {
            Source = source;
            Target = target;
        }
    }
}