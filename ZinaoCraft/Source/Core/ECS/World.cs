using System.Collections.ObjectModel;

namespace ZinaoCraft;

public static class World
{
    private static readonly List<Entity> all = new();
    private static readonly Dictionary<Type, List<Component>> components = new();
    
    public static ReadOnlyCollection<Entity> All => all.AsReadOnly();
    public static ReadOnlyDictionary<Type, List<Component>> Components => components.AsReadOnly();

    public static void Instantiate(Entity entity) => all.Add(entity);

    public static void Destroy(Entity entity)
    {
        if (!all.Contains(entity)) return;

        for (int i = entity.components.Count - 1; i >= 0; i--) DestroyComponent(entity.components[i]);
        
        all.Remove(entity);        
        all.TrimExcess();
    }

    public static void AddComponent<T>(T component) where T : Component
    {
        var componentType = typeof(T);
        if (!components.ContainsKey(componentType)) components.Add(componentType, new List<Component>());
        
        components[componentType].Add(component);
    }

    public static void DestroyComponent<T>(T component) where T : Component
    {
        var componentType = typeof(T);
        if(componentType == typeof(Component)) componentType = component.GetType();
        
        if (!components.TryGetValue(componentType, out var subComponents)) return;

        subComponents.Remove(component);
        subComponents.TrimExcess();
    }

    public static void GetComponents<T>(ref List<T> list) where T : Component
    {
        components.TryGetValue(typeof(T), out var subComponents);
        if (subComponents == null) return;

        for (int i = 0; i < subComponents.Count; i++)
        {
            list.Add((T)subComponents[i]);
        }
    }
}