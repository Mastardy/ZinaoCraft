using OpenTK.Graphics.OpenGL4;

namespace ZinaoCraft;

public class Material
{
    private Shader shader;

    public Material()
    {
        shader = ResourceManager.GetShader("DefaultShader");
        GL.GetProgramInterface(shader.id, ProgramInterface.Uniform, ProgramInterfaceParameter.ActiveResources, out int uniformCount);

        ProgramProperty[] properties = new[] { ProgramProperty.NameLength, ProgramProperty.Type, ProgramProperty.ArraySize };
        int[] values = new int[3];

        for (int i = 0; i < uniformCount; i++)
        {
            GL.GetProgramResource(shader.id, ProgramInterface.Uniform, i, 3, properties, 3, out int _, values);
            GL.GetProgramResourceName(shader.id, ProgramInterface.Uniform, i, values[0], out int _, out string name);
            Console.WriteLine("Name: " + name + "\nType: " + (AttributeType)values[1] + "\nArraySize: " + values[2] + "\n");
        }
    }
}