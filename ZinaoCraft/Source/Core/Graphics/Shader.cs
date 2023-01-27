using OpenTK.Graphics.OpenGL4;
using System.Reflection;

namespace ZinaoCraft;

public class Shader : IDisposable
{
    private bool disposed;

    public readonly int id;
    
    public Shader(string vertexPath, string fragmentPath, string geometryPath = "null")
    {
        id = GL.CreateProgram();

        var vertexShader = GL.CreateShader(ShaderType.VertexShader);
        CreateShader(vertexShader, vertexPath, ShaderType.VertexShader);

        var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
        CreateShader(fragmentShader, fragmentPath, ShaderType.FragmentShader);
        
        int geometryShader = 0;

        if (geometryPath != "null")
        {
            geometryShader = GL.CreateShader(ShaderType.GeometryShader);
            CreateShader(geometryShader, geometryPath, ShaderType.GeometryShader);
        }

        GL.AttachShader(id, vertexShader);
        GL.AttachShader(id, fragmentShader);
        if (geometryPath != "nul") GL.AttachShader(id, geometryShader);

        GL.LinkProgram(id);

        GL.GetProgram(id, GetProgramParameterName.LinkStatus, out int success);
        if (success == 0) Console.WriteLine(GL.GetProgramInfoLog(id));

        GL.DetachShader(id, vertexShader);
        GL.DeleteShader(vertexShader);

        GL.DetachShader(id, fragmentShader);
        GL.DeleteShader(fragmentShader);

        if (geometryPath != "null")
        {
            GL.DetachShader(id, geometryShader);
            GL.DeleteShader(geometryShader);
        }
    }

    private static void CreateShader(int shader, string path, ShaderType type)
    {
        string source = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + path);

        GL.ShaderSource(shader, source);

        GL.CompileShader(shader);

        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0)
        {
            Console.WriteLine(GL.GetShaderInfoLog(shader));
        }
    }

    public void Use()
    {
        GL.UseProgram(id);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        GL.DeleteProgram(id);
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}