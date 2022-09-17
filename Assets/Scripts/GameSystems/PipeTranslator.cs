using System.Linq;
using UnityEngine;

namespace GameSystems
{
    public class PipeTranslator : MonoBehaviour
    {
        [SerializeField]
        float speed = 1.5f;

        private void Start()
        {
            GameController.Instance.OnGameStopped.AddListener(DisableColliders);
        }

        void Update()
        {
            if (GameController.Instance.isGameActive)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        private void DisableColliders()
        {
            GetComponentsInChildren<Collider2D>().ToList().ForEach(collider => collider.enabled = false);
        }

        private void OnDestroy()
        {
            GameController.Instance.OnGameStopped.RemoveListener(DisableColliders);
        }
    }
}