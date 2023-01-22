using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ZinaoCraft;

public static class Input
{
    public static KeyboardState? keyboardState;

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
}
