using System;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Forta
{
	public class PhysicsGrabber : MonoBehaviour
	{
		public float maxVelocity = 10;
		public float speed = 4;
		
		private Grabable _target;

		private void OnGrab(InputAction.CallbackContext ctx)
		{
			if (_target != null)
			{
				_target.OnRelease();
				_target = null;
			}
			else
			{
				_target = Grabable.SelectedGrabable;
				
				if (_target == null) return;
				
				_target.OnGrabbed();
			}
		}

		#region Unity Events
		private void Start()
		{
			InputManager.Instance.Controls.Player.Enable();
			InputManager.Instance.Controls.Player.Grab.started += OnGrab;
		}

		private void FixedUpdate()
		{
			if (_target == null) return;

			Rigidbody2D rb = _target.Rigidbody;
			
			Vector2 targetPos = InputManager.Instance.PointerWorldPos;
			Vector2 currentPos = rb.transform.position;
			Vector2 delta = targetPos - currentPos;
			delta.x = Mathf.Clamp(delta.x, -maxVelocity, maxVelocity);
			delta.y = Mathf.Clamp(delta.y, -maxVelocity, maxVelocity);

			rb.velocity = delta * speed;
		}
		#endregion
	}
}