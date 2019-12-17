using System;
using UnityEngine;
using UnityEngine.UI;

namespace RakibUtils
{
    public class SimpleScoreExample : MonoBehaviour
    {
        private SimpleScoreSystem m_scoreSystem;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text highScoreText;
        private void Awake()
        {
            m_scoreSystem = new SimpleScoreSystem();
            UpdateScoreUI();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_scoreSystem.IncreaseScore(1);
                if(m_scoreSystem.IsHighScore())
                    m_scoreSystem.SaveHighScore();
                
                UpdateScoreUI();
            }
            
        }

        private void UpdateScoreUI()
        {
            scoreText.text = "Score: " + m_scoreSystem.ScoreInt.ToString();
            highScoreText.text = "HighScore: " + m_scoreSystem.HighScoreInt;
        }
    }
}
