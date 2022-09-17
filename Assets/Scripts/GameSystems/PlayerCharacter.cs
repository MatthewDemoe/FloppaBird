using Identifiers;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace GameSystems
{
    public class PlayerCharacter : MonoBehaviour
    {
        Rigidbody2D rb;
        FloppaAudioPlayer audioPlayer;

        private const float SpinSpeed = 750.0f;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            audioPlayer = GetComponent<FloppaAudioPlayer>();

            GameController.Instance.OnGameStopped.AddListener(() => HandleDeath());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.tag == Tags.Obstacle)
                HandleCollision();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == Tags.Goal)
                ScoreTracker.Instance.IncrementScore();
        }

        public void Initialize()
        {
            rb.simulated = true;
        }

        private void HandleCollision()
        {
            if (GameController.Instance.isGameActive)
            {
                GameController.Instance.StopGame();
                audioPlayer.PlayImpactClip();
            }

            else
            {
                GameController.Instance.EndGame();
                audioPlayer.PlayGroundImpactClip();
                StopAllCoroutines();
            }
        }

        private void HandleDeath()
        {
            StartCoroutine(DeathRoutine());
        }

        IEnumerator DeathRoutine()
        {
            yield return null;

            while (true)
            {
                transform.Rotate(0.0f, 0.0f, Time.deltaTime * SpinSpeed);
                yield return null;
            }
        }
    }
}