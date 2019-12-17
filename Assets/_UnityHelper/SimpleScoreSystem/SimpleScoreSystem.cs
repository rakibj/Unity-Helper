using UnityEngine;

namespace RakibUtils
{
    public class SimpleScoreSystem
    {
        private float m_score;
        public float Score
        {
            get => m_score;
            set => m_score = value;
        }
        public float ScoreFloat => m_score;
        public int ScoreInt => Mathf.CeilToInt(m_score);
        
        private float m_highScore;
        public float HighScoreFloat => m_highScore;
        public int HighScoreInt => Mathf.CeilToInt(m_highScore);
        private const string KeyHighScore = "HighScore";
        
        public SimpleScoreSystem()
        {
            m_highScore = PlayerPrefsExtended.LoadOrCreateKeyFloat(KeyHighScore);
            m_score = 0f;
        }

        public bool IsHighScore()
        {
            return m_score > m_highScore;
        }

        public void IncreaseScore(float increment)
        {
            m_score += increment;
        }

        public void DecreaseScore(float decrement)
        {
            m_score -= decrement;
        }

        public void SaveHighScore()
        {
            m_highScore = m_score > m_highScore ? m_score : m_highScore;
            PlayerPrefs.SetFloat(KeyHighScore, m_highScore);
        }
    }
}
