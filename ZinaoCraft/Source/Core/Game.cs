using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ZinaoCraft;

public static class Game
{
    public static Window window = new(800, 600, "Test Window");

    public static void Run()
    {
        window.Run();
    }

    public static void OnLoad()
    {
        World.Instantiate(new Block());

        ResourceManager.CreateShader("DefaultShader", @"Shaders\DefaultShader.vert", @"Shaders\DefaultShader.frag");
        ResourceManager.CreateTexture("Container", @"Textures\container.jpg");
        Material mat = new Material();
    }

    public static void OnUpdate()
    {
        if (Input.GetKeyDown(Keys.Escape)) Close();
    }

    public static void OnRender()
    {
        var meshRenderer = World.GetSystem<MeshRenderer>();
        meshRenderer?.Render();
    }

    public static void Close()
    {
        window.Close();
    }
}
