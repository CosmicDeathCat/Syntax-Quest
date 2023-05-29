using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private int promptDifficulty = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        List<CodePrompt> learningPrompt = null;
        if (col.CompareTag("Player"))
        {
            var player = col.gameObject.GetComponent<PlayerController>();
            if (player != null)
            {
                switch (player.CurrentLanguage)
                {
                    case ProgrammingLanguages.None:
                        learningPrompt = new List<CodePrompt>();
                        break;
                    case ProgrammingLanguages.C:
                        learningPrompt = CodePromptGenerator.Instance.CPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Cpp:
                        learningPrompt = CodePromptGenerator.Instance.CppPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Csharp:
                        learningPrompt = CodePromptGenerator.Instance.CSharpPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Css:
                        learningPrompt = CodePromptGenerator.Instance.CssPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Go:
                        learningPrompt = CodePromptGenerator.Instance.GoPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Html:
                        learningPrompt = CodePromptGenerator.Instance.HtmlPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Java:
                        learningPrompt = CodePromptGenerator.Instance.JavaPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Javascript:
                        learningPrompt = CodePromptGenerator.Instance.JavascriptPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Perl:
                        learningPrompt = CodePromptGenerator.Instance.PerlPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Php:
                        learningPrompt = CodePromptGenerator.Instance.PhpPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Python:
                        learningPrompt = CodePromptGenerator.Instance.PythonPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.R:
                        learningPrompt = CodePromptGenerator.Instance.RPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Ruby:
                        learningPrompt = CodePromptGenerator.Instance.RubyPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Rust:
                        learningPrompt = CodePromptGenerator.Instance.RustPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Sql:
                        learningPrompt = CodePromptGenerator.Instance.SqlPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Typescript:
                        learningPrompt = CodePromptGenerator.Instance.TypescriptPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                    case ProgrammingLanguages.Visualbasic:
                        learningPrompt = CodePromptGenerator.Instance.VisualbasicPrompts.Select(x => x).Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                        break;
                }

                if (learningPrompt.Count <= 0)
                {
                    return;
                }

                var randomPrompt = learningPrompt[Random.Range(0, learningPrompt.Count)];
                PopupDisplayUI.instance.ShowOptionsPopup(randomPrompt.QuestionPrompt, () =>
                {
                    if (randomPrompt.Answer == 1)
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => { });
                    }
                    else
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => { });
                    }
                }, () =>
                {
                    if (randomPrompt.Answer == 2)
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => { });
                    }
                    else
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => { });
                    }
                }, () =>
                {
                    if (randomPrompt.Answer == 3)
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => { });
                    }
                    else
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => { });
                    }
                }, () =>
                {
                    if (randomPrompt.Answer == 4)
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => { });
                    }
                    else
                    {
                        PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => { });
                    }
                });
            }




        }
    }
}
