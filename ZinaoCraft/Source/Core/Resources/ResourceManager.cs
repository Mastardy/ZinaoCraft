using System.Reflection;

namespace ZinaoCraft;

public static class ResourceManager
{
    private static readonly Dictionary<Type, Dictionary<string, object>> objects = new();
    
    private static readonly Dictionary<string, Texture> textures = new();
    private static readonly Dictionary<string, Shader> shaders = new();
    private static readonly Dictionary<string, Material> materials = new();
    private static readonly Dictionary<string, Mesh> meshes = new();

    public static void Create<T>(string name, T obj) where T : class
    {
        var type = typeof(T);
        
        if (!objects.ContainsKey(type)) objects.Add(type, new Dictionary<string, object>());

        objects[type].Add(name, obj);
    }

    public static T Get<T>(string name) where T : class
    {
        var type = typeof(T);
        
        if (!objects.TryGetValue(type, out var subDictionary)) throw new Exception($"[ResourceManager] Couldn't find a Resource of type {type}");
        if (!subDictionary.TryGetValue(name, out object? obj)) throw new Exception($"[ResourceManager] Couldn't find {name} under type {type} resources");
        if (obj == null) throw new NullReferenceException($"[ResourceManager] {name} was null when trying to get it from {type} resources");

        return (T)obj;
    }

    public static void Destroy<T>(string name) where T : class
    {
        var obj = Get<T>(name);

        if(obj is IDisposable disposable) disposable.Dispose();
        
        objects[typeof(T)].Remove(name);
    }

    public static void DisposeAll()
    {
        foreach (var entry in objects)
        {
            foreach(var subEntry in entry.Value)
            {
                MethodInfo destroyMethod = typeof(ResourceManager).GetMethod("Destroy")?.MakeGenericMethod(entry.Key) ?? throw new NullReferenceException("Bruh");
                destroyMethod.Invoke(null, new[] { subEntry.Value });
            }
        }

        objects.Clear();
    }
}