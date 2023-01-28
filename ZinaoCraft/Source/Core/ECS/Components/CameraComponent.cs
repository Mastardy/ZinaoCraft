using OpenTK.Mathematics;

namespace ZinaoCraft;

public class CameraComponent : Component
{
    public bool current = true;
    
    public float fov = 90.0f;
    public float depthNear = 0.1f;
    public float depthFar = 100.0f;
    
    public Matrix4 view
    {
        get
        {
            var transform = parent.GetComponent<Transform>();
            if (transform == null) return Matrix4.Identity;

            var position = transform.position;
            var target = position + transform.forward;
            var up = transform.up;
            
            return Matrix4.LookAt(position, target, up);
        }
    }

    public Matrix4 projection => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), Game.window.Size.X / Game.window.Size.Y, depthNear, depthFar);
    
    public CameraComponent(Entity parent) : base(parent) { }

    public CameraComponent(Entity parent, float fov, float depthNear, float depthFar) : base(parent)
    {
        this.fov = fov;
        this.depthNear = depthNear;
        this.depthFar = depthFar;
    }
}