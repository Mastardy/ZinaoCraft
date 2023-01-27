using OpenTK.Mathematics;

namespace ZinaoCraft;

public abstract class Entity : IEquatable<Entity>
{
    protected readonly string id;
    public string ID => id;

    public readonly List<Component> components = new();

    public Transform transform;

    public Entity()
    {
        id = Guid.NewGuid().ToString();
        transform = new Transform(this, Vector3.Zero, Quaternion.Identity, Vector3.One);
    }

    public Entity(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        id = Guid.NewGuid().ToString();
        transform = new Transform(this, position, rotation, scale);
    }


    public void AddComponent(Component component)
    {
        components.Add(component);
    }

    public T? GetComponent<T>() where T : Component
    {
        for(int i = 0; i < components.Count; i++)
        {
            var component = components[i];

            if (component.GetType() == typeof(T))
            {
                return (T)component;
            }
        }

        return null;
    }

    public bool Equals(Entity? other) => other?.id == id;
    public override bool Equals(object? obj) => Equals(obj as Entity);
    public override int GetHashCode() => id.GetHashCode();
}