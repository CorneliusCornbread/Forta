using System;
using MyBox;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Forta
{
	public class PhysicsGrabber : MonoBehaviour
	{
		private Rigidbody2D _target;

		private void Start()
		{
			InputManager.Instance.Controls.Player.Enable();
			InputManager.Instance.Controls.Player.Grab.started += OnGrab;
		}

		private void FixedUpdate()
		{
			if (_target == null) return;
			
			Vector2 targetPos = InputManager.Instance.PointerWorldPos;
			
			_target.MovePosition(targetPos);
		}
		private void OnGrab(InputAction.CallbackContext ctx)
		{
			if (_target != null)
			{
				OnTargetDeselect();
				return;
			}
			
			_target = Grabable.SelectedGrabable;
			
			if (_target == null) return;
			
			_target.bodyType = RigidbodyType2D.Dynamic;
		}

		private void OnTargetDeselect()
		{
			_target.bodyType = RigidbodyType2D.Static;
			_target = null;
		}
	}
}