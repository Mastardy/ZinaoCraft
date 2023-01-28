namespace ZinaoCraft;

public abstract class Camera : Entity
{
   protected Camera()
   {
      AddComponent(new Transform(this));
      AddComponent(new CameraComponent(this));
   }
}