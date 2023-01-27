using OpenTK.Mathematics;

namespace ZinaoCraft;

public class Camera : Entity
{
   public Camera()
   {
      AddComponent(new Transform(this, new Vector3(0, 0, -3), Quaternion.Identity, new Vector3(1, 1, 1)));
   }
}