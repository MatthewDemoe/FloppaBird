using System.Collections;
using UnityEngine;

namespace GameSystems
{
    public class SpriteController : MonoBehaviour
    {
        const float speed = 1.5f;

        void Start()
        {
            StartCoroutine(DestroyWhenOutOfRangeRoutine());
        }

        private void Update()
        {
            if (GameController.Instance.isGameActive)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        IEnumerator DestroyWhenOutOfRangeRoutine()
        {
            yield return new WaitUntil(() => transform.position.x <= -6.0f);

            Destroy(gameObject);
        }
    }
}