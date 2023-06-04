using PlayerPrefsPlus;
using UnityEngine;

namespace DLS.Game.Scripts.PlayerPrefsPlus
{
    [ExecuteInEditMode]
    public class PlayerPrefsController : MonoBehaviour
    {
        public static PlayerPrefsController instance;
        [SerializeField] private bool enableGridOverlay = true;
        [SerializeField] private bool enableOnScreenJoystick = false;

        public bool EnableGridOverlay
        {
            get => enableGridOverlay;
            set => enableGridOverlay = value;
        }

        public bool EnableOnScreenJoystick
        {
            get => enableOnScreenJoystick;
            set => enableOnScreenJoystick = value;
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
            }
        }

        private void Start()
        {
#if UNITY_ANDROID || UNITY_IOS
            enableOnScreenJoystick = true;
#endif

            PPPlus.SetBool(Prefs.EnableGridOverlay, enableGridOverlay);
            PPPlus.SetBool(Prefs.EnableOnScreenJoystick, enableOnScreenJoystick);
        }
    }
}