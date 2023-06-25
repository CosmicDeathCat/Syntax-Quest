using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
#endif
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.Networking;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace DLS.Game.Scripts.Utility
{
    public static class SQUtilities
    {
        public static async Task<(bool success, string json)> LoadJsonAsync(BasePath basePath, string path)
        {
            try
            {
                string jsonContent = string.Empty;
                bool success = false;

                if (basePath == BasePath.StreamingAssets)
                {
                    string fullPath = GetFullPath(basePath, path);

                    if (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer)
                    {
                        // Read the file directly from the StreamingAssets folder in the Unity Editor or Windows Player
                        jsonContent = File.ReadAllText(fullPath);
                        success = true;
                    }
                    else if (Application.platform == RuntimePlatform.Android)
                    {
                        // Use Unity's StreamingAssets API to read the file on Android
                        UnityWebRequest www = UnityWebRequest.Get(Path.Combine(Application.streamingAssetsPath, path));
                        www.SendWebRequest();

                        while (!www.isDone) { }

                        if (string.IsNullOrEmpty(www.error))
                        {
                            jsonContent = www.downloadHandler.text;
                            success = true;
                        }
                        else
                        {
                            Debug.LogError($"Failed to load JSON from StreamingAssets: {www.error}");
                        }
                    }
                    else if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.WebGLPlayer)
                    {
                        // Use UnityWebRequest to load the file on iOS and WebGL
                        string url = Path.Combine(Application.streamingAssetsPath, path);

                        UnityWebRequest www = UnityWebRequest.Get(url);
                        www.SendWebRequest();

                        while (!www.isDone) { }

                        if (string.IsNullOrEmpty(www.error))
                        {
                            jsonContent = www.downloadHandler.text;
                            success = true;
                        }
                        else
                        {
                            Debug.LogError($"Failed to load JSON from StreamingAssets: {www.error}");
                        }
                    }
                }
                else if (basePath == BasePath.Addressables)
                {
                    AsyncOperationHandle<TextAsset> handle = Addressables.LoadAssetAsync<TextAsset>(Path.GetFileNameWithoutExtension(path));
                    await handle.Task;

                    if (handle.Status == AsyncOperationStatus.Succeeded)
                    {
                        TextAsset jsonAsset = handle.Result;
                        return (true, jsonAsset.text);
                    }
                    else
                    {
                        Debug.LogWarning("Unable to load Addressable");
                        return (false, string.Empty);
                    }
                }

                return (success, jsonContent);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error while loading JSON: {e.Message}");
                return (false, string.Empty);
            }
        }
        
        public static async Task<(bool success, string message)> WriteJsonAsync(BasePath basePath, string path, string jsonContent)
        {
            try
            {
                string fullPath = GetFullPath(basePath, path);

                // Create directories for the path if they don't exist
                string directoryPath = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

        #if UNITY_EDITOR
                if (basePath == BasePath.StreamingAssets && (Application.isEditor || Application.platform == RuntimePlatform.WindowsPlayer))
                {
                    // Copy the file to the streaming assets folder in the Unity Editor or Windows Player
                    string streamingAssetsPath = GetFullPath(BasePath.StreamingAssets, path);
                    await File.WriteAllTextAsync(streamingAssetsPath, jsonContent);
                }
                else if (basePath == BasePath.Addressables && (Application.isEditor || Application.isPlaying))
                {
                    // Write the file directly to the specified base path
                    await File.WriteAllTextAsync(fullPath, jsonContent);

                    // Mark the file as addressable through the Addressable Asset System
                    string address = Path.GetFileNameWithoutExtension(fullPath);

                    // Get the AddressableAssetSettings
                    var settings = AddressableAssetSettingsDefaultObject.Settings;

                    if (settings != null)
                    {
                        var group = settings.DefaultGroup;

                        if (group != null)
                        {
                            // Make sure the asset database is up to date
                            AssetDatabase.Refresh();

                            // Get the relative path
                            string relativePath = fullPath.Replace(Application.dataPath, "Assets");

                            // Create or move an entry for the asset
                            var guid = AssetDatabase.AssetPathToGUID(relativePath);
                            if (!string.IsNullOrEmpty(guid))
                            {
                                var entry = settings.CreateOrMoveEntry(guid, group);

                                if (entry != null)
                                {
                                    entry.SetLabel("Addressable", true);
                                }
                                else
                                {
                                    throw new Exception($"Failed to create or move AddressableAssetEntry for address: {address}");
                                }
                            }
                            else
                            {
                                throw new Exception($"Failed to find GUID for path: {relativePath}");
                            }
                        }
                    }
                }
        #endif

                // Write the file directly to the specified base path
                await File.WriteAllTextAsync(fullPath, jsonContent);

                return (true, jsonContent);
            }
            catch (Exception e)
            {
                return (false, e.Message);
            }
        }



        public static (bool success, string[] files, string[] copiedPaths) CopyFiles(BasePath sourceBasePath, BasePath destinationBasePath, params string[] filePaths)
        {
            try
            {
                List<string> copiedFiles = new List<string>();
                List<string> copiedPaths = new List<string>();

                foreach (string path in filePaths)
                {
                    string sourcePath = GetFullPath(sourceBasePath, path);
                    string destinationPath = GetFullPath(destinationBasePath, path);
                    File.Copy(sourcePath, destinationPath);

                    copiedFiles.Add(Path.GetFileName(path));
                    copiedPaths.Add(destinationPath);
                }

                return (true, copiedFiles.ToArray(), copiedPaths.ToArray());
            }
            catch (Exception e)
            {
                return (false, null, null);
            }
        }

        private static string GetFullPath(BasePath basePath, string path)
        {
            switch (basePath)
            {
                case BasePath.GameDirectory:
                    return Path.Combine(Application.dataPath, "DLS", "Game", path);
                case BasePath.PersistentData:
                    return Path.Combine(Application.persistentDataPath, path);
                case BasePath.StreamingAssets:
                    return Path.Combine(Application.streamingAssetsPath, path);
                case BasePath.DataPath:
                    return Path.Combine(Application.dataPath, path);
                case BasePath.TemporaryCache:
                    return Path.Combine(Application.temporaryCachePath, path);
                case BasePath.Addressables:
                    // return Path.Combine("Assets", "DLS", "Game", path)
                    return Path.Combine(Application.dataPath, "StreamingAssets", "DLS", "Game", path);
                default:
                    throw new ArgumentException("Invalid base path");
            }
        }

        #if UNITY_EDITOR
        public static async Task<AddressableAssetEntry> GetAddressableAssetEntry(string address)
        {
            if (Application.isEditor)
            {
                var locations = await Addressables.LoadResourceLocationsAsync(address).Task;
                if (locations != null && locations.Count > 0)
                {
                    var entry = await Addressables.LoadAssetAsync<AddressableAssetEntry>(locations[0]).Task;
                    return entry;
                }
            }
            return null;
        }
        #endif

    }
}