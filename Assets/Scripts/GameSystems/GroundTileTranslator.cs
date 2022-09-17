using UnityEngine;

namespace GameSystems
{
    public class GroundTileTranslator : MonoBehaviour
    {
        [SerializeField]
        float speed = 1.5f;

        void Update()
        {
            if (GameController.Instance.isGameActive)
                UpdatePosition();
        }

        private void UpdatePosition()
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (transform.position.x <= -6.0f)
                transform.position += new Vector3(12.0f, 0.0f, 0.0f);
        }
    }
}