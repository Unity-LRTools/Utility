using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class LazySingletonScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
	public static readonly string DEFAULT_EDITOR_LOAD_PATH = "Assets/Resources/";
	public static readonly string EDITOR_FILE_NAME = typeof(T).Name + ".asset";
	public static readonly string RUNTIME_FILE_NAME = typeof(T).Name;

	public static T Instance
	{
		get
		{
#if UNITY_EDITOR
			if (!Application.isPlaying && instance == null)
			{
				string editorPath = GetEditorPath();
				string editorFilepath = GetEditorFilepath();

				instance = AssetDatabase.LoadAssetAtPath<T>(editorFilepath);
				if (instance == null)
				{
					if (!Directory.Exists(editorPath))
						Directory.CreateDirectory(editorPath);

					T bufferInstance = CreateInstance<T>();
					AssetDatabase.CreateAsset(bufferInstance, editorFilepath);
					AssetDatabase.SaveAssets();
					instance = bufferInstance;
				}
			}
			else if (instance == null)
			{
				instance = Resources.Load<T>(RUNTIME_FILE_NAME);
			}
#else
			if (instance == null)
				instance = Resources.Load<T>(RUNTIME_FILE_NAME);
#endif
			return instance;
		}
	}

	private static T instance;

	private static string GetEditorPath()
	{
		string filepath = DEFAULT_EDITOR_LOAD_PATH;

		BindingFlags flags = BindingFlags.Static | BindingFlags.NonPublic;
		MethodInfo getPathMethod = typeof(T).GetMethod("GetPath", flags);

		if (getPathMethod != null)
			filepath = (string)getPathMethod.Invoke(null, null);

		return filepath;
	}

	private static string GetEditorFilepath()
	{
		return Path.Combine(GetEditorPath(), EDITOR_FILE_NAME);
	}
}