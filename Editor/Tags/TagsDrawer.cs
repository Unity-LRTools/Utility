using LRT.Utility;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LRT.Smith.Statistics.Editor
{
	[CustomPropertyDrawer(typeof(Tags))]
	public abstract class TagsDrawer : PropertyDrawer
	{
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			SerializedProperty mask = property.FindPropertyRelative("mask");

			Rect pos1 = position.SliceH(0.33f, 0);
			Rect pos2 = position.RemainderH(0.33f).SliceH(0.65f, 0);
			Rect pos3 = position.RemainderH(0.33f).RemainderH(0.65f);

			EditorGUI.LabelField(pos1, label);
			mask.intValue = EditorGUI.MaskField(pos2, mask.intValue, GetOptions().ToArray());
			if (GUI.Button(pos3, "edit"))
				TagsWizard.CreateWizard(GetOptions());
		}

		public abstract List<string> GetOptions();
	}

	public static class TagsLayout
	{
		public static Tags TagsFlagField(string label, Tags tags, List<string> origin) => TagsFlagField(new GUIContent(label), tags, origin);

		public static Tags TagsFlagField(GUIContent label, Tags tags, List<string> origin)
		{
			Rect start = EditorGUILayout.GetControlRect(true, EditorGUIUtility.singleLineHeight);
			Rect pos1 = start.SetWidth(EditorGUIUtility.labelWidth);
			Rect pos2 = start.MoveX(EditorGUIUtility.labelWidth + 2).ChangeWidth(-EditorGUIUtility.labelWidth - 2).SliceH(0.7f, 0);
			Rect pos3 = start.MoveX(EditorGUIUtility.labelWidth + 2).ChangeWidth(-EditorGUIUtility.labelWidth - 2).RemainderH(0.7f);

			EditorGUI.LabelField(pos1, label);
			tags.mask = EditorGUI.MaskField(pos2, tags.mask, tags.Options);

			if (GUI.Button(pos3, "Edit"))
				TagsWizard.CreateWizard(origin);

			return tags;
		}
	}
}

