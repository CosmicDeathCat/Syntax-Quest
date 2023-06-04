using DLS.Game.Scripts.PlayerPrefsPlus;
using PlayerPrefsPlus;
using UnityEditor;

namespace _Game.Scripts.PlayerPrefsPlus.Editor
{
    [CustomEditor(typeof(PlayerPrefsController))]
    public class PlayerPrefsControllerEditor : UnityEditor.Editor
    {
        private SerializedProperty enableGridOverlay;
        private bool previousEnableGridOverlay;

        private SerializedProperty enableOnScreenJoystick;
        private bool previousEnableOnScreenJoystick;

        private void OnEnable()
        {
            enableGridOverlay = serializedObject.FindProperty("enableGridOverlay");
            previousEnableGridOverlay = enableGridOverlay.boolValue;

            enableOnScreenJoystick = serializedObject.FindProperty("enableOnScreenJoystick");
            previousEnableOnScreenJoystick = enableOnScreenJoystick.boolValue;
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(enableGridOverlay);
            EditorGUILayout.PropertyField(enableOnScreenJoystick);

            serializedObject.ApplyModifiedProperties();

            if (previousEnableGridOverlay != enableGridOverlay.boolValue)
            {
                PPPlus.SetBool(Prefs.EnableGridOverlay, enableGridOverlay.boolValue);
                previousEnableGridOverlay = enableGridOverlay.boolValue;
            }

            if (previousEnableOnScreenJoystick != enableOnScreenJoystick.boolValue)
            {
                PPPlus.SetBool(Prefs.EnableOnScreenJoystick, enableOnScreenJoystick.boolValue);
                previousEnableOnScreenJoystick = enableOnScreenJoystick.boolValue;
            }
        }
    }
}