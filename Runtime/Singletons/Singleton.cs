using UnityEngine;

namespace LRG
{
	public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		protected static T instance;
		public static T Instance
		{
			get
			{
#if UNITY_EDITOR
				if (!Application.isPlaying)
					instance = FindObjectOfType<T>();
#else
				if (instance == null)
					throw new NullReferenceException("Initialize singleton in Awake.");
#endif
				return instance;
			}
		}

		protected virtual void Awake()
		{
			instance = this as T;
			OnAwake();
		}

		protected virtual void OnAwake() { }
	}
}

