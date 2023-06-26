using System;
using System.Collections;
using System.Collections.Generic;
using PlayerPrefsPlus;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuController : MonoBehaviour
{
    [field: SerializeField] public Toggle EnableGridToggle { get; set; }
    [field: SerializeField] public Toggle EnableOnScreenJoystickToggle { get; set; }
    [field: SerializeField] public Scrollbar MasterVolumeScrollbar { get; set; }
    [field: SerializeField] public TMP_Text MasterVolumeText { get; set; }
    [field: SerializeField] public Scrollbar SFXVolumeScrollbar { get; set; }
    [field: SerializeField] public TMP_Text SFXVolumeText { get; set; }
    [field: SerializeField] public Scrollbar BGMVolumeScrollbar { get; set; }
    [field: SerializeField] public TMP_Text BGMVolumeText { get; set; }

    private void Start()
    {
        EnableGridToggle.isOn = PPPlus.GetBool("EnableGridOverlay");
        EnableOnScreenJoystickToggle.isOn = PPPlus.GetBool("EnableOnScreenJoystick");
        var masterVolume = Mathf.Pow(10, PPPlus.GetFloat("masterVolume") / 20f);
        var sfxVolume = Mathf.Pow(10, PPPlus.GetFloat("effectsVolume") / 20f);
        var bgmVolume = Mathf.Pow(10, PPPlus.GetFloat("musicVolume") / 20f);
        MasterVolumeScrollbar.value = masterVolume;
        SFXVolumeScrollbar.value = sfxVolume;
        BGMVolumeScrollbar.value = bgmVolume;
    }

    public void UpdateMasterVolumeText(float volume)
    {
        MasterVolumeText.text = $"Master Volume: {volume * 100}%";
    }
    
    public void UpdateSfxVolumeText(float volume)
    {
        SFXVolumeText.text = $"SFX Volume: {volume * 100}%";
    }
    
    public void UpdateBgmVolumeText(float volume)
    {
        BGMVolumeText.text = $"BGM Volume: {volume * 100}%";
    }

    public void EnableGrid(bool enabled)
    {
        PPPlus.SetBool("EnableGridOverlay", enabled);
    }

    public void EnableOnScreenJoystick(bool enabled)
    {
        PPPlus.SetBool("EnableOnScreenJoystick", enabled);
    }
}
