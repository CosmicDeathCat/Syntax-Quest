using System.Collections.Generic;
using System.Linq;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.Prompts;
using DLS.Game.Scripts.UI;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DLS.Game.Scripts.Npcs
{
    public class BaseNpc : MonoBehaviour
    {
        [SerializeField] private int promptDifficulty = 1;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                var player = col.gameObject.GetComponent<PlayerController>();

                if (player != null)
                {
                    List<CodePrompt> learningPrompts;
                    switch (player.CurrentLanguage)
                    {
                        case ProgrammingLanguages.None:
                            break;
                        case ProgrammingLanguages.C:
                            learningPrompts = CodePromptGenerator.Instance.CPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.CPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Cpp:
                            learningPrompts = CodePromptGenerator.Instance.CppPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.CppPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.CSharp:
                            learningPrompts = CodePromptGenerator.Instance.CSharpPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.CSharpPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Css:
                            learningPrompts = CodePromptGenerator.Instance.CssPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.CssPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Go:
                            learningPrompts = CodePromptGenerator.Instance.GoPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.GoPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Html:
                            learningPrompts = CodePromptGenerator.Instance.HtmlPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.HtmlPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Java:
                            learningPrompts = CodePromptGenerator.Instance.JavaPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.JavaPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Javascript:
                            learningPrompts = CodePromptGenerator.Instance.JavascriptPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.JavascriptPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Perl:
                            learningPrompts = CodePromptGenerator.Instance.PerlPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.PerlPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Php:
                            learningPrompts = CodePromptGenerator.Instance.PhpPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.PhpPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Python:
                            learningPrompts = CodePromptGenerator.Instance.PythonPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.PythonPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.R:
                            learningPrompts = CodePromptGenerator.Instance.RPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.RPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Ruby:
                            learningPrompts = CodePromptGenerator.Instance.RubyPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.RubyPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Rust:
                            learningPrompts = CodePromptGenerator.Instance.RustPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.RustPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Sql:
                            learningPrompts = CodePromptGenerator.Instance.SqlPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.SqlPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Typescript:
                            learningPrompts = CodePromptGenerator.Instance.TypescriptPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.TypescriptPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                        case ProgrammingLanguages.Visualbasic:
                            learningPrompts = CodePromptGenerator.Instance.VisualbasicPrompts.Select(x => x)
                                .Where(x => !x.Learned && x.Difficulty <= promptDifficulty).ToList();
                            if (learningPrompts.Count > 0)
                            {
                                var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation,
                                    () => { randomPrompt.Learned = true; });
                            }
                            else
                            {
                                learningPrompts = CodePromptGenerator.Instance.VisualbasicPrompts.Select(x => x)
                                    .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                                if (learningPrompts.Count > 0)
                                {
                                    var randomPrompt = learningPrompts[Random.Range(0, learningPrompts.Count)];
                                    PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () => { });
                                }
                            }

                            break;
                    }
                }
            }
        }
    }
}