using UnityEditor;
using UnityEngine;

namespace LRT.Utility
{
	public static class RectUtility
	{
		/// <summary>
		/// The last rect (after modifications) that went through a method of <see cref="RectUtility"/>
		/// </summary>
		public static Rect lastRect { get; private set; }

		/// <summary>
		/// Manually set the last rect to be used by <see cref="RectUtility"/>
		/// </summary>
		public static Rect SetLastRect(Rect rect)
		{
			return lastRect = rect;
		}

		/// <summary>
		/// Set the x position of this rect
		/// </summary>
		public static Rect SetX(this Rect rect, float x)
		{
			rect.x = x;
			return lastRect = rect;
		}

		/// <summary>
		/// Set the y position of this rect
		/// </summary>
		public static Rect SetY(this Rect rect, float y)
		{
			rect.y = y;
			return lastRect = rect;
		}

		/// <summary>
		/// Set the width of this rect
		/// </summary>
		public static Rect SetWidth(this Rect rect, float width)
		{
			rect.width = width;
			return lastRect = rect;
		}

		/// <summary>
		/// Set the height of this rect
		/// </summary>
		public static Rect SetHeight(this Rect rect, float height)
		{
			rect.height = height;
			return lastRect = rect;
		}

		/// <summary>
		/// Set the height of this rect to <see cref="EditorGUIUtility.singleLineHeight"/>
		/// </summary>
		public static Rect LineHeight(this Rect rect)
		{
			rect.height = EditorGUIUtility.singleLineHeight;
			return lastRect = rect;
		}

		/// <summary>
		/// Make this rect a square using its smallest dimension. Set oppositeDirection to true to keep the square on the right or the bottom
		/// </summary>
		public static Rect Square(this Rect rect, bool oppositeDirection = false)
		{
			float oldWidth = rect.width;
			float oldHeight = rect.height;

			rect.width = rect.height > rect.width ? rect.width : rect.height;
			rect.height = rect.width > rect.height ? rect.height : rect.width;

			if (oppositeDirection)
			{
				rect.x += oldWidth - rect.width;
				rect.y += oldHeight - rect.height;
			}

			return lastRect = rect;
		}

		/// <summary>
		/// Place this rect at its default position of (0, 0)
		/// </summary>
		public static Rect DefaultPos(this Rect rect) => SetPos(rect, Vector2.zero);

		/// <summary>
		/// Set the position of this rect
		/// </summary>
		public static Rect SetPos(this Rect rect, float x, float y) => SetPos(rect, new Vector2(x, y));

		/// <summary>
		/// Set the position of this rect
		/// </summary>
		public static Rect SetPos(this Rect rect, Vector2 position)
		{
			rect.position = position;
			return lastRect = rect;
		}

		/// <summary>
		/// Set the size of this rect
		/// </summary>
		public static Rect SetSize(this Rect rect, float width, float height) => SetSize(rect, new Vector2(width, height));

		/// <summary>
		/// Set the size of this rect
		/// </summary>
		public static Rect SetSize(this Rect rect, Vector2 size)
		{
			rect.size = size;
			return lastRect = rect;
		}

		/// <summary>
		/// Move the x position of this rect
		/// </summary>
		public static Rect MoveX(this Rect rect, float x)
		{
			rect.x += x;
			return lastRect = rect;
		}

		/// <summary>
		/// Move the y position of this rect
		/// </summary>
		public static Rect MoveY(this Rect rect, float y)
		{
			rect.y += y;
			return lastRect = rect;
		}

		/// <summary>
		/// Change the width of this rect
		/// </summary>
		public static Rect ChangeWidth(this Rect rect, float width)
		{
			rect.width += width;
			return lastRect = rect;
		}

		/// <summary>
		/// Change the height of this rect
		/// </summary>
		public static Rect ChangeHeight(this Rect rect, float height)
		{
			rect.height += height;
			return lastRect = rect;
		}

		/// <summary>
		/// Move this rect
		/// </summary>
		public static Rect Move(this Rect rect, float x, float y) => Move(rect, new Vector2(x, y));

		/// <summary>
		/// Move this rect
		/// </summary>
		public static Rect Move(this Rect rect, Vector2 position)
		{
			rect.position += position;
			return lastRect = rect;
		}

