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

        ResourceManager.Create<Mesh>("CubeMesh", new BlockMesh());

        var positions = ChunkGenerator.GenerateChunk(0, 0);
        
        for (int x = 0; x < 16; x++)
        {
            for (int y = 0; y < 16; y++)
            {
                var block = new Block();
                World.Instantiate(block);
                block.GetComponent<Transform>().position = positions[y + x * 16];
            }
        }
    }
    
    public static void OnUpdate()
    {
        SystemManager.Update();

        if (Input.GetKeyDown(Keys.Escape)) Close();
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
