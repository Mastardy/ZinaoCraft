namespace ZinaoCraft;

public class TransformSystem : System
{
    public TransformSystem() : base(SystemUpdateOrder.Early) { }

    public override void Update()
    {
        var transforms = new List<Transform>();
        World.GetComponents(ref transforms);

        for (int i = 0; i < transforms.Count; i++)
        {
            var renderable = transforms[i].parent.GetComponent<Renderable>();
            if (renderable == null) continue;

            renderable.Material.ChangeUniform("transform", transforms[i].Matrix);
        }
    }
}