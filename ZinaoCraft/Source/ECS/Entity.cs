namespace ZinaoCraft;

public abstract class Entity : IEquatable<Entity>
{
    protected readonly string id;
    public string ID => id;

    private readonly List<Component> components = new();

    public Entity()
    {
        id = Guid.NewGuid().ToString();
    }

    public void AddComponent(Component component)
    {
        components.Add(component);
    }

    public bool Equals(Entity? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Entity);
    public override int GetHashCode() => id.GetHashCode();
}