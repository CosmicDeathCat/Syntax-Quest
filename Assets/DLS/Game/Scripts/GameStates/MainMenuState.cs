using Unity.VisualScripting;
using UnityEngine;

namespace DLS.Game.Scripts.GameStates
{
    [CreateAssetMenu(fileName = "MainMenuState", menuName = "DLS/GameStates/MainMenuState", order = 0)]
    public class MainMenuState : GameState
    {
        public GameObject MainMenuCanvasPrefab;

        private GameObject mainMenu;
        
        public override void Enter()
        {
            Debug.Log("Entered main menu state");
        }

        public override void Exit()
        {
            Debug.Log("Exited main menu state");
        }

        public override void Update()
        {
            Debug.Log("Update main menu state");
        }
    }
}