using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System.Diagnostics;

namespace ZinaoCraft;

public class Window : GameWindow
{
    private Texture container;
    private int vbo, vao, ebo;

    private readonly Vertex[] vertices =
    {
        new Vertex { position = new Vector3(-0.5f, -0.5f, 0.5f), texCoords = new Vector2(0.0f, 0.0f) },
        new Vertex { position = new Vector3(-0.5f, 0.5f, 0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(0.5f, -0.5f, 0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, 0.5f), texCoords = new Vector2(1.0f, 1.0f) },

        new Vertex { position = new Vector3(-0.5f, -0.5f, -0.5f), texCoords = new Vector2(0.0f, 0.0f) },
        new Vertex { position = new Vector3(-0.5f, 0.5f, -0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(-0.5f, -0.5f, 0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(-0.5f, 0.5f, 0.5f), texCoords = new Vector2(1.0f, 1.0f) },

        new Vertex { position = new Vector3(-0.5f, -0.5f, -0.5f), texCoords = new Vector2(1.0f, 1.0f) },
        new Vertex { position = new Vector3(-0.5f, 0.5f, -0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, -0.5f, -0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, -0.5f), texCoords = new Vector2(0.0f, 0.0f) },

        new Vertex { position = new Vector3(0.5f, -0.5f, 0.5f), texCoords = new Vector2(0.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, 0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(0.5f, -0.5f, -0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, -0.5f), texCoords = new Vector2(1.0f, 1.0f) },

        new Vertex { position = new Vector3(-0.5f, 0.5f, 0.5f), texCoords = new Vector2(0.0f, 0.0f) },
        new Vertex { position = new Vector3(-0.5f, 0.5f, -0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, 0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, 0.5f, -0.5f), texCoords = new Vector2(1.0f, 1.0f) },

        new Vertex { position = new Vector3(-0.5f, -0.5f, -0.5f), texCoords = new Vector2(0.0f, 0.0f) },
        new Vertex { position = new Vector3(-0.5f, -0.5f, 0.5f), texCoords = new Vector2(0.0f, 1.0f) },
        new Vertex { position = new Vector3(0.5f, -0.5f, -0.5f), texCoords = new Vector2(1.0f, 0.0f) },
        new Vertex { position = new Vector3(0.5f, -0.5f, 0.5f), texCoords = new Vector2(1.0f, 1.0f) }
    };

    private readonly uint[] indices = { 
        0,  1,  2, 
        1,  3,  2,

        4, 5, 6,
        5, 7, 6,

        8, 9, 10,
        9, 11, 10,

        12, 13, 14,
        13, 15, 14,

        16, 17, 18,
        17, 19, 18,

        20, 21, 22,
        21, 23, 22
    };

    public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) { }

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        if (KeyboardState.IsKeyDown(Keys.Escape)) Close();
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
        GL.Enable(EnableCap.DepthTest);

        ResourceManager.CreateShader("DefaultShader", @"Shaders\DefaultShader.vert", @"Shaders\DefaultShader.frag");
        ResourceManager.CreateTexture("Container", @"Textures\container.jpg");

        vbo = GL.GenBuffer();
        vao = GL.GenVertexArray();
        ebo = GL.GenBuffer();

        GL.BindVertexArray(vao);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * 5 * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        GL.BindBuffer(BufferTarget.ElementArrayBuffer, ebo);
        GL.BufferData(BufferTarget.ElementArrayBuffer, indices.Length * sizeof(uint), indices, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);
    }

    private float x;
    private float y;

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        Matrix4 model = Matrix4.Identity;

        x += KeyboardState.IsKeyDown(Keys.D) ? (float)args.Time : KeyboardState.IsKeyDown(Keys.A) ? (float)-args.Time : 0;
        y += KeyboardState.IsKeyDown(Keys.W) ? (float)args.Time : KeyboardState.IsKeyDown(Keys.S) ? (float)-args.Time : 0;

        model *= Matrix4.CreateTranslation(x, y, 0);

        Matrix4 view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);

        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(90.0f), Size.X / Size.Y, 0.1f, 100.0f);

        GL.BindVertexArray(vao);

        var defaultShader = ResourceManager.GetShader("DefaultShader");
        var container = ResourceManager.GetTexture("Container");

        defaultShader.Use();
        container.Use();

        GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "model"), true, ref model);
        GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "view"), true, ref view);
        GL.UniformMatrix4(GL.GetUniformLocation(defaultShader.id, "projection"), true, ref projection);

        GL.DrawElements(PrimitiveType.Triangles, indices.Length, DrawElementsType.UnsignedInt, 0);

        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs args)
    {
        base.OnResize(args);

        GL.Viewport(0, 0, args.Width, args.Height);
    }
}