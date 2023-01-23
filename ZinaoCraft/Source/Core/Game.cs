using OpenTK.Graphics.ES11;
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

    public static void OnLoad()
    {
        ResourceManager.CreateShader("DefaultShader", @"Shaders\DefaultShader.vert", @"Shaders\DefaultShader.frag");
        ResourceManager.CreateTexture("Container", @"Textures\container.jpg");

        var uniforms = new Dictionary<string, List<object>>
        {
            { "model", new List<object>() { Matrix4.Identity } },
            { "view", new List<object>() { Matrix4.CreateTranslation(0.0f, 0.0f, -10.0f) } },
            { "projection", new List<object>() { Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), Game.window.Size.X / Game.window.Size.Y, 0.1f, 100.0f) }}
        };

        var textures = new List<Texture>
        {
            ResourceManager.GetTexture("Container")
        };
        
        ResourceManager.CreateMaterial("DefaultMaterial", ResourceManager.GetShader("DefaultShader"), uniforms, textures);
    }

    public static void OnUpdate()
    {
        if (Input.GetKeyDown(Keys.Escape)) Close();

        if (Input.GetKeyDown(Keys.J)) World.Instantiate(new Block());
        if (Input.GetKeyDown(Keys.K)) World.Destroy(World.All[^1]);

        for(int i = 0; i < World.All.Count; i++)
        {
            if (Input.GetKeyDown(Keys.W))
            {
                World.All[i].transform.position = new Vector3(0, 1 + i, 0);
            }
            if (Input.GetKeyDown(Keys.S))
            {
                World.All[i].transform.position = new Vector3(0, -1 - i, 0);
            }
            if (Input.GetKeyDown(Keys.A))
            {
                World.All[i].transform.position = new Vector3(-1 - i, 0, 0);
            }
            if (Input.GetKeyDown(Keys.D))
            {
                World.All[i].transform.position = new Vector3(1 + i, 0, 0);
            }
        }
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
