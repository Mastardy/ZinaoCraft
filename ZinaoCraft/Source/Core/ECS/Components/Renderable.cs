using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Renderable : Component
{
    public Mesh Mesh { get; }
    public Material Material { get; }

    public Renderable(Entity parent) : base(parent)
    {
        Mesh = ResourceManager.Get<Mesh>("CubeMesh");
        
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
        
        Material = new Material(ResourceManager.Get<Shader>("DefaultShader"), uniforms, textures);
    }
}