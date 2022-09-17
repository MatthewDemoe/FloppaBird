using UnityEngine;
using UnityEngine.Events;

namespace GameSystems
{
    public class GameController : MonoBehaviour
    {
        public static GameController Instance { get; private set; } = null;

        public UnityEvent OnGameStarted = new UnityEvent();
        public UnityEvent OnGameStopped = new UnityEvent();
        public UnityEvent OnGameEnded = new UnityEvent();

        public bool isGameActive { get; private set; } = false;
        public bool isPlayerAlive { get; private set; } = true;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
                Debug.Log("Trying to create more than one GameController");
        }

        public void StartGame()
        {
            isGameActive = true;
            OnGameStarted.Invoke();
        }

        public void StopGame()
        {
            isGameActive = false;
            isPlayerAlive = false;
            OnGameStopped.Invoke();
        }

        public void EndGame()
        {            
            OnGameEnded.Invoke();
        }

        public void ResetGame()
        {
            SceneTransitioner.Instance.ReloadScene();
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}