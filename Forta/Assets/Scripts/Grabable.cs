using UnityEngine;

namespace Forta
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class Grabable : MonoBehaviour
	{
		public static Rigidbody2D SelectedGrabable { get; private set; }

		[SerializeField]
		private Rigidbody2D rigidbody;
		
		private void OnMouseEnter()
		{
			SelectedGrabable = rigidbody;
		}

		private void OnMouseExit()
		{
			if (SelectedGrabable == rigidbody)
			{
				SelectedGrabable = null;
			}
		}
	}
}