		/// <summary>
		/// Change the size of this rect
		/// </summary>
		public static Rect ChangeSize(this Rect rect, float width, float height) => ChangeSize(rect, new Vector2(width, height));

		/// <summary>
		/// Change the size of this rect
		/// </summary>
		public static Rect ChangeSize(this Rect rect, Vector2 size)
		{
			rect.size += size;
			return lastRect = rect;
		}

		/// <summary>
		/// Grow a rect on all sides by the given offset
		/// </summary>
		public static Rect Grow(this Rect rect, float offset)
		{
			return Shrink(rect, -offset);
		}

		/// <summary>
		/// Grow a rect on all sides by the given horizontal and vertical offsets, 
		/// </summary>
		public static Rect Grow(this Rect rect, float offsetH, float offsetV)
		{
			return Shrink(rect, -offsetH, -offsetV);
		}

		/// <summary>
		/// Grow a rect by the given offsets for each side 
		/// </summary>
		public static Rect Grow(this Rect rect, float top, float right, float bottom, float left)
		{
			return Shrink(rect, -top, -right, -bottom, -left);
		}

		/// <summary>
		/// Grow a rect on all sides by the given factor
		/// </summary>
		public static Rect GrowBy(this Rect rect, float factor)
		{
			return ShrinkBy(rect, 1 / factor);
		}

		/// <summary>
		/// Grow a rect on all sides by the given horizontal and vertical factors, 
		/// </summary>
		public static Rect GrowBy(this Rect rect, float factorH, float factorV)
		{
			return ShrinkBy(rect, 1 / factorH, 1 / factorV);
		}

		/// <summary>
		/// Shrink a rect on all sides by the given offset
		/// </summary>
		public static Rect Shrink(this Rect rect, float offset)
		{
			rect.position += Vector2.one * offset;
			rect.size -= Vector2.one * offset * 2;
			return lastRect = rect;
		}

		/// <summary>
		/// Shrink a rect on all sides by the given horizontal and vertical offsets, 
		/// </summary>
		public static Rect Shrink(this Rect rect, float offsetH, float offsetV)
		{
			rect.x += offsetH;
			rect.y += offsetV;
			rect.width -= offsetH * 2;
			rect.height -= offsetV * 2;
			return lastRect = rect;
		}

		/// <summary>
		/// Shrink a rect by the given offsets for each side 
		/// </summary>
		public static Rect Shrink(this Rect rect, float top, float right, float bottom, float left)
		{
			rect.x += left;
			rect.y += top;
			rect.width -= left + right;
			rect.height -= top + bottom;
			return lastRect = rect;
		}

		/// <summary>
		/// Shrink a rect on all sides by the given factor
		/// </summary>
		public static Rect ShrinkBy(this Rect rect, float factor)
		{
			return Shrink(rect, (rect.width - rect.width * factor) / 2, (rect.height - rect.height * factor) / 2);
		}

		/// <summary>
		/// Shrink a rect on all sides by the given horizontal and vertical factors, 
		/// </summary>
		public static Rect ShrinkBy(this Rect rect, float factorH, float factorV)
		{
			return Shrink(rect, (rect.width - rect.width * factorH) / 2, (rect.height - rect.height * factorV) / 2);
		}

		/// <summary>
		/// Shrink a rect on all sides by the given factors, 
		/// </summary>
		public static Rect ShrinkBy(this Rect rect, float top, float right, float bottom, float left)
		{
			float xOffset = rect.width * left;
			float yOffset = rect.height * top;
			float width = rect.width - rect.width * (left + right);
			float height = rect.height - rect.height * (top + bottom);

			return lastRect = new Rect(rect.x + xOffset, rect.y + yOffset, width, height);
		}

		/// <summary>
		/// Center this rect in relation to another rect
		/// </summary>
		public static Rect Center(this Rect rect, Rect other)
		{
			rect.x = other.width / 2 - rect.width / 2 + other.x;
			rect.y = other.height / 2 - rect.height / 2 + other.y;
			return lastRect = rect;
		}

