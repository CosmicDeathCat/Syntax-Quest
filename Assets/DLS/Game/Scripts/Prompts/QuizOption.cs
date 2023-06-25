using UnityEngine;
using UnityEngine.Events;

namespace DLS.Game.Scripts.Prompts
{
    [System.Serializable]
    public class QuizOption
    {
        [field: SerializeField] public string Text { get; set; }
        [field: SerializeField] public UnityAction Action { get; set; }
        [field: SerializeField] public bool IsAnswer { get; set; }

        public QuizOption(string text, UnityAction action, bool isAnswer)
        {
            Text = text;
            Action = action;
            IsAnswer = isAnswer;
        }
    }

}