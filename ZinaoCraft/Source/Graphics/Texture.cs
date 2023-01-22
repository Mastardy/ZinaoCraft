using System.Reflection;
using OpenTK.Graphics.OpenGL4;
using StbImageSharp;

namespace ZinaoCraft;

public class Texture : IDisposable
{
    private readonly int id;

    private bool disposed;

    public Texture(string imagePath)
    {
        id = GL.GenTexture();
        GL.BindTexture(TextureTarget.Texture2D, id);

        StbImage.stbi_set_flip_vertically_on_load(1);

        ImageResult image = ImageResult.FromStream(File.OpenRead(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\" + imagePath), ColorComponents.RedGreenBlueAlpha);

        GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, image.Width, image.Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, image.Data);
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
    }

    public void Use()
    {
        GL.BindTexture(TextureTarget.Texture2D, id);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposed) return;

        GL.DeleteTexture(id);
        disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}