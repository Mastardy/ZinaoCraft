using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace ZinaoCraft;

public class BlockMesh : Mesh
{
    public BlockMesh(Entity parent) : base(parent)
    {
        vertices = new Vertex[]
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

        indices = new uint[] {
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

        UpdateMesh();
    }
}