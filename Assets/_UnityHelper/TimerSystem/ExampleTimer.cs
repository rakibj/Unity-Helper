using System;
using UnityEngine;
using UnityEngine.UI;

namespace RakibUtils
{
    public class ExampleTimer : MonoBehaviour
    {
        [SerializeField] private float timerDuration;
        [SerializeField] private Text timerText;
        private Timer m_timer;
        private void Start()
        {
            m_timer = new Timer(timerDuration);
        }

        private void Update()
        {
            m_timer.ReduceTimer_Update(Time.deltaTime);
            timerText.text = m_timer.CurrentTime.ToString("F1");
            if(m_timer.CurrentTime <= 0)
                m_timer.ResetTimer(timerDuration);
        }
    }
}
