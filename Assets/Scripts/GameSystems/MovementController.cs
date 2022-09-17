using UnityEngine;

namespace GameSystems
{
    public class MovementController : MonoBehaviour
    {
        Rigidbody2D rigidBody;

        [SerializeField]
        float FlopForce = 3.33f;

        void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            GameController.Instance.OnGameStopped.AddListener(() => AddFlopForce());
        }

        public void AddFlopForce()
        {
            rigidBody.velocity = Vector3.up * FlopForce;
        }
    }
}