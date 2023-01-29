using OpenTK.Mathematics;

namespace ZinaoCraft;

public static class ChunkGenerator
{
    public static Vector3[] GenerateChunk(uint chunkX, uint chunkY)
    {
        var vertices = new Vector3[256];
        
        FastNoiseLite noise = new();
        noise.SetNoiseType(FastNoiseLite.NoiseType.Perlin);

        int index = 0;
        
        for (uint y = 16 * chunkY; y < 16 + 16 * chunkY; y++)
        {
            for (uint x = 16 * chunkX; x < 16 + 16 * chunkX; x++)
            {
                vertices[index++] = new Vector3(x, (int)(noise.GetNoise(x * 10, y * 10) * 10), y);
            }
        }

        return vertices;
    }
}