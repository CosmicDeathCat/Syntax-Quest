using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class NpcBase : MonoBehaviour
{
    [SerializeField] private int promptDifficulty = 1;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            var learningPrompt = CodePromptGenerator.Instance.CsharpPrompts.Select(x=> x).Where(x=> !x.Learned && x.Difficulty <= promptDifficulty).ToList();
            if (learningPrompt.Count > 0)
            {
                var randomPrompt = learningPrompt[Random.Range(0, learningPrompt.Count)];
                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () =>
                {
                    randomPrompt.Learned = true;
                });
            }
            else
            {
                learningPrompt = CodePromptGenerator.Instance.CsharpPrompts.Select(x=> x).Where(x=> x.Learned && x.Difficulty <= promptDifficulty).ToList();
                var randomPrompt = learningPrompt[Random.Range(0, learningPrompt.Count)];
                PopupDisplayUI.instance.ShowTextPopup(randomPrompt.Explanation, () =>
                {
                    
                });
            }

        }
    }
}
