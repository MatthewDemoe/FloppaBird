using GameSystems;
using System.Collections;
using UnityEngine;

namespace GameSystems
{
    public class PipeCreator : MonoBehaviour
    {
        [SerializeField]
        GameObject pipePrefab;

        [SerializeField]
        float maxDisplacement = 2.0f;

        [SerializeField]
        float timeBetweenPipes = 2.25f;

        public void StartCreatingPipes()
        {
            StartCoroutine(CreatePipesRoutine());
        }

        private void CreatePipe()
        {
            float displacement = Random.Range(-maxDisplacement, maxDisplacement);

            Instantiate(pipePrefab, transform.position + Vector3.up * displacement, Quaternion.identity);
        }

        IEnumerator CreatePipesRoutine()
        {
            while (GameController.Instance.isGameActive)
            {
                CreatePipe();
                yield return new WaitForSeconds(timeBetweenPipes);
            }
        }
    }
}