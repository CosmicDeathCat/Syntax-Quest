using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PlayerPrefsDB : MonoBehaviour
{
    public static PlayerPrefsDB instance;
    [SerializeField] private bool enableGridOverlay = true;
    private PlayerPrefsPlus playerPrefsPlus = null;
    
    public bool EnableGridOverlay
    {
        get => enableGridOverlay;
        set => enableGridOverlay = value;
    }

    public PlayerPrefsPlus PlayerPrefsPlus
    {
        get => playerPrefsPlus;
        set => playerPrefsPlus = value;
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            playerPrefsPlus = new PlayerPrefsPlus(this);
            playerPrefsPlus.OpenAsync(IsOpen);
        }
    }

    public void IsOpen(bool ok)
    {
        if (ok)
        {
            playerPrefsPlus.GetPlayerByName(Prefs.PlayerName);
            playerPrefsPlus.Set(Prefs.EnableGridOverlay, enableGridOverlay);
            playerPrefsPlus.Close();
        }
        else
        {
            Debug.Log("Database unavailable");
        }
    }

    // private void OnValidate()
    // {
    //     if (playerPrefsPlus != null)
    //     {
    //         playerPrefsPlus.GetPlayerByName(Prefs.PlayerName);
    //         playerPrefsPlus.Set(Prefs.EnableGridOverlay, enableGridOverlay);
    //         playerPrefsPlus.Close();
    //     }
    // }
}