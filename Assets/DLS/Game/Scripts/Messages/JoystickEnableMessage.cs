namespace DLS.Game.Scripts.Messages
{
    public struct JoystickEnableMessage
    {
        public bool Enabled { get; }

        public JoystickEnableMessage(bool enabled)
        {
            Enabled = enabled;
        }
    }
}