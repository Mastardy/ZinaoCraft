using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Transform : Component
{
    public Vector3 position = Vector3.Zero;
    public Quaternion rotation = Quaternion.Identity;
    public Vector3 scale = Vector3.One;

    public Vector3 forward => rotation * new Vector3(0, 0, 1);

    public Vector3 up => rotation * new Vector3(0, 1, 0);

    public Vector3 right => rotation * new Vector3(1, 0, 0);
    
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

    public Transform(Entity parent) : base(parent) { }
    
    public Transform(Entity parent, Vector3 position, Quaternion rotation, Vector3 scale) : base(parent)
    {
        this.position = position;
        this.rotation = rotation;
        this.scale = scale;
    }
}
