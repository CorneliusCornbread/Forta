using System;
using System.Collections.Generic;
using UnityEngine;

namespace Forta
{
	[RequireComponent(typeof(Rigidbody2D))]
	[RequireComponent(typeof(BoxCollider2D))]
	public class Grabable : MonoBehaviour
	{
		public static Grabable SelectedGrabable { get; private set; }

		public float gravity = 1;
		
		[SerializeField]
		private new Rigidbody2D rigidbody;

		[SerializeField]
		private new BoxCollider2D collider;

		public Rigidbody2D Rigidbody => rigidbody;

		private static readonly string[] MountLayerMask = new []
		{
			"Grabable"
		};

		private bool IsMounted => _mountCollisions.Count != 0;
		
		private List<Collision2D> _mountCollisions = new List<Collision2D>(4);

		private bool _isGrabbed = false;

		public void OnGrabbed()
		{
			_isGrabbed = true;
			
			rigidbody.bodyType = RigidbodyType2D.Dynamic;
			rigidbody.gravityScale = 0;
		}

		public void OnRelease()
		{
			_isGrabbed = false;
		}

		private void UnmountSelf()
		{
			Debug.Log($"Unmounted {gameObject.name}");

			rigidbody.bodyType = RigidbodyType2D.Dynamic;
			rigidbody.gravityScale = gravity;
		}
		
		private void MountSelf()
		{
			Debug.Log($"Mounted {gameObject.name}");
			
			rigidbody.bodyType = RigidbodyType2D.Static;
		}
		
		#region Unity Events
		private void Start()
		{
			collider.enabled = true; //Wait until serialization is finished before handling mouse detection to avoid null ref
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			
		}

		private void OnCollisionExit2D(Collision2D other)
		{
			
		}

		private void OnMouseEnter()
		{
			SelectedGrabable = this;
		}

		private void OnMouseExit()
		{
			if (SelectedGrabable == this)
			{
				SelectedGrabable = null;
			}
		}
		#endregion
	}
}