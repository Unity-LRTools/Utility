using UnityEngine;

namespace LRT.Utility.Editor
{
	public static class CustomGUIStyle
	{
		#region Label
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
		#endregion

		#region Button
		public static GUIStyle Button(
			Font font = null,
			int fontSize = 0,
			FontStyle fontStyle = FontStyle.Normal,
			TextAnchor alignment = TextAnchor.MiddleCenter,
			bool wordWrap = false,
			Color? normalTextColor = null,
			Color? hoverTextColor = null,
			Color? activeTextColor = null,
			Color? focusedTextColor = null,
			Color? onNormalTextColor = null,
			Color? onHoverTextColor = null,
			Color? onActiveTextColor = null,
			Color? onFocusedTextColor = null,
			Texture2D normalBackground = null,
			Texture2D hoverBackground = null,
			Texture2D activeBackground = null,
			Texture2D focusedBackground = null,
			Texture2D onNormalBackground = null,
			Texture2D onHoverBackground = null,
			Texture2D onActiveBackground = null,
			Texture2D onFocusedBackground = null,
			RectOffset border = null,
			RectOffset margin = null,
			RectOffset padding = null,
			RectOffset overflow = null,
			bool stretchWidth = true,
			bool stretchHeight = false
		)
		{
			// Use default button skin
			GUIStyle baseStyle = GUI.skin.button;

			// Create a new style
			GUIStyle customStyle = new GUIStyle(baseStyle)
			{
				font = font ?? baseStyle.font,
				fontSize = fontSize > 0 ? fontSize : baseStyle.fontSize,
				fontStyle = fontStyle,
				alignment = alignment,
				wordWrap = wordWrap,
				stretchWidth = stretchWidth,
				stretchHeight = stretchHeight
			};

			// Assign text color
			customStyle.normal.textColor = normalTextColor ?? baseStyle.normal.textColor;
			customStyle.hover.textColor = hoverTextColor ?? baseStyle.hover.textColor;
			customStyle.active.textColor = activeTextColor ?? baseStyle.active.textColor;
			customStyle.focused.textColor = focusedTextColor ?? baseStyle.focused.textColor;
			customStyle.onNormal.textColor = onNormalTextColor ?? baseStyle.onNormal.textColor;
			customStyle.onHover.textColor = onHoverTextColor ?? baseStyle.onHover.textColor;
			customStyle.onActive.textColor = onActiveTextColor ?? baseStyle.onActive.textColor;
			customStyle.onFocused.textColor = onFocusedTextColor ?? baseStyle.onFocused.textColor;

			// Assign texture background
			customStyle.normal.background = normalBackground ?? baseStyle.normal.background;
			customStyle.hover.background = hoverBackground ?? baseStyle.hover.background;
			customStyle.active.background = activeBackground ?? baseStyle.active.background;
			customStyle.focused.background = focusedBackground ?? baseStyle.focused.background;
			customStyle.onNormal.background = onNormalBackground ?? baseStyle.onNormal.background;
			customStyle.onHover.background = onHoverBackground ?? baseStyle.onHover.background;
			customStyle.onActive.background = onActiveBackground ?? baseStyle.onActive.background;
			customStyle.onFocused.background = onFocusedBackground ?? baseStyle.onFocused.background;

			// Assign rect offset
			customStyle.border = border ?? new RectOffset(baseStyle.border.left, baseStyle.border.right, baseStyle.border.top, baseStyle.border.bottom);
			customStyle.margin = margin ?? new RectOffset(baseStyle.margin.left, baseStyle.margin.right, baseStyle.margin.top, baseStyle.margin.bottom);
			customStyle.padding = padding ?? new RectOffset(baseStyle.padding.left, baseStyle.padding.right, baseStyle.padding.top, baseStyle.padding.bottom);
			customStyle.overflow = overflow ?? new RectOffset(baseStyle.overflow.left, baseStyle.overflow.right, baseStyle.overflow.top, baseStyle.overflow.bottom);

			return customStyle;
		}
		#endregion
	}
}
