using Identifiers;
using TMPro;
using UnityEngine;

namespace GameSystems
{
    public class ScoreTracker : MonoBehaviour
    {
        public static ScoreTracker Instance { get; private set; } = null;

        public int score { get; private set; } = 0;

        [SerializeField]
        TextMeshProUGUI liveScore;

        [SerializeField]
        TextMeshProUGUI scoreText;

        void Awake()
        {
            if (Instance == null)
                Instance = this;

            else
                Debug.Log("Trying to create more than one ScoreTracker");            
        }

        private void Start()
        {
            GameController.Instance.OnGameEnded.AddListener(CheckScore);
        }

        public void IncrementScore()
        {
            score++;

            liveScore.text = score.ToString();
        }

        private void CheckScore()
        {
            if (score > PlayerPrefs.GetInt(PlayerPrefsKeys.HighScore))
                UpdateHighScore();

            else
                scoreText.text = $"Best: {PlayerPrefs.GetInt(PlayerPrefsKeys.HighScore)}\nScore: {score}";
        }

        private void UpdateHighScore()
        {
            PlayerPrefs.SetInt(PlayerPrefsKeys.HighScore, score);

            scoreText.text = $"New Best!\n{score}";
        }
    }
}