using UnityEngine;

namespace RakibUtils
{
    public class InputTopDownMobile : MonoBehaviour, IInputTopDown
    {
        private float m_horizontal;
        private float m_vertical;
        private bool m_release;
        private Vector2 m_startTouch;
        private Vector2 m_currentTouch;
        private Vector2 m_inputVector;
        public float Horizontal()
        {
            return m_horizontal;
        }

        public float Vertical()
        {
            return m_vertical;
        }

        public bool Release()
        {
            return m_release;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                m_currentTouch = Input.mousePosition;
                if (Vector2.Distance(m_currentTouch, m_startTouch) < 5)
                    return;
                m_inputVector = (m_startTouch - m_currentTouch).normalized;
                m_horizontal = m_inputVector.x;
                m_vertical = m_inputVector.y;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                m_release = true;
                m_horizontal = 0;
                m_vertical = 0;
            }
            else
            {
                m_release = false;
            }
        }
    }
}
