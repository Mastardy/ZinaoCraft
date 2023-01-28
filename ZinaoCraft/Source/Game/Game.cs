using System.Diagnostics;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ZinaoCraft;

public static class Game
{
    public static Window window = new(800, 600, "Test Window");

    public static void Run()
    {
        window.Run();
    }

    private static FirstPersonCamera? camera;

    public static void OnLoad()
    {
        SystemManager.RegisterSystems();

        camera = new FirstPersonCamera();
        World.Instantiate(camera);
        
        ResourceManager.Create("DefaultShader", new Shader(@"Shaders\DefaultShader.vert", @"Shaders\DefaultShader.frag"));
        ResourceManager.Create("Container", new Texture(@"Textures\container.jpg"));

        var uniforms = new Dictionary<string, List<object>>
        {
            { "transform", new List<object>() { Matrix4.Identity } },
            { "view", new List<object>() { Matrix4.CreateTranslation(0.0f, 0.0f, 0.0f) } },
            { "projection", new List<object>() { Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), Game.window.Size.X / Game.window.Size.Y, 0.1f, 100.0f) }}
        };

        var textures = new List<Texture>
        {
            ResourceManager.Get<Texture>("Container")
        };
        
        ResourceManager.Create("DefaultMaterial", new Material(ResourceManager.Get<Shader>("DefaultShader"), uniforms, textures));
        
        ResourceManager.Create<Mesh>("CubeMesh", new BlockMesh());
    }

    public static void OnUpdate()
    {
        SystemManager.Update();

        if (Input.GetKeyDown(Keys.Escape)) Close();

        if (Input.GetKeyDown(Keys.J)) World.Instantiate(new Block());
        if (Input.GetKeyDown(Keys.K) && World.All.Count > 1) World.Destroy(World.All[^1]);
    }

    public static void OnRender()
    {
        SystemManager.Render();
    }

    public static void Close()
    {
        window.Close();
        ResourceManager.DisposeAll();
    }
}
