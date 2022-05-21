using System;
using System.Linq;
using UnityEngine;

namespace Forta.Tools
{
	/// <summary>
	/// A class which can be inherited from to create a singleton with a scriptable object.
	/// Be careful in editor, values can carry over between play modes, initialize your values.
	/// </summary>
	/// <typeparam name="T">Self</typeparam>
	public abstract class SingletonScriptableObject<T> : ScriptableObject where T : SingletonScriptableObject<T>
	{
		[NonSerialized]
		private bool _isLoaded;
		private static T _instance;
		public static T Instance
		{
			get
			{
				if (_instance != null) return _instance;
				
				Debug.LogWarning($"Singleton instance for type {typeof(T)} not found, finding new instance");

#if UNITY_EDITOR
				T[] objects = Resources.LoadAll<T>("Singletons");
				switch (objects.Length)
				{
					case 0:
						Debug.LogError($"No singleton scriptable object asset found for type {typeof(T)}");
						break;
					case 1:
						_instance = objects[0];
						break;
					default:
						Debug.LogWarning($"More than one scriptable object found for type {typeof(T)}, defaulting to first object found");
						_instance = objects[0];
						break;

				}
				
#else
				_instance = Resources.LoadAll<T>("Singletons").FirstOrDefault();
#endif
				_instance.InitializeSingleton();
				
				return _instance;
			}
		}

		/// <summary>
		/// Needs to be called when you load a singleton, instance based singletons do not need to call this.
		/// Injected singletons DO however have to call this at some point before being used.
		/// </summary>
		public void InitializeSingleton()
		{
			if (_isLoaded) { return; }
			
			try
			{
				OnLoad();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
			_isLoaded = true;
		}
		
		/// <summary>
		/// Called when the scriptable object is loaded so it can be referenced from its singleton field.
		/// Use this instead of Awake() or OnEnable().
		/// </summary>
		protected virtual void OnLoad()
		{
			
		}
	}
}