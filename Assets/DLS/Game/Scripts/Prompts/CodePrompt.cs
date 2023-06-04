using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace DLS.Game.Scripts.Prompts
{
    [Preserve]
    [System.Serializable]
    [CreateAssetMenu(fileName = "CodePrompt", menuName = "DLS/Code Prompt")]
    public class CodePrompt : ScriptableObject
    {
        [SerializeField] protected ProgrammingLanguages programmingLanguage;

        [SerializeField] protected ProgrammingCategories category;

        [SerializeField, TextArea(10, 50)] protected string questionPrompt;

        [SerializeField] protected int answer;

        [SerializeField] protected int difficulty;

        [SerializeField, TextArea(10, 50)] protected string sampleCode;

        [SerializeField, TextArea(10, 50)] protected string hint;

        [SerializeField] protected List<string> tags;

        [SerializeField, TextArea(10, 50)] protected string explanation;

        [SerializeField] protected bool learned;

        public ProgrammingLanguages ProgrammingLanguage
        {
            get => programmingLanguage;
            set => programmingLanguage = value;
        }

        public ProgrammingCategories Category
        {
            get => category;
            set => category = value;
        }

        public string QuestionPrompt
        {
            get => questionPrompt;
            set => questionPrompt = value;
        }

        public int Answer
        {
            get => answer;
            set => answer = value;
        }

        public int Difficulty
        {
            get => difficulty;
            set => difficulty = value;
        }

        public string SampleCode
        {
            get => sampleCode;
            set => sampleCode = value;
        }

        public string Hint
        {
            get => hint;
            set => hint = value;
        }

        public List<string> Tags
        {
            get => tags;
            set => tags = value;
        }

        public string Explanation
        {
            get => explanation;
            set => explanation = value;
        }

        public bool Learned
        {
            get => learned;
            set => learned = value;
        }
    }
}