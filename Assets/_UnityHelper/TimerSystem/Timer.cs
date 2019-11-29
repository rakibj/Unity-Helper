using UnityEngine;

namespace RakibUtils
{
    public class Timer
    {
        private float m_currentTime = 0;
        /// <summary>
        /// current calculated time in timer
        /// </summary>
        public float CurrentTime => m_currentTime;

        private float m_totalTime = 0;
        /// <summary>
        /// total time the timer will run for
        /// </summary>
        public float TotalTime => m_totalTime;
        
        /// <summary>
        /// Instantiate Timer Class using the totalTime timer will run
        /// </summary>
        /// <param name="totalTime"></param>
        public Timer(float totalTime)
        {
            ResetTimer(totalTime);
        }

        /// <summary>
        /// Call this on Update to Run Timer
        /// </summary>
        /// <param name="deltaTime"></param>
        public void ReduceTimer_Update(float deltaTime)
        {
            m_currentTime -= deltaTime;
            if (m_currentTime <= 0)
                m_currentTime = 0;
        }

        /// <summary>
        /// Resets timer to parameter value
        /// </summary>
        /// <param name="totalTime"></param>
        public void ResetTimer(float totalTime)
        {
            m_totalTime = totalTime;
            m_currentTime = m_totalTime;
        }
    }
}
