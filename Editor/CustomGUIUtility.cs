using UnityEditor;
using UnityEngine;

namespace LRT.Utility.Editor
{
	public static class CustomGUIUtility
	{
		public static void DrawBorder(Rect rect, Color color, float borderWidth = 1)
		{
			//---TOP LINE---
			float x1 = rect.x;
			float y1 = rect.y;
			float x2 = rect.width;
			float y2 = borderWidth;

			Rect lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);

			//---RIGHT LINE---
			x1 = rect.x + rect.width;
			y1 = rect.y;
			x2 = borderWidth;
			y2 = rect.height;

			lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);

			//---LEFT LINE---
			x1 = rect.x;
			y1 = rect.y;
			x2 = borderWidth;
			y2 = rect.height;

			lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);

			//---BOTTOM LINE---

			x1 = rect.x;
			y1 = rect.y + rect.height - borderWidth + 1;
			x2 = rect.width;
			y2 = borderWidth;

			lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);
		}
		
		public static void DrawCross(Rect rect, Color color, float borderWidth = 1)
		{
			//---VERTICAL LINE---
			float x1 = (rect.x + (rect.width / 2)) + (borderWidth / 2);
			float y1 = rect.y;
			float x2 = borderWidth;
			float y2 = rect.height;

			Rect lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);

			//---RIGHT LINE---
			x1 = rect.x;
			y1 = (rect.y + (rect.height / 2)) - (borderWidth / 2);
			x2 = rect.width;
			y2 = borderWidth;

			lineRect = new Rect(x1, y1, x2, y2);

			EditorGUI.DrawRect(lineRect, color);
		}
	}
}