		/// <summary>
		/// Center this rect horizontally in relation to another rect
		/// </summary>
		public static Rect CenterH(this Rect rect, Rect other)
		{
			rect.x = other.width / 2 - rect.width / 2 + other.x;
			return lastRect = rect;
		}

		/// <summary>
		/// Center this rect vertically in relation to another rect
		/// </summary>
		public static Rect CenterV(this Rect rect, Rect other)
		{
			rect.y = other.height / 2 - rect.height / 2 + other.y;
			return lastRect = rect;
		}

		/// <summary>
		/// Fit this rect to the position and size of another rect
		/// </summary>
		public static Rect Fit(this Rect rect, Rect other)
		{
			rect.position = other.position;
			rect.size = other.size;
			return lastRect = rect;
		}

		/// <summary>
		/// Fit this rect horizontally in another rect
		/// </summary>
		public static Rect FitH(this Rect rect, Rect other)
		{
			rect.x = other.x;
			rect.width = other.width;
			return lastRect = rect;
		}

		/// <summary>
		/// Fit this rect vertically in another rect
		/// </summary>
		public static Rect FitV(this Rect rect, Rect other)
		{
			rect.y = other.y;
			rect.height = other.height;
			return lastRect = rect;
		}

		/// <summary>
		/// Make a rect that comes after horizontally
		/// </summary>
		public static Rect LayoutRight(this Rect rect) => LayoutRight(rect, 0);

		/// <summary>
		/// Make a rect that comes after horizontally, with the given spacing
		/// </summary>
		public static Rect LayoutRight(this Rect rect, float spacing)
		{
			rect.x += rect.width + spacing;
			return lastRect = rect;
		}

		/// <summary>
		/// Make a rect that comes after vertically
		/// </summary>
		public static Rect LayoutBottom(this Rect rect) => LayoutBottom(rect, 0);

		/// <summary>
		/// Make a rect that comes after vertically, with the given spacing
		/// </summary>
		public static Rect LayoutBottom(this Rect rect, float spacing)
		{
			rect.y += rect.height + spacing;
			return lastRect = rect;
		}

		/// <summary>
		/// Make a rect that comes before horizontally
		/// </summary>
		public static Rect LayoutLeft(this Rect rect) => LayoutLeft(rect, 0);

		/// <summary>
		/// Make a rect that comes before horizontally, with the given spacing
		/// </summary>
		public static Rect LayoutLeft(this Rect rect, float spacing)
		{
			rect.x -= rect.width + spacing;
			return lastRect = rect;
		}

		/// <summary>
		/// Make a rect that comes before vertically
		/// </summary>
		public static Rect LayoutTop(this Rect rect) => LayoutTop(rect, 0);

