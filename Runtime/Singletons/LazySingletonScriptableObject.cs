using System.IO;
using UnityEditor;
using UnityEngine;

public class LazySingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
	public static readonly string LOAD_PATH = "Assets/Resources/";
	public static readonly string FILE_PATH = Path.Combine(LOAD_PATH, typeof(T).Name + ".asset");

	public static T Instance
	{
		get
		{
#if UNITY_EDITOR
			if (instance == null)
			{
				instance = AssetDatabase.LoadAssetAtPath<T>(FILE_PATH);
				if (instance == null)
				{
					if (!Directory.Exists(LOAD_PATH))
						Directory.CreateDirectory(LOAD_PATH);

					T bufferInstance = CreateInstance<T>();
					AssetDatabase.CreateAsset(bufferInstance, FILE_PATH);
					AssetDatabase.SaveAssets();
					instance = bufferInstance;
				}
			}
#else
			if (instance == null)
				instance = Resources.Load<T>(FILE_PATH);
#endif
			return instance;
		}
	}

	private static T instance;
}