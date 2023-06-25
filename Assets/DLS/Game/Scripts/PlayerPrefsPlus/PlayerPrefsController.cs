using PlayerPrefsPlus;
using UnityEngine;
using UnityEngine.Serialization;

namespace DLS.Game.Scripts.PlayerPrefsPlus
{
    [ExecuteInEditMode]
    public class PlayerPrefsController : MonoBehaviour
    {
        public static PlayerPrefsController instance;

        [SerializeField] private bool enableGridOverlay = true;
        [SerializeField] private bool enableOnScreenJoystick = false;

        public bool EnableGridOverlay { get => enableGridOverlay; set => enableGridOverlay = value; }

        public bool EnableOnScreenJoystick { get => enableOnScreenJoystick; set => enableOnScreenJoystick = value; }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }
    }
}