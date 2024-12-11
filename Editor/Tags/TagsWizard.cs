using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace LRT.Smith.Statistics.Editor
{
	public class TagsWizard : EditorWindow
	{
		public List<string> tags;
		public Vector2 scrollPosition;

		public static void CreateWizard(List<string> tags)
		{
			TagsWizard window = GetWindow<TagsWizard>("Statistic Tags");
			window.tags = tags;

			while (tags.Count() < 32)
			{
				tags.Add("");
			}
		}

		void OnGUI()
		{
			scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition);

			for (int i = 0; i < 32; i++)
			{
				tags[i] = EditorGUILayout.TextField($"Tag {i + 1}", tags[i].ToString());
			}

			EditorGUILayout.EndScrollView();

			GUILayout.FlexibleSpace();
			EditorGUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("Apply"))
				OnApplyButton();
			GUILayout.Space(5);
			EditorGUILayout.EndHorizontal();
		}

		private void OnApplyButton()
		{
			Close();
		}
	}
}
