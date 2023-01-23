using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Block : Entity
{
    public Block() : base()
    {
        AddComponent(new BlockMesh(this));
    }

    public Block(Vector3 position, Quaternion rotation, Vector3 scale) : base(position, rotation, scale)
    {
        AddComponent(new BlockMesh(this));
    }
}
