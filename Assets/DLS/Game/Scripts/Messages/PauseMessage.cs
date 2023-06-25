namespace DLS.Game.Scripts.Messages
{
    public struct PauseMessage
    {
        public bool Paused { get; }

        public PauseMessage(bool paused)
        {
            Paused = paused;
        }
    }
}