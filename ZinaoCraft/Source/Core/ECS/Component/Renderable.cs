namespace ZinaoCraft;

public class Renderable : Component
{
    public Mesh Mesh { get; }
    public Material Material { get; }

    public Renderable(Entity parent) : base(parent)
    {
        Mesh = ResourceManager.Get<Mesh>("CubeMesh");
        Material = ResourceManager.Get<Material>("DefaultMaterial");
    }
}