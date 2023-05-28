using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Scripting;

[Preserve]
[System.Serializable]
[CreateAssetMenu(fileName = "CodePrompt", menuName = "DLS/Code Prompt")]
public class CodePrompt : ScriptableObject
{
    [SerializeField] protected ProgrammingLanguages programmingLanguage;
    [SerializeField] protected ProgrammingCategories category;
    [SerializeField, TextArea(10,50)] protected string questionPrompt;
    [SerializeField] protected int answer;
    [SerializeField] protected int difficulty;
    [SerializeField,TextArea(10,50)] protected string sampleCode;
    [SerializeField, TextArea(10,50)] protected string hint;
    [SerializeField] protected List<string> tags;
    [SerializeField, TextArea(10,50)] protected string explanation;
    [SerializeField] protected bool learned;

    public ProgrammingLanguages ProgrammingLanguage => programmingLanguage;
    public ProgrammingCategories Category => category;
    public string QuestionPrompt => questionPrompt;
    public int Answer => answer;
    public int Difficulty => difficulty;
    public string SampleCode => sampleCode;
    public string Hint => hint;
    public List<string> Tags => tags;
    public string Explanation => explanation;
    public bool Learned { get => learned; set => learned = value; }
}