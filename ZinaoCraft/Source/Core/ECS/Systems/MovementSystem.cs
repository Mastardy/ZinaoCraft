using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace ZinaoCraft;

public class MovementSystem : System
{
    public MovementSystem() : base(SystemUpdateOrder.Normal) { }
    
    public override void Update()
    {
        var movementComponents = new List<MovementComponent>();
        World.GetComponents(ref movementComponents);

        for (int i = 0; i < movementComponents.Count; i++)
        {
            var movementComponent = movementComponents[i];
            if (!movementComponent.Input) continue;
           
            var movement = new Vector3(Input.GetKey(Keys.A) ? -1 : Input.GetKey(Keys.D) ? 1 : 0, 
                Input.GetKey(Keys.LeftControl) ? -1 : Input.GetKey(Keys.Space) ? 1 : 0, 
                Input.GetKey(Keys.S) ? -1 : Input.GetKey(Keys.W) ? 1 : 0);
            movement *= Time.deltaTime;
            
            var mouseDelta = Input.mouseDelta / 800;
            
            var transform = movementComponent.parent.GetComponent<Transform>();
            if (transform == null) continue;

            transform.position -= transform.right * movement.X;
            transform.position += transform.up * movement.Y;
            transform.position += transform.forward * movement.Z;

            Quaternion pitch = Quaternion.FromAxisAngle(transform.right, mouseDelta.Y);
            transform.rotation = pitch * transform.rotation;
            Quaternion yaw = Quaternion.FromAxisAngle(Vector3.UnitY, -mouseDelta.X);
            transform.rotation = yaw * transform.rotation;
        }
    }
}