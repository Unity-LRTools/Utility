using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

using Object = UnityEngine.Object;

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

		public static string Popup<T>(string label, string current, List<T> possiblesValues, Func<T, string> getValue, Func<T, string> getName)
		{
			string[] options = possiblesValues.Select(getName).ToArray();
			string[] values = possiblesValues.Select(getValue).ToArray();
			int index = Mathf.Max(0, Array.IndexOf(values, current));

			return values[EditorGUILayout.Popup(label, index, options)];
		}
	}

	public static class EditorListDrawer<T> where T : class
	{
		static Object undoTarget;
		static HashSet<int> expandedSet = new HashSet<int>();
		static ActionItemMod? actionItemMod;

		/// <summary>
		/// Draw the given list in the editor, for when you need to change variables of the list's elements, but not the elements themselves
		/// </summary>
		public static List<T> Draw(List<T> list, Action<T> drawItem)
		{
			return DrawList(new DefaultListDrawer(list, drawItem));
		}

		public static List<T> Draw(string label, ListDrawer drawer)
		{
			EditorGUILayout.LabelField(label);
			EditorGUI.indentLevel++;
			List<T> list = DrawList(drawer);
			EditorGUI.indentLevel--;

			return list;
		}

		static List<T> DrawList(ListDrawer drawer)
		{
			undoTarget = drawer.Target;
			actionItemMod = null;

			for (int i = 0; i < drawer.items.Count; i++)
			{
				if (!drawer.DrawHeader || DrawItemHeader(drawer.items, i, drawer.GetTitle(i), drawer.Orderable))
					drawer.DrawItem(drawer.items[i], i);
			}

			if (drawer.ShowAddButton)
				drawer.DrawAddButton();

			DoItemActionMod(drawer.items);

			return drawer.items;
		}

		static bool DrawItemHeader(List<T> list, int index, string title, bool orderable)
		{
			EditorGUILayout.BeginHorizontal();

			bool expanded = EditorGUILayout.Foldout(expandedSet.Contains(GetItemHashCode(list, index)), title);

			DrawUtilities(list, index, orderable);

			EditorGUILayout.EndHorizontal();

			if (expanded && !expandedSet.Contains(GetItemHashCode(list, index)))
				expandedSet.Add(GetItemHashCode(list, index));
			else if (!expanded && expandedSet.Contains(GetItemHashCode(list, index)))
				expandedSet.Remove(GetItemHashCode(list, index));

			return expanded;
		}

		private static void DrawUtilities(List<T> list, int index, bool orderable)
		{
			if (orderable)
			{
				bool wasEnabled = GUI.enabled;

				GUI.enabled = wasEnabled && index < list.Count - 1;
				if (GUILayout.Button("▼", EditorStyles.label, GUILayout.Width(12.75f)))
					actionItemMod = new ActionItemMod(list[index], ModType.MoveUp);

				GUI.enabled = wasEnabled && index > 0;
				if (GUILayout.Button("▲", EditorStyles.label, GUILayout.Width(12.75f)))
					actionItemMod = new ActionItemMod(list[index], ModType.MoveDown);

				GUI.enabled = wasEnabled;
			}

			if (GUILayout.Button("X", EditorStyles.label, GUILayout.Width(12.75f)))
				actionItemMod = new ActionItemMod(list[index], ModType.Delete);
		}

		static void DoItemActionMod(List<T> list)
		{
			if (actionItemMod.HasValue)
			{
				switch (actionItemMod.Value.modType)
				{
					case ModType.Delete:
						RecordUndo("remove state commmand", () => list.Remove(actionItemMod.Value.item));
						break;

					case ModType.MoveUp:
						RecordUndo("move command up", () => MoveUp(list, actionItemMod.Value.item));
						break;

					case ModType.MoveDown:
						RecordUndo("move command down", () => MoveDown(list, actionItemMod.Value.item));
						break;
				}
			}
		}

		static void MoveUp(List<T> list, T item)
		{
			Move(1, list, item);
		}

		static void MoveDown(List<T> list, T item)
		{
			Move(-1, list, item);
		}

		static void Move(int delta, List<T> list, T item)
		{
			int index = list.IndexOf(item);
			list.RemoveAt(index);
			list.Insert(index + delta, item);
		}

		static void RecordUndo(string command, Action action)
		{
			if (undoTarget)
			{
				Undo.RegisterCompleteObjectUndo(undoTarget, command);
				if (action != null)
				{
					action();
					EditorUtility.SetDirty(undoTarget);
				}
			}
			else
				action();

		}

		static int GetItemHashCode(List<T> list, int index)
		{
			return list.GetHashCode() ^ index;
		}

		struct ActionItemMod
		{
			public T item;
			public ModType modType;

			public ActionItemMod(T item, ModType modType)
			{
				this.item = item;
				this.modType = modType;
			}
		}

		enum ModType
		{
			Delete, MoveUp, MoveDown
		}

		public abstract class ListDrawer
		{
			public List<T> items;
			public virtual Object Target { get; set; }
			public virtual bool Orderable { get; set; }
			public virtual bool DrawHeader { get; set; }
			public virtual bool ShowAddButton { get; set; }
			public virtual string LabelAddButton { get => "Add item"; }

			public ListDrawer(List<T> items)
			{
				this.items = items;
				Orderable = true;
				DrawHeader = true;
				ShowAddButton = true;
			}

			public abstract void DrawItem(T item, int index);

			protected void DrawUtilities(int index)
			{
				EditorListDrawer<T>.DrawUtilities(items, index, Orderable);
			}

			public virtual void DrawBeforeAddButton() { }

			public virtual bool IsAddButtonValid()
			{
				return true;
			}

			public virtual string GetTitle(int i)
			{
				return $"Element {i}";
			}

			public virtual T OnCreate()
			{
				return default;
			}

			public void DrawAddButton()
			{
				if (!ShowAddButton)
					return;

				EditorGUILayout.BeginHorizontal();

				DrawBeforeAddButton();

				using (new EditorGUI.DisabledGroupScope(!IsAddButtonValid()))
				{
					if (GUILayout.Button(LabelAddButton))
						items.Add(OnCreate());
				}

				EditorGUILayout.EndHorizontal();
			}
		}

		private class DefaultListDrawer : ListDrawer
		{
			Action<T> drawItem;

			public DefaultListDrawer(List<T> items, Action<T> drawItem) : base(items)
			{
				this.drawItem = drawItem;
			}

			public override void DrawItem(T item, int index)
			{
				drawItem(item);
			}
		}
	}
}