		/// <summary>
		/// Make a rect that comes before vertically, with the given spacing
		/// </summary>
		public static Rect LayoutTop(this Rect rect, float spacing)
		{
			rect.y -= rect.height + spacing;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a horizontal slice of a rect whose width is the original width times the given factor, and return the indexth one
		/// </summary>
		public static Rect SliceH(this Rect rect, float factor, int index)
		{
			if (float.IsNaN(factor))
				return lastRect = rect;

			rect.width *= factor;
			rect.x += index * rect.width;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a vertical slice of a rect whose height is the original height times the given factor, and return the indexth one
		/// </summary>
		public static Rect SliceV(this Rect rect, float factor, int index)
		{
			if (float.IsNaN(factor))
				return lastRect = rect;

			rect.height *= factor;
			rect.y += index * rect.height;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a horizontal slice of a rect with the given width, and return the indexth one
		/// </summary>
		public static Rect FixedSliceH(this Rect rect, float width, int index)
		{
			rect.width = width;
			rect.x += index * rect.width;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a horizontal slice of a rect with the given height, and return the indexth one
		/// </summary>
		public static Rect FixedSliceV(this Rect rect, float height, int index)
		{
			rect.height = height;
			rect.y += index * rect.height;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a horizontal center slice of this rect whose width is multiplied by the factor
		/// </summary>
		public static Rect CenterSliceH(this Rect rect, float factor)
		{
			rect.x += (rect.width - rect.width * factor) / 2;
			rect.width *= factor;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a vertical center slice of this rect whose height is multiplied by the factor
		/// </summary>
		public static Rect CenterSliceV(this Rect rect, float factor)
		{
			rect.y += (rect.height - rect.height * factor) / 2;
			rect.height *= factor;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a horizontal center slice of this rect with the given width
		/// </summary>
		public static Rect FixedCenterSliceH(this Rect rect, float width)
		{
			rect.x += (rect.width - width) / 2;
			rect.width = width;
			return lastRect = rect;
		}

		/// <summary>
		/// Take a vertical center slice of this rect whose with the given height
		/// </summary>
		public static Rect FixedCenterSliceV(this Rect rect, float height)
		{
			rect.y += (rect.height - height) / 2;
			rect.height = height;
			return lastRect = rect;
		}

		/// <summary>
		/// Take the left half of this rect
		/// </summary>
		public static Rect LeftHalf(this Rect rect) => SliceH(rect, .5f, 0);

		/// <summary>
		/// Take the right half of this rect
		/// </summary>
		public static Rect RightHalf(this Rect rect) => SliceH(rect, .5f, 1);

		/// <summary>
		/// Take the top half of this rect
		/// </summary>
		public static Rect TopHalf(this Rect rect) => SliceV(rect, .5f, 0);

		/// <summary>
		/// Take the bottom half of this rect
		/// </summary>
		public static Rect BottomHalf(this Rect rect) => SliceV(rect, .5f, 1);

		/// <summary>
		/// Take the left half of this rect, with the specified [0-1] midpoint
		/// </summary>
		public static Rect LeftHalf(this Rect rect, float midpoint) => SliceH(rect, midpoint, 0);

		/// <summary>
		/// Take the right half of this rect, with the specified [0-1] midpoint
		/// </summary>
		public static Rect RightHalf(this Rect rect, float midpoint) => RemainderH(rect, midpoint);

		/// <summary>
		/// Take the top half of this rect, with the specified [0-1] midpoint
		/// </summary>
		public static Rect TopHalf(this Rect rect, float midpoint) => SliceV(rect, midpoint, 0);

		/// <summary>
		/// Take the bottom half of this rect, with the specified [0-1] midpoint
		/// </summary>
		public static Rect BottomHalf(this Rect rect, float midpoint) => RemainderV(rect, midpoint);

		/// <summary>
		/// Get a rect whose left hand side is moved right by the given amount
		/// </summary>
		public static Rect RemainderH(this Rect rect, float factor)
		{
			rect.x += rect.width * factor;
			rect.width *= 1 - factor;
			return lastRect = rect;
		}

		/// <summary>
		/// Get a rect whose top side is moved right by the given amount
		/// </summary>
		public static Rect RemainderV(this Rect rect, float factor)
		{
			rect.y += rect.height * factor;
			rect.height *= 1 - factor;
			return lastRect = rect;
		}

		/// <summary>
		/// Get a rect whose left hand side is moved right by the given offset
		/// </summary>
		public static Rect FixedRemainderH(this Rect rect, float width)
		{
			rect.x += width;
			rect.width -= width;
			return lastRect = rect;
		}

		/// <summary>
		/// Get a rect whose top side is moved right by the given offset
		/// </summary>
		public static Rect FixedRemainderV(this Rect rect, float height)
		{
			rect.y += height;
			rect.height -= height;
			return lastRect = rect;
		}

		/// <summary>
		/// Get the right half of this rect with the given width
		/// </summary>
		public static Rect FixedRightHalf(this Rect rect, float width)
		{
			rect.x += rect.width - width;
			rect.width = width;
			return lastRect = rect;
		}

		/// <summary>
		/// Get the bottom half of this rect with the given height
		/// </summary>
		public static Rect FixedBottomHalf(this Rect rect, float height)
		{
			rect.y += rect.height - height;
			rect.height = height;
			return lastRect = rect;
		}

		/// <summary>
		/// Creates a tooltip area for this rect, when there's no other possible way
		/// </summary>
		public static Rect Tooltip(this Rect rect, object tooltip)
		{
			GUI.Label(rect, new GUIContent(default(string), tooltip.ToString()));
			return lastRect = rect;
		}
	}
}