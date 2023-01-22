using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ZinaoCraft;

public class MeshRenderer : System
{
    public MeshRenderer() { }

    public void Render()
    {
        for (int i = 0; i < components.Count; i++)
        {
            if (components[i] is not Mesh mesh) throw new NullReferenceException("Mesh was null!");

            var model = Matrix4.Identity;
            var view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            var projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), Game.window.Size.X / Game.window.Size.Y, 0.1f, 100.0f);

            GL.BindVertexArray(mesh.vertexArrayObject);

            var defaultShader = ResourceManager.GetShader("DefaultShader");
            var container = ResourceManager.GetTexture("Container");

            defaultShader.Use();
            container.Use();

            GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "model"), true, ref model);
            GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "view"), true, ref view);
            GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "projection"), true, ref projection);

            GL.DrawElements(PrimitiveType.Triangles, mesh.indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}