using UnityEngine;

namespace RakibUtils
{
    public class RotateWithDrag : MonoBehaviour
    {
        [SerializeField] private LayerMask targetLayer;
        [SerializeField] private float rotationRate = 3.0f;
        [SerializeField] private bool xRotation;
        [SerializeField] private bool yRotation;
        [SerializeField] private bool invertX;
        [SerializeField] private bool invertY;
        [SerializeField] private bool touchAnywhere;
        private float m_previousX;
        private float m_previousY;
        private Camera m_camera;
        private bool m_rotating = false;

        private void Awake()
        {
            m_camera = Camera.main;
        }

        private void Update ()
        {
            if (!touchAnywhere)
            {
                //No need to check if already rotating
                if (!m_rotating)
                {
                    RaycastHit hit;
                    Ray ray = m_camera.ScreenPointToRay(Input.mousePosition);
                    if (!Physics.Raycast(ray, out hit, 1000, targetLayer))
                    {
                        return;
                    }
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                m_rotating = true;
                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }
            // get the user touch input
            if(Input.GetMouseButton(0)) 
            {
                var touch = Input.mousePosition;
                var deltaX = -(Input.mousePosition.y - m_previousY) * rotationRate;
                var deltaY = -(Input.mousePosition.x - m_previousX) * rotationRate;
                if(!yRotation) deltaX = 0;
                if(!xRotation) deltaY = 0;
                if (invertX) deltaY *= -1;
                if (invertY) deltaX *= -1;
                transform.Rotate (deltaX, deltaY, 0, Space.World);
                
                m_previousX = Input.mousePosition.x;
                m_previousY = Input.mousePosition.y;
            }
            if (Input.GetMouseButtonUp(0))
                m_rotating = false;
        }
    }
}
