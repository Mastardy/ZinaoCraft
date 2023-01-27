using OpenTK.Graphics.OpenGL4;

namespace ZinaoCraft;

public abstract class Mesh : IDisposable
{
    private bool disposed;
    
    private readonly int vertexArrayObject;
    private readonly int vertexBufferObject;
    private readonly int elementBufferObject;

    protected Vertex[] vertices;
    protected uint[] indices;

    public Mesh()
    {
        vertices = Array.Empty<Vertex>();
        indices = Array.Empty<uint>();

        vertexArrayObject = GL.GenVertexArray();
        vertexBufferObject = GL.GenBuffer();
        elementBufferObject = GL.GenBuffer();
    }

    public void UpdateMesh()
    {
        GL.BindVertexArray(vertexArrayObject);

        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexBufferObject);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * 5 * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, elementBufferObject);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

        GL.EnableVertexAttribArray(0);
        GL.EnableVertexAttribArray(1);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));

        GL.BindVertexArray(0);
        GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, 0);
    }
    
    protected virtual void Dispose(bool _)
    {
        if (disposed) return;

        GL.DeleteVertexArray(vertexArrayObject);
        GL.DeleteBuffer(vertexBufferObject);
        GL.DeleteBuffer(elementBufferObject);
        
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
