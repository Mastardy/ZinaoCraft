using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ZinaoCraft;

public static class Input
{
    public static KeyboardState? keyboardState;
    public static MouseState? mouseState;

    public static Vector2 mousePosition
    {
        get
        {
            if (mouseState == null) return -Vector2.One;
            return mouseState.Position;
        }
    }

    public static Vector2 lastMousePosition
    {
        get
        {
            if (mouseState == null) return -Vector2.One;
            return mouseState.PreviousPosition;
        }
    }

    public static Vector2 mouseDelta
    {
        get
        {
            if (mouseState == null) return -Vector2.One;
            return mousePosition - lastMousePosition;
        }
    }

    public static Vector2 mouseScrollDelta
    {
        get
        {
            if (mouseState == null) return Vector2.Zero;
            return mouseState.ScrollDelta;
        }
    }
    
    public static bool GetKeyDown(Keys key)
    {
        if (keyboardState == null) return false;
        return keyboardState.IsKeyPressed(key);
    }

    public static bool GetKeyUp(Keys key)
    {
        if (keyboardState == null) return false;
        return keyboardState.IsKeyReleased(key);
    }

    public static bool GetKey(Keys key)
    {
        if (keyboardState == null) return false;
        return keyboardState.IsKeyDown(key);
    }

    public static bool GetButtonDown(MouseButton button)
    {
        if (mouseState == null) return false;
        return mouseState.IsButtonPressed(button);
    }
    
    public static bool GetButtonUp(MouseButton button)
    {
        if (mouseState == null) return false;
        return mouseState.IsButtonReleased(button);
    }
    
    public static bool GetButton(MouseButton button)
    {
        if (mouseState == null) return false;
        return mouseState.IsButtonDown(button);
    }
}
