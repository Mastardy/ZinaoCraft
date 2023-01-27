using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Block : Entity
{
    public Block()
    {
        AddComponent(new Transform(this));
        AddComponent(new Renderable(this));
    }
}
