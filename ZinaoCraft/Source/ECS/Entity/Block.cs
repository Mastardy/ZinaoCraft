namespace ZinaoCraft;

public class Block : Entity
{
    public Block() : base()
    {
        AddComponent(new BlockMesh(this));
    }
}
