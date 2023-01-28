namespace ZinaoCraft;

public abstract class Entity : IEquatable<Entity>
{
    protected readonly string id;
    public string Id => id;

    public readonly List<Component> components = new();

    protected Entity() => id = Guid.NewGuid().ToString();

    public void AddComponent<T>(T component) where T : Component
    {
        components.Add(component);
        World.AddComponent(component);
    }

    public T? GetComponent<T>() where T : Component
    {
        for(int i = 0; i < components.Count; i++)
        {
            var component = components[i];
            if (component.GetType() == typeof(T)) return (T)component;
        }

        return null;
    }

    public bool Equals(Entity? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Entity);
    public override int GetHashCode() => id.GetHashCode();
}