using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

public class BaseEnemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            var randomPrompt = CodePromptGenerator.Instance.CsharpPrompts[Random.Range(0, CodePromptGenerator.Instance.CsharpPrompts.Count)];
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
