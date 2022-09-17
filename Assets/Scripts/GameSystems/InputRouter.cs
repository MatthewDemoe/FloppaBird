using UnityEngine;
using UnityEngine.Events;

namespace GameSystems
{
    public class InputRouter : MonoBehaviour
    {
        public UnityEvent OnLeftClick = new UnityEvent();

        void Update()
        {          
            if (Input.GetMouseButtonDown(0))
            {
                if (!GameController.Instance.isGameActive && GameController.Instance.isPlayerAlive)
                    GameController.Instance.StartGame();

                if(GameController.Instance.isPlayerAlive)
                    OnLeftClick.Invoke();
            }
        }
    }
}