namespace ZinaoCraft;

public abstract class Component : IEquatable<Component>
{
    protected string id;
    public Type systemType;
    public Entity parent;

    public Component(Entity parent, Type systemType)
    {
        this.parent = parent;
        id = Guid.NewGuid().ToString();
        this.systemType = systemType;
    }

    public bool Equals(Component? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Component);
    public override int GetHashCode() => id.GetHashCode();
}
