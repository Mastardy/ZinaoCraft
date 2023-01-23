using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Material
{
    private readonly Shader shader;
    private readonly Dictionary<string, List<object>> uniforms = new();
    private readonly List<Texture> textures = new();

    public Material(Shader shader, Dictionary<string, List<object>> uniforms, List<Texture> textures)
    {
        this.shader = shader;
        this.uniforms = uniforms;
        this.textures = textures;
    }

    public void Use()
    {
        shader.Use();

        for(int i = 0; i < textures.Count; i++)
        {
            GL.ActiveTexture(TextureUnit.Texture0 + i);
            textures[i].Use();
        }

        foreach(var pair in uniforms)
        {
            switch (pair.Value.Count)
            {
                case 1:
                    SetUniform(pair.Key, pair.Value[0]);
                    break;
                case 2:
                    SetUniform(pair.Key, pair.Value[0], pair.Value[1]);
                    break;
                case 3:
                    SetUniform(pair.Key, pair.Value[0], pair.Value[1], pair.Value[2]);
                    break;
                case 4:
                    SetUniform(pair.Key, pair.Value[0], pair.Value[1], pair.Value[2], pair.Value[3]);
                    break;
                default:
                    throw new Exception("Uniform had more than 4 values!");
            }
        }
    }

    public void ChangeUniform(string name, params object[] values)
    {
        if (!uniforms.ContainsKey(name)) return;
        uniforms[name] = values.ToList();
    }

    private void SetUniform(string name, object value)
    {
        var location = GL.GetUniformLocation(shader.id, name);

        if (value is int) GL.Uniform1(location, (int)value);
        else if (value is uint) GL.Uniform1(location, (uint)value);
        else if (value is float) GL.Uniform1(location, (uint)value);
        else if (value is double) GL.Uniform1(location, (double)value);
        else if (value is Matrix4 matrix) GL.UniformMatrix4(location, true, ref matrix);
        else throw new Exception("Unrecognized Uniform: " + value.GetType());
    }

    private void SetUniform(string name, object value1, object value2)
    {
        var location = GL.GetUniformLocation(shader.id, name);

        if (value1.GetType() != value2.GetType()) throw new Exception("Values were not the same type!");

        if (value1 is int) GL.Uniform2(location, (int)value1, (int)value2);
        else if (value1 is uint) GL.Uniform2(location, (uint)value1, (uint)value2);
        else if (value1 is float) GL.Uniform2(location, (float)value1, (float)value2);
        else if (value1 is double) GL.Uniform2(location, (double)value1, (double)value2);
        else throw new Exception("Unrecognized Uniform: " + value1.GetType());
    }

    private void SetUniform(string name, object value1, object value2, object value3)
    {
        var location = GL.GetUniformLocation(shader.id, name);

        if (value1.GetType() != value2.GetType() || value1.GetType() != value3.GetType()) throw new Exception("Values were not the same type!");

        if (value1 is int) GL.Uniform3(location, (int)value1, (int)value2, (int)value3);
        else if (value1 is uint) GL.Uniform3(location, (uint)value1, (uint)value2, (uint)value3);
        else if (value1 is float) GL.Uniform3(location, (float)value1, (float)value2, (float)value3);
        else if (value1 is double) GL.Uniform3(location, (double)value1, (double)value2, (double)value3);
        else throw new Exception("Unrecognized Uniform: " + value1.GetType());
    }

    private void SetUniform(string name, object value1, object value2, object value3, object value4)
    {
        var location = GL.GetUniformLocation(shader.id, name);

        if (value1.GetType() != value2.GetType() || value1.GetType() != value3.GetType() || value1.GetType() != value4.GetType()) throw new Exception("Values were not the same type!");

        if (value1 is int) GL.Uniform4(location, (int)value1, (int)value2, (int)value3, (int)value4);
        else if (value1 is uint) GL.Uniform4(location, (uint)value1, (uint)value2, (uint)value3, (uint)value4);
        else if (value1 is float) GL.Uniform4(location, (float)value1, (float)value2, (float)value3, (float)value4);
        else if (value1 is double) GL.Uniform4(location, (double)value1, (double)value2, (double)value3, (double)value4);
        else throw new Exception("Unrecognized Uniform: " + value1.GetType());
    }
}