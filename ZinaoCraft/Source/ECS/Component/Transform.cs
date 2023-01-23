using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Transform : Component
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public Transform(Entity parent, Vector3 position, Quaternion rotation, Vector3 scale) : base(parent, typeof(EmptySystem))
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }

    public Matrix4 GetTransform()
    {
        var matrix = Matrix4.Identity;

        matrix *= Matrix4.CreateTranslation(position);
        matrix *= Matrix4.CreateRotationX(rotation.X);
        matrix *= Matrix4.CreateRotationY(rotation.Y);
        matrix *= Matrix4.CreateRotationZ(rotation.Z);
        matrix *= Matrix4.CreateScale(scale);

        return matrix;
    }
}
