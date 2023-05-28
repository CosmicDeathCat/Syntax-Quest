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
        if (col.CompareTag("Player"))
        {
            var learningPrompt = CodePromptGenerator.Instance.CsharpPrompts.Select(x=> x).Where(x=> x.Learned && x.Difficulty <= promptDifficulty).ToList();
            var randomPrompt = learningPrompt[Random.Range(0, learningPrompt.Count)];
            PopupDisplayUI.instance.ShowOptionsPopup(randomPrompt.QuestionPrompt, () =>
            {
                if (randomPrompt.Answer == 1)
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => {});
                }
                else
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                }
            }, () =>
            {
                if (randomPrompt.Answer == 2)
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => {});
                }
                else
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                }
            }, () =>
            {
                if (randomPrompt.Answer == 3)
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => {});
                }
                else
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                }
            }, () =>
            {
                if (randomPrompt.Answer == 4)
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("CORRECT!", () => {});
                }
                else
                {
                    PopupDisplayUI.instance.ShowConfirmPopup("INCORRECT!", () => {});
                }
            });
           
        }
    }
}
