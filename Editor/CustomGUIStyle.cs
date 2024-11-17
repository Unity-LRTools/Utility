using UnityEngine;

namespace LRT.Utility.Editor
{
	public static class CustomGUIStyle
	{
		/// <summary>
		/// Override the default label skin to create a new style
		/// </summary>
		public static GUIStyle Label(
			string name = null,
			GUIStyleState normal = null,
			GUIStyleState hover = null,
			GUIStyleState active = null,
			GUIStyleState focused = null,
			GUIStyleState onNormal = null,
			GUIStyleState onHover = null,
			GUIStyleState onActive = null,
			GUIStyleState onFocused = null,
			RectOffset border = null,
			RectOffset margin = null,
			RectOffset padding = null,
			RectOffset overflow = null,
			Font font = null,
			int? fontSize = null,
			FontStyle? fontStyle = null,
			TextAnchor? alignment = null,
			bool? wordWrap = null,
			Color? textColor = null,
			bool? richText = null,
			ImagePosition? imagePosition = null
		)
		{
			// Get the default label skin
			GUIStyle defaultStyle = GUI.skin.label;

			// Create the new style
			var style = new GUIStyle
			{
				name = name ?? defaultStyle.name,
				normal = normal ?? defaultStyle.normal,
				hover = hover ?? defaultStyle.hover,
				active = active ?? defaultStyle.active,
				focused = focused ?? defaultStyle.focused,
				onNormal = onNormal ?? defaultStyle.onNormal,
				onHover = onHover ?? defaultStyle.onHover,
				onActive = onActive ?? defaultStyle.onActive,
				onFocused = onFocused ?? defaultStyle.onFocused,
				border = border ?? defaultStyle.border,
				margin = margin ?? defaultStyle.margin,
				padding = padding ?? defaultStyle.padding,
				overflow = overflow ?? defaultStyle.overflow,
				font = font ?? defaultStyle.font,
				fontSize = fontSize ?? defaultStyle.fontSize,
				fontStyle = fontStyle ?? defaultStyle.fontStyle,
				alignment = alignment ?? defaultStyle.alignment,
				wordWrap = wordWrap ?? defaultStyle.wordWrap,
				richText = richText ?? defaultStyle.richText,
				imagePosition = imagePosition ?? defaultStyle.imagePosition
			};

			// Override text color
			if (textColor.HasValue)
				style.normal.textColor = textColor.Value;

			return style;
		}
	}
}
