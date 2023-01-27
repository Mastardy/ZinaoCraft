using OpenTK.Graphics.OpenGL4;

namespace ZinaoCraft;

public class MeshRenderer : System
{
    public MeshRenderer() : base(SystemUpdateOrder.Render) { }
    
    public override void Update()
    {
        var renderables = World.GetComponents<Renderable>();
        if (renderables == null) return;

        for (int i = 0; i < renderables.Count; i++)
        {
            var mesh = renderables[i].Mesh;
            var material = renderables[i].Material;
            
            GL.BindVertexArray(mesh.VertexArrayObject);
            
            material.Use();
            
            GL.DrawElements(PrimitiveType.Triangles, mesh.Indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}