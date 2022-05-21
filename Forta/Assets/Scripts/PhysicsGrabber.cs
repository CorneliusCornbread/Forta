using System;
using MyBox;
using UnityEngine;

namespace Forta
{
	public class PhysicsGrabber : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D _target;

		private void FixedUpdate()
		{
			Vector2 targetPos = InputManager.Instance.PointerWorldPos;
			
			_target.MovePosition(targetPos);
		}
	}
}