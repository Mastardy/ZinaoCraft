﻿using OpenTK.Graphics.OpenGL4;

namespace ZinaoCraft;

public abstract class Mesh : Component
{
    public int vertexArrayObject;
    public int vertexBufferObject;
    public int elementBufferObject;

    public Vertex[] vertices;
    public uint[] indices;

    public Material material;

    public Mesh(Entity parent) : base(parent)
    {
        vertices = Array.Empty<Vertex>();
        indices = Array.Empty<uint>();

        vertexArrayObject = GL.GenVertexArray();
        vertexBufferObject = GL.GenBuffer();
        elementBufferObject = GL.GenBuffer();

        material = ResourceManager.GetMaterial("DefaultMaterial");

        World.AddComponent<MeshRenderer>(this);
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
    }
}
