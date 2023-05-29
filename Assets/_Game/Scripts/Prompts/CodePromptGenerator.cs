using System;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.VisualScripting;

public class CodePromptGenerator : MonoBehaviour
{
    public static CodePromptGenerator Instance;
    
    [SerializeField] private List<CodePrompt> allCodePrompts = new();
    [SerializeField] private List<CodePrompt> cPrompts = new();
    [SerializeField] private List<CodePrompt> cppPrompts = new();
    [SerializeField] private List<CodePrompt> csharpPrompts = new();
    [SerializeField] private List<CodePrompt> cssPrompts = new();
    [SerializeField] private List<CodePrompt> goPrompts = new();
    [SerializeField] private List<CodePrompt> htmlPrompts = new();
    [SerializeField] private List<CodePrompt> javaPrompts = new();
    [SerializeField] private List<CodePrompt> javascriptPrompts = new();
    [SerializeField] private List<CodePrompt> perlPrompts = new();
    [SerializeField] private List<CodePrompt> phpPrompts = new();
    [SerializeField] private List<CodePrompt> pythonPrompts = new();
    [SerializeField] private List<CodePrompt> rPrompts = new();
    [SerializeField] private List<CodePrompt> rubyPrompts = new();
    [SerializeField] private List<CodePrompt> rustPrompts = new();
    [SerializeField] private List<CodePrompt> sqlPrompts = new();
    [SerializeField] private List<CodePrompt> typescriptPrompts = new();
    [SerializeField] private List<CodePrompt> visualbasicPrompts = new();
    
    public List<CodePrompt> AllCodePrompts { get => allCodePrompts; set => allCodePrompts = value; }
    public List<CodePrompt> CPrompts { get => cPrompts; set => cPrompts = value; }
    public List<CodePrompt> CppPrompts { get => cppPrompts; set => cppPrompts = value; }
    public List<CodePrompt> CSharpPrompts { get => csharpPrompts; set => csharpPrompts = value; }
    public List<CodePrompt> CssPrompts { get => cssPrompts; set => cssPrompts = value; }
    public List<CodePrompt> GoPrompts { get => goPrompts; set => goPrompts = value; }
    public List<CodePrompt> HtmlPrompts { get => htmlPrompts; set => htmlPrompts = value; }
    public List<CodePrompt> JavaPrompts { get => javaPrompts; set => javaPrompts = value; }
    public List<CodePrompt> JavascriptPrompts { get => javascriptPrompts; set => javascriptPrompts = value; }
    public List<CodePrompt> PerlPrompts { get => perlPrompts; set => perlPrompts = value; }
    public List<CodePrompt> PhpPrompts { get => phpPrompts; set => phpPrompts = value; }
    public List<CodePrompt> PythonPrompts { get => pythonPrompts; set => pythonPrompts = value; }
    public List<CodePrompt> RPrompts { get => rPrompts; set => rPrompts = value; }
    public List<CodePrompt> RubyPrompts { get => rubyPrompts; set => rubyPrompts = value; }
    public List<CodePrompt> RustPrompts { get => rustPrompts; set => rustPrompts = value; }
    public List<CodePrompt> SqlPrompts { get => sqlPrompts; set => sqlPrompts = value; }
    public List<CodePrompt> TypescriptPrompts { get => typescriptPrompts; set => typescriptPrompts = value; }
    public List<CodePrompt> VisualbasicPrompts { get => visualbasicPrompts; set => visualbasicPrompts = value; }
    
    
    public void GenerateJsonFiles()
    {
        try
        {
            // Get all subdirectories within the Resources folder
            string[] subdirectories = Directory.GetDirectories(Path.Combine(Application.dataPath, "_Game","Resources", "CodePrompts"));

            foreach (string subdirectory in subdirectories)
            {
                // Extract the programming language from the folder name
                string programmingLanguage = Path.GetFileName(subdirectory);

                // Load all CodePrompt objects in the current programming language folder
                CodePrompt[] prompts = Resources.LoadAll<CodePrompt>("CodePrompts/" + programmingLanguage);


                
                //Adding the prompts to all code prompts
                allCodePrompts.AddRange(prompts);

                switch (programmingLanguage.ToLower())
                {
                    case "c":
                        cPrompts.AddRange(prompts);
                        break;
                    case "cpp":
                        cppPrompts.AddRange(prompts);
                        break;
                    case "csharp":
                        csharpPrompts.AddRange(prompts);
                        break;
                    case "css":
                        cssPrompts.AddRange(prompts);
                        break;
                    case "go":
                        goPrompts.AddRange(prompts);
                        break;
                    case "html":
                        htmlPrompts.AddRange(prompts);
                        break;
                    case "java":
                        javaPrompts.AddRange(prompts);
                        break;
                    case "javascript":
                        javascriptPrompts.AddRange(prompts);
                        break;
                    case "perl":
                        perlPrompts.AddRange(prompts);
                        break;
                    case "php":
                        phpPrompts.AddRange(prompts);
                        break;
                    case "python":
                        pythonPrompts.AddRange(prompts);
                        break;
                    case "r":
                        rPrompts.AddRange(prompts);
                        break;
                    case "ruby":
                        rubyPrompts.AddRange(prompts);
                        break;
                    case "rust":
                        rustPrompts.AddRange(prompts);
                        break;
                    case "sql":
                        sqlPrompts.AddRange(prompts);
                        break;
                    case "typescript":
                        typescriptPrompts.AddRange(prompts);
                        break;
                    case "visualbasic":
                        visualbasicPrompts.AddRange(prompts);
                        break;
                }

                // Generate JSON content
                string jsonContent = JsonConvert.SerializeObject(prompts, Formatting.Indented);

                // Define the file path
                string filePath = Path.Combine(subdirectory, programmingLanguage + ".json");

                // Create the directory if it doesn't exist
                Directory.CreateDirectory(subdirectory);
                
                // Save JSON content to a file1
                File.WriteAllText(filePath, jsonContent);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
            
        }
    }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
    
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
            GenerateJsonFiles();
        } 
    }
}