namespace ZinaoCraft;

public abstract class Component : IEquatable<Component>
{
    protected readonly string id;
    public string Id => id;
    
    public Entity parent;

    protected Component(Entity parent)
    {
        this.parent = parent;
        id = Guid.NewGuid().ToString();
    }

    public bool Equals(Component? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Component);
    public override int GetHashCode() => id.GetHashCode();
}
