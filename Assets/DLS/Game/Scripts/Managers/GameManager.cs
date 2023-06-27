using DLS.Game.Scripts.GameStates;
using UnityEngine;

namespace DLS.Game.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<GameManager>();

                    if (instance == null)
                    {
                        GameObject managerObject = new GameObject("Game Manager");
                        instance = managerObject.AddComponent<GameManager>();
                    }
                }

                return instance;
            }
        }

        [SerializeField]
        public GameState CurrentState;

        [SerializeField]
        public GameState InitialState;

        private GameObject mainMenuCanvas;
        private bool isMainMenuSpawned;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (InitialState == null) return;
            SetState(InitialState);
            InitialState.Enter();
        }

        private void Update()
        {
            if (CurrentState != null)
                CurrentState.Update();
        }

        public void SetState(GameState newState)
        {
            if (CurrentState != null)
            {
                CurrentState.Exit();

                // Remove MainMenuCanvasPrefab when changing from MainMenuState
                if (CurrentState is MainMenuState)
                {
                    Destroy(mainMenuCanvas);
                    isMainMenuSpawned = false;
                }
            }

            CurrentState = newState;

            if (CurrentState != null)
            {
                CurrentState.Enter();

                // Spawn MainMenuCanvasPrefab when changing to MainMenuState
                if (CurrentState is MainMenuState && !isMainMenuSpawned)
                {
                    mainMenuCanvas = Instantiate((CurrentState as MainMenuState).MainMenuCanvasPrefab);
                    isMainMenuSpawned = true;
                }
            }
        }
    }
}
