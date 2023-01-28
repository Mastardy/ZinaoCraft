namespace ZinaoCraft;

public class MovementComponent : Component
{
    private float speed = 3.0f;
    public float Speed => speed;

    private bool input = true;
    public bool Input => input;

    public MovementComponent(Entity parent) : base(parent) { }
}