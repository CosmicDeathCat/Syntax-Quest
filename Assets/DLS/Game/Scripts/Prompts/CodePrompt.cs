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
        [field: SerializeField] public ProgrammingLanguages ProgrammingLanguage { get; set; }
        [field: SerializeField] public ProgrammingCategories Category { get; set; }
        [field: SerializeField] public string QuestionPrompt { get; set; }
        [field: SerializeField] public List<QuizOption> Options { get; set; }
        [field: SerializeField] public int Difficulty { get; set; }
        [field: SerializeField] public string SampleCode { get; set; }
        [field: SerializeField] public string Hint { get; set; }
        [field: SerializeField] public List<string> Tags { get; set; }
        [field: SerializeField] public string Explanation { get; set; }
        [field: SerializeField] public bool Learned { get; set; }
    }
}