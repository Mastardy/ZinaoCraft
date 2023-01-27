using OpenTK.Graphics.OpenGL4;

namespace ZinaoCraft;

public class MeshRenderer : System
{
    public MeshRenderer() { }

    public void Render()
    {
        for (int i = 0; i < components.Count; i++)
        {
            // TODO: Make a MeshRenderer, MeshComponent and MaterialComponent!
            
            // if (components[i] is not Mesh mesh) throw new NullReferenceException("Mesh was null!");
            //
            // GL.BindVertexArray(mesh.vertexArrayObject);
            //
            // mesh.material.ChangeUniform("model", mesh.parent.transform.GetTransform());
            //
            // mesh.material.Use();
            //
            // GL.DrawElements(PrimitiveType.Triangles, mesh.indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}