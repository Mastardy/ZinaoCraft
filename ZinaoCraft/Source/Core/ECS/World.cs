using System.Collections.ObjectModel;

namespace ZinaoCraft;

public static class World
{
    private readonly static List<Entity> all = new();
    private readonly static Dictionary<Type, System> systems = new();

    public static ReadOnlyCollection<Entity> All => all.AsReadOnly();

    public static void Instantiate(Entity entity) => all.Add(entity);

    public static void AddComponent<T>(Component component) where T : System, new()
    {
        if (systems.ContainsKey(typeof(T)))
        {
            systems[typeof(T)].AddComponent(component);
            return;
        }
        
        var system = new T();
        systems.Add(typeof(T), system);
        system.AddComponent(component);
    }

    public static T? GetSystem<T>() where T : System
    {
        systems.TryGetValue(typeof(T), out var system);
        return system == null ? null : (T)system;
    }

    public static void Destroy(Entity entity)
    {
        all.Remove(entity);
        for(int i = 0; i < entity.components.Count; i++)
        {
            var component = entity.components[i];
            systems[component.systemType].RemoveComponent(component);
        }
        entity.components.Clear();
        all.TrimExcess();
    }
}