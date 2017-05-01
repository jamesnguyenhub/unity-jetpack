# unity-jetpack
Unity practice

* Rigidbody2D -> Constraints -> Freeze x, y, z to fix position, angle
* At least one object must have a rigidbody to detect collision

## Vertext snapping
Select the room background object that you want to move. Don’t forget to release the mouse button. Then hold the V key and move a mouse to the corner you wan to use as a pivot point.
This will be one of the left corners, for the background to the right of the window, and one of the right corners (any) for background to the left of the window.
Note how the blue point shows which vertex will be used as pivot point.
After selecting the pivot point hold down the left mouse button and start moving the object. You will notice that you can only move the object so that it’s pivot point matches the position of other sprite’s corner (vertex).

```java
float height = 2.0f * Camera.main.orthographicSize;
screenWidthInPoints = height * Camera.main.aspect;
```
