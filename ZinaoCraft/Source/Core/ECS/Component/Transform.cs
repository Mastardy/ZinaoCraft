using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Transform : Component
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public Matrix4 Matrix
    {
        get
        {
            Matrix4 matrix = Matrix4.Identity;
            matrix *= Matrix4.CreateScale(scale);
            matrix *= Matrix4.CreateFromQuaternion(rotation);
            matrix *= Matrix4.CreateTranslation(position);
            return matrix;
        }
    }

    public Transform(Entity parent) : base(parent)
    {
        position = Vector3.Zero;
        rotation = Quaternion.Identity;
        scale = Vector3.One;
    }
    
    public Transform(Entity parent, Vector3 position, Quaternion rotation, Vector3 scale) : base(parent)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}
