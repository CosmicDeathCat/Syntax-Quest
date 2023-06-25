using System.Collections.Generic;
using System.Linq;
using DLS.Core;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.UI;
using UnityEngine;

namespace DLS.Game.Scripts.Prompts
{
    public static class CodePromptDisplay
    {
        public static void ShowLearningPrompt(PlayerController player, int promptDifficulty)
        {
            if (player == null) return;
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

        public static void ShowQuizPrompt(PlayerController player, int promptDifficulty)
        {
            if(player == null) return;;
            List<CodePrompt> learningPrompt = null;
            switch (player.CurrentLanguage)
            {
                case ProgrammingLanguages.None:
                    learningPrompt = new List<CodePrompt>();
                    break;
                case ProgrammingLanguages.C:
                    learningPrompt = CodePromptGenerator.Instance.CPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Cpp:
                    learningPrompt = CodePromptGenerator.Instance.CppPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.CSharp:
                    learningPrompt = CodePromptGenerator.Instance.CSharpPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Css:
                    learningPrompt = CodePromptGenerator.Instance.CssPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Go:
                    learningPrompt = CodePromptGenerator.Instance.GoPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Html:
                    learningPrompt = CodePromptGenerator.Instance.HtmlPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Java:
                    learningPrompt = CodePromptGenerator.Instance.JavaPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Javascript:
                    learningPrompt = CodePromptGenerator.Instance.JavascriptPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Perl:
                    learningPrompt = CodePromptGenerator.Instance.PerlPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Php:
                    learningPrompt = CodePromptGenerator.Instance.PhpPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Python:
                    learningPrompt = CodePromptGenerator.Instance.PythonPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.R:
                    learningPrompt = CodePromptGenerator.Instance.RPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Ruby:
                    learningPrompt = CodePromptGenerator.Instance.RubyPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Rust:
                    learningPrompt = CodePromptGenerator.Instance.RustPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Sql:
                    learningPrompt = CodePromptGenerator.Instance.SqlPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Typescript:
                    learningPrompt = CodePromptGenerator.Instance.TypescriptPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
                    break;
                case ProgrammingLanguages.Visualbasic:
                    learningPrompt = CodePromptGenerator.Instance.VisualbasicPrompts.Select(x => x)
                        .Where(x => x.Learned && x.Difficulty <= promptDifficulty).ToList();
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