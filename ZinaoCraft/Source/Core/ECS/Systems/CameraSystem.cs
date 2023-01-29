namespace ZinaoCraft;

public class CameraSystem : System
{
    public CameraSystem() : base(SystemUpdateOrder.Normal) { }

    public override void Update()
    {
        List<CameraComponent> cameras = new();
        World.GetComponents(ref cameras);

        for (int i = 0; i < cameras.Count; i++)
        {
            var camera = cameras[i];
            if (!camera.current) continue;

            List<Renderable> renderables = new();
            World.GetComponents(ref renderables);

            for (int j = 0; j < renderables.Count; j++)
            {
                var renderable = renderables[j];
                renderable.Material.ChangeUniform("view", camera.view);
                renderable.Material.ChangeUniform("projection", camera.projection);
            }
        }
    }
}