namespace ZinaoCraft;

public abstract class Component : IEquatable<Component>
{
    protected string id;
    public Entity parent;

    public Component(Entity parent)
    {
        this.parent = parent;
        id = Guid.NewGuid().ToString();
    }

    public bool Equals(Component? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Component);
    public override int GetHashCode() => id.GetHashCode();
}
