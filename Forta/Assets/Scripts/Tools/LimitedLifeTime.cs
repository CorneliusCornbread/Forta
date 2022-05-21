using UnityEngine;

namespace Forta.Tools
{
	[DisallowMultipleComponent]
	public class LimitedLifeTime : MonoBehaviour
	{
		[SerializeField]
		[Range(0.1f, 360)]
		[Tooltip("Lifetime of this game object in seconds.")]
		private float lifeTime = 100;

		private float _timeAlive;

		private void Update()
		{
			_timeAlive += Time.deltaTime;

			if (_timeAlive >= lifeTime)
			{
				Destroy(gameObject);
			}
		}
	}
}