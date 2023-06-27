using UnityEngine;

namespace DLS.Game.Scripts.GameStates
{
    [CreateAssetMenu(fileName = "GamePlayingState", menuName = "DLS/GameStates/GamePlayingState", order = 1)]
    public class GamePlayingState : GameState
    {
        public override void Enter()
        {
            Debug.Log("Entered game playing state");
        }

        public override void Exit()
        {
            Debug.Log("Exited game playing state");
        }

        public override void Update()
        {
            Debug.Log("Update game playing state");
        }
    }
}