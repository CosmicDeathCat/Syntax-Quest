using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DLS.Game.Scripts.Enums;
using DLS.Game.Scripts.Player;
using DLS.Game.Scripts.PlayerPrefsPlus;
using DLS.Game.Scripts.Utility;
using Newtonsoft.Json;
using PlayerPrefsPlus;
using UnityEngine;
using static UnityEngine.Resources;

namespace DLS.Game.Scripts.Prompts
{
    public class CodePromptGenerator : MonoBehaviour
    {
        public static CodePromptGenerator Instance;

        [SerializeField] private List<CodePrompt> allCodePrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> cPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> cppPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> csharpPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> cssPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> goPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> htmlPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> javaPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> javascriptPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> perlPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> phpPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> pythonPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> rPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> rubyPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> rustPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> sqlPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> typescriptPrompts = new List<CodePrompt>();
        [SerializeField] private List<CodePrompt> visualbasicPrompts = new List<CodePrompt>();

        private PlayerController player;

        public List<CodePrompt> AllCodePrompts
        {
            get => allCodePrompts;
            set => allCodePrompts = value;
        }

        public List<CodePrompt> CPrompts
        {
            get => cPrompts;
            set => cPrompts = value;
        }

        public List<CodePrompt> CppPrompts
        {
            get => cppPrompts;
            set => cppPrompts = value;
        }

        public List<CodePrompt> CSharpPrompts
        {
            get => csharpPrompts;
            set => csharpPrompts = value;
        }

        public List<CodePrompt> CssPrompts
        {
            get => cssPrompts;
            set => cssPrompts = value;
        }

        public List<CodePrompt> GoPrompts
        {
            get => goPrompts;
            set => goPrompts = value;
        }

        public List<CodePrompt> HtmlPrompts
        {
            get => htmlPrompts;
            set => htmlPrompts = value;
        }

        public List<CodePrompt> JavaPrompts
        {
            get => javaPrompts;
            set => javaPrompts = value;
        }

        public List<CodePrompt> JavascriptPrompts
        {
            get => javascriptPrompts;
            set => javascriptPrompts = value;
        }

        public List<CodePrompt> PerlPrompts
        {

            get => perlPrompts;
            set => perlPrompts = value;
        }

        public List<CodePrompt> PhpPrompts
        {
            get => phpPrompts;
            set => phpPrompts = value;
        }

        public List<CodePrompt> PythonPrompts
        {
            get => pythonPrompts;
            set => pythonPrompts = value;
        }

        public List<CodePrompt> RPrompts
        {
            get => rPrompts;
            set => rPrompts = value;
        }

        public List<CodePrompt> RubyPrompts
        {
            get => rubyPrompts;
            set => rubyPrompts = value;
        }

        public List<CodePrompt> RustPrompts
        {
            get => rustPrompts;
            set => rustPrompts = value;
        }

        public List<CodePrompt> SqlPrompts
        {
            get => sqlPrompts;
            set => sqlPrompts = value;
        }

        public List<CodePrompt> TypescriptPrompts
        {
            get => typescriptPrompts;
            set => typescriptPrompts = value;
        }

        public List<CodePrompt> VisualbasicPrompts
        {
            get => visualbasicPrompts;
            set => visualbasicPrompts = value;
        }

        public async void GenerateJsonFiles()
        {
            List<CodePrompt> prompts = null;
            string jsonContent = string.Empty;
            (bool success, string json) writeJson;
            try
            {
                if (player != null)
                {
                    switch (player.AvailableLanguages)
                    {
                        case ProgrammingLanguages.None:
                            break;
                        case ProgrammingLanguages.CSharp:
                            string folderName = "CodePrompts";
                            string jsonFileName = ProgrammingLanguages.CSharp.ToString()+ "Prompts" + ".json";
                            string jsonFolderPath = Path.Combine(Application.streamingAssetsPath, folderName);
                            string jsonFilePath = Path.Combine(jsonFolderPath, jsonFileName);

        #if UNITY_EDITOR || UNITY_STANDALONE_WIN
                            prompts = LoadAll<CodePrompt>($"CodePrompts/{ProgrammingLanguages.CSharp}").ToList();
                            jsonContent = JsonConvert.SerializeObject(prompts, Formatting.Indented, new CodePromptConverter());
                            
                            if (File.Exists(jsonFilePath))
                            {
                                string existingJsonContent = File.ReadAllText(jsonFilePath);
                                if (existingJsonContent != jsonContent) // If the content has changed
                                {
                                    writeJson = await SQUtilities.WriteJsonAsync(BasePath.Addressables, jsonFilePath, jsonContent);
                                    if (writeJson.success)
                                    {
                                        Debug.Log($"C# Prompts JSON being overwritten: {jsonFilePath}");
                                    }
                                    else
                                    {
                                        Debug.LogWarning($"Failed to overwrite JSON at filepath: {jsonFilePath}");
                                    }
                                }
                            }
                            else
                            {
                                writeJson = await SQUtilities.WriteJsonAsync(BasePath.Addressables, jsonFilePath, jsonContent);
                                if (writeJson.success)
                                {
                                    Debug.Log($"C# Prompts JSON being created: {jsonFilePath}");
                                }
                                else
                                {
                                    Debug.LogWarning($"Failed to write JSON to filepath: {jsonFilePath}");
                                }
                            }
        #else
                            var loadJson = await SQUtilities.LoadJsonAsync(BasePath.Addressables, jsonFilePath);
                            if (loadJson.success)
                            {
                                jsonContent = loadJson.json;
                                prompts = JsonConvert.DeserializeObject<List<CodePrompt>>(jsonContent, new CodePromptConverter());
                                Debug.Log($"C# Prompts JSON being loaded successfully: {jsonFilePath}");
                            }
                            else
                            {
                                Debug.LogWarning($"Failed to load JSON from filepath: {jsonFilePath}");
                            }
        #endif

                            if (prompts != null && prompts.Count > 0)
                            {
                                allCodePrompts.AddRange(prompts);
                                csharpPrompts.AddRange(prompts);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message, this);
            }
        }



        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
                player = FindObjectOfType<PlayerController>();
                GenerateJsonFiles();
            }
        }
    }
}
