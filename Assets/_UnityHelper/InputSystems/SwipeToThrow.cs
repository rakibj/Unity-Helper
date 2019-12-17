using UnityEngine;

namespace RakibUtils
{
	public class SwipeToThrow : MonoBehaviour
	{
		private Vector3 m_ballInitialPosition;
		private Vector2 m_startPos, m_endPos, m_direction; // touch start position, touch end position, swipe direction
		private float m_touchTimeStart, m_touchTimeFinish, m_timeInterval; // to calculate swipe time to sontrol throw force in Z direction
		private Rigidbody m_rb;
		[SerializeField] private float throwForceInXAndY = 1f; // to control throw force in X and Y directions
		[SerializeField] private float throwForceInZ = 50f; // to control throw force in Z direction

		private void Start()
		{
			m_rb = GetComponent<Rigidbody> ();
			m_rb.isKinematic = true;
			m_ballInitialPosition = transform.position;
		}

		private void Update () 
		{
			// if you touch the screen
			if (Input.GetMouseButtonDown(0)) {

				// getting touch position and marking time when you touch the screen
				m_touchTimeStart = Time.time;
				m_startPos = Input.mousePosition;
			}
			// if you release your finger
			if (Input.GetMouseButtonUp(0)) {

				// marking time when you release it
				m_touchTimeFinish = Time.time;

				// calculate swipe time interval 
				m_timeInterval = m_touchTimeFinish - m_touchTimeStart;

				// getting release finger position
				m_endPos = Input.mousePosition;

				// calculating swipe direction in 2D space
				m_direction = m_startPos - m_endPos;

				// add force to balls rigidbody in 3D space depending on swipe time, direction and throw forces
				m_rb.isKinematic = false;
				m_rb.AddForce (- m_direction.x * throwForceInXAndY, - m_direction.y * throwForceInXAndY, throwForceInZ / m_timeInterval);

			}
			
			//Reset Ball Position
			if (Input.GetKeyDown(KeyCode.R))
			{
				transform.position = m_ballInitialPosition;
				m_rb.isKinematic = true;
				m_rb.velocity = Vector3.zero;
			}
			
		}
	}
}
