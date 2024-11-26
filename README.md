# Utility
A couple of class, methods, serialization and so on to help and make development more lisible, easier and faster.

## How to install
Go to your unity's root project.\
Under the folder `Packages` open the file `Manifest.json`.\
Add the package and his dependencies to the project :
```json
{
  "dependencies": {
    ...
    "com.lrtools.utility":"https://github.com/Unity-LRTools/Utility.git",
  }
}
```

## Documentation runtime
### Singleton
```csharp
public class MySingleton : Singleton<MySingleton> 
{

}
```
You can access it with the `Instance` property.\
This class also provide an overridable method `OnAwake()` because the singleton already use the `Awake()` method.

### Lazy singletons scriptable object
```csharp
public class MyLazySingleton : LazySingletonScriptableObject<MyLazySingleton> 
{

}
```
It work in editor and in runtime using conditional compilation to optimize the class.\
You can easily access it like common singleton using the `Instance` property.\
Note that those scriptable object will be loaded under the following path: `Assets/Resources/nameof(T)`.

## Documentation editor
### Custom GUI Style
Grand methods accessible with the static class `CustomGUIStyle`. It help overriding specific part of default element's GUI skin.
|Method|Description|
|--|---|
|GUIStyle Label(...)|Override the default `GUI.Skin.Label` property specified in the method parameters.|
|GUIStyle Button(...)|Override the default `GUI.Skin.Button` property specified in the method parameters.|
### Custom GUI Utility
Grand methods accessible with the static class `CustomGUIUtility`. You'll find methods that help you draw things in the editor.
|Method|Description|
|---|--|
|void DrawBorder(Rect rect, Color color, float borderWidth = 1)|Draw the border of a rect.|
|void DrawCross(Rect rect, Color color, float borderWidth = 1)|Draw a cross inside a rect, striking throught middle x and y.|
### Rect Utility
Grant flexible way to manipulate Rect class.
|Method|Description|
|------|-----------|
|`Rect SetLastRect(Rect rect)`|Manually set the last rect to be used by `RectUtility`.|
|`Rect SetX(this Rect rect, float x)`|Set the x position of this rect.|
|`Rect SetY(this Rect rect, float y)`|Set the y position of this rect.|
|`Rect SetWidth(this Rect rect, float width)`|Set the width of this rect.|
|`Rect SetHeight(this Rect rect, float height)`|Set the height of this rect.|
|`Rect LineHeight(this Rect rect)`|Set the height of this rect to `EditorGUIUtility.singleLineHeight`.|
|`Rect Square(this Rect rect, bool oppositeDirection = false)`|Make this rect a square using its smallest dimension. Optionally keep the square on the right or bottom.|
|`Rect DefaultPos(this Rect rect)`|Place this rect at its default position of `(0, 0)`.|
|`Rect SetPos(this Rect rect, float x, float y)`|Set the position of this rect.|
|`Rect SetSize(this Rect rect, float width, float height)`|Set the size of this rect.|
|`Rect MoveX(this Rect rect, float x)`|Move the x position of this rect.|
|`Rect MoveY(this Rect rect, float y)`|Move the y position of this rect.|
|`Rect ChangeWidth(this Rect rect, float width)`|Change the width of this rect.|
|`Rect ChangeHeight(this Rect rect, float height)`|Change the height of this rect.|
|`Rect Move(this Rect rect, float x, float y)`|Move this rect.|
|`Rect ChangeSize(this Rect rect, float width, float height)`|Change the size of this rect.|
|`Rect Grow(this Rect rect, float offset)`|Grow a rect on all sides by the given offset.|
|`Rect GrowBy(this Rect rect, float factor)`|Grow a rect on all sides by the given factor.|
|`Rect Shrink(this Rect rect, float offset)`|Shrink a rect on all sides by the given offset.|
|`Rect ShrinkBy(this Rect rect, float factor)`|Shrink a rect on all sides by the given factor.|
|`Rect Center(this Rect rect, Rect other)`|Center this rect in relation to another rect.|
|`Rect CenterH(this Rect rect, Rect other)`|Center this rect horizontally in relation to another rect.|
|`Rect CenterV(this Rect rect, Rect other)`|Center this rect vertically in relation to another rect.|
|`Rect Fit(this Rect rect, Rect other)`|Fit this rect to the position and size of another rect.|
|`Rect FitH(this Rect rect, Rect other)`|Fit this rect horizontally in another rect.|
|`Rect FitV(this Rect rect, Rect other)`|Fit this rect vertically in another rect.|
|`Rect LayoutRight(this Rect rect)`|Make a rect that comes after horizontally.|
|`Rect LayoutBottom(this Rect rect)`|Make a rect that comes after vertically.|
|`Rect LayoutLeft(this Rect rect)`|Make a rect that comes before horizontally.|
|`Rect LayoutTop(this Rect rect)`|Make a rect that comes before vertically.|
|`Rect SliceH(this Rect rect, float factor, int index)`|Take a horizontal slice of a rect whose width is the original width times the given factor, and return the indexth one.|
|`Rect SliceV(this Rect rect, float factor, int index)`|Take a vertical slice of a rect whose height is the original height times the given factor, and return the indexth one.|
|`Rect FixedSliceH(this Rect rect, float width, int index)`|Take a horizontal slice of a rect with the given width, and return the indexth one.|
|`Rect FixedSliceV(this Rect rect, float height, int index)`|Take a vertical slice of a rect with the given height, and return the indexth one.|
|`Rect CenterSliceH(this Rect rect, float factor)`|Take a horizontal center slice of this rect whose width is multiplied by the factor.|
|`Rect CenterSliceV(this Rect rect, float factor)`|Take a vertical center slice of this rect whose height is multiplied by the factor.|
|`Rect FixedCenterSliceH(this Rect rect, float width)`|Take a horizontal center slice of this rect with the given width.|
|`Rect FixedCenterSliceV(this Rect rect, float height)`|Take a vertical center slice of this rect with the given height.|
|`Rect LeftHalf(this Rect rect)`|Take the left half of this rect.|
|`Rect RightHalf(this Rect rect)`|Take the right half of this rect.|
|`Rect TopHalf(this Rect rect)`|Take the top half of this rect.|
|`Rect BottomHalf(this Rect rect)`|Take the bottom half of this rect.|
|`Rect LeftHalf(this Rect rect, float midpoint)`|Take the left half of this rect, with the specified [0-1] midpoint.|
|`Rect RightHalf(this Rect rect, float midpoint)`|Take the right half of this rect, with the specified [0-1] midpoint.|
|`Rect TopHalf(this Rect rect, float midpoint)`|Take the top half of this rect, with the specified [0-1] midpoint.|
|`Rect BottomHalf(this Rect rect, float midpoint)`|Take the bottom half of this rect, with the specified [0-1] midpoint.|
|`Rect RemainderH(this Rect rect, float factor)`|Get a rect whose left-hand side is moved right by the given amount.|
|`Rect RemainderV(this Rect rect, float factor)`|Get a rect whose top side is moved down by the given amount.|
|`Rect FixedRemainderH(this Rect rect, float width)`|Get a rect whose left-hand side is moved right by the given offset.|
|`Rect FixedRemainderV(this Rect rect, float height)`|Get a rect whose top side is moved down by the given offset.|
|`Rect FixedRightHalf(this Rect rect, float width)`|Get the right half of this rect with the given width.|
|`Rect FixedBottomHalf(this Rect rect, float height)`|Get the bottom half of this rect with the given height.|
|`Rect Tooltip(this Rect rect, object tooltip)`|Creates a tooltip area for this rect.|
### Attributes
|Attribute|Description|
|--|---|
|`[ReadOnly]`|Make a field read only in inspector.| 