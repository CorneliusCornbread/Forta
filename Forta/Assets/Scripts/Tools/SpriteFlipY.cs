using MyBox;
using UnityEngine;

namespace Forta.Tools
{
	public class SpriteFlipY : MonoBehaviour
	{
		[SerializeField]
		[MustBeAssigned]
		private SpriteRenderer targetSprite;

		[SerializeField]
		private RangedInt flipDirection = new RangedInt(90, 270);

		private void Update()
		{
			if (transform.rotation.eulerAngles.z > flipDirection.Max || transform.rotation.eulerAngles.z < flipDirection.Min)
			{
				targetSprite.flipY = false;
			}
			else
			{
				targetSprite.flipY = true;
			}
		}
	}
}