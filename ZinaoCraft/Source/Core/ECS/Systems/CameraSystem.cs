namespace ZinaoCraft;

public class CameraSystem : System
{
    public CameraSystem() : base(SystemUpdateOrder.Late) { }

    public override void Update()
    {
        var cameras = World.GetComponents<CameraComponent>();
        if (cameras == null) return;

        for (int i = 0; i < cameras.Count; i++)
        {
            var camera = cameras[i];
            if (!camera.current) continue;

            var renderables = World.GetComponents<Renderable>();
            if (renderables == null) continue;

            for (int j = 0; j < renderables.Count; j++)
            {
                var renderable = renderables[i];
                renderable.Material.ChangeUniform("view", camera.view);
                renderable.Material.ChangeUniform("projection", camera.projection);
            }
        }
    }
}