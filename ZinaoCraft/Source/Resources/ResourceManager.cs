using OpenTK.Graphics.OpenGL;

namespace ZinaoCraft;

public static class ResourceManager
{
    private static readonly Dictionary<string, Texture> textures = new();
    private static readonly Dictionary<string, Shader> shaders = new();

    public static void CreateShader(string name, string vertexPath, string fragmentPath, string geometryPath = "null")
    {
        shaders.Add(name, new Shader(vertexPath, fragmentPath, geometryPath));
    }

    public static void CreateTexture(string name, string path)
    {
        textures.Add(name, new Texture(path));
    }

    public static Shader GetShader(string name)
    {
        if (!shaders.ContainsKey(name)) throw new Exception($"There's no shader named {name} in the ResourceManager.");
        var shader = shaders[name];
        if (shader == null) throw new NullReferenceException($"Shader {name} was null!");
        
        return shader;
    }
    
    public static Texture GetTexture(string name)
    {
        if (!textures.ContainsKey(name)) throw new Exception($"There's no texture named {name} in the ResourceManager.");
        var texture = textures[name];
        if (texture == null) throw new NullReferenceException($"Texture {name} was null!");

        return texture;
    }

    public static void DestroyShader(string name)
    {
        if (!shaders.ContainsKey(name)) throw new Exception($"There's no shader named {name} in the ResourceManager.");
        var shader = shaders[name];
        if (shader == null) throw new NullReferenceException($"Shader {name} was null!");

        shader.Dispose();
        shaders.Remove(name);
    }

    public static void DestroyTexture(string name)
    {
        if (!textures.ContainsKey(name)) throw new Exception($"There's no texture named {name} in the ResourceManager.");
        var texture = textures[name];
        if (texture == null) throw new NullReferenceException($"Texture {name} was null!");

        texture.Dispose();
        textures.Remove(name);
    }

    public static void Dispose()
    {
        foreach (var shader in shaders.Values)
        {
            shader.Dispose();
        }
        shaders.Clear();

        foreach(var texture in textures.Values)
        {
            texture.Dispose();
        }
        textures.Clear();
    }
}