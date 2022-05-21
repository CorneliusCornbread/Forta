using UnityEngine;

namespace Forta.Tools
{
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Returns if the given game object is a prefab asset and NOT a instance in a scene.
		/// </summary>
		/// <param name="go"></param>
		/// <returns></returns>
		public static bool IsPrefabAsset(this GameObject go)
		{
			return go.scene.name == null;
		}
	}
}