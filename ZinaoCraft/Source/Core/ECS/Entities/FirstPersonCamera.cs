using OpenTK.Mathematics;

namespace ZinaoCraft;

public class FirstPersonCamera : Camera
{
    public FirstPersonCamera()
    {
        var transform = GetComponent<Transform>();
        if (transform == null) throw new Exception("Camera did not have a Transform!"); 
        transform.position = new Vector3(1, 0, -3);

        var camera = GetComponent<CameraComponent>();
        if (camera == null) throw new Exception("Camera did not have a CameraComponent!");
        
        AddComponent(new MovementComponent(this));
    }
}