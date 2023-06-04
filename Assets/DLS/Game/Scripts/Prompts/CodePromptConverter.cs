using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace DLS.Game.Scripts.Prompts
{
    public class CodePromptConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(CodePrompt);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            CodePrompt codePrompt = (CodePrompt)value;
            JObject jsonObject = JObject.FromObject(codePrompt);
            jsonObject.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            CodePrompt codePrompt = ScriptableObject.CreateInstance<CodePrompt>();
            serializer.Populate(jsonObject.CreateReader(), codePrompt);
            return codePrompt;
        }
    }
}