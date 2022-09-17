using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystems
{   
    public class SpriteCreator : MonoBehaviour
    {
        [SerializeField]
        GameObject spritePrefab;

        [SerializeField]
        GameObject spriteSpawnPoint;

        [SerializeField]
        List<Sprite> sprites = new List<Sprite>();

        const float MinTimeBetweenSprites = 2.0f;
        const float MaxTimeBetweenSprites = 7.0f;

        void Start()
        {
            StartCoroutine(CreateSpritesRoutine());
        }

        IEnumerator CreateSpritesRoutine()
        {
            yield return new WaitUntil(() => GameController.Instance.isGameActive);

            while (GameController.Instance.isGameActive)
            {
                yield return new WaitForSeconds(Random.Range(MinTimeBetweenSprites, MaxTimeBetweenSprites));

                GameObject spriteInstance = Instantiate(spritePrefab, spriteSpawnPoint.transform.position, Quaternion.identity);
                spriteInstance.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Count)];
            }
        }
    }
}