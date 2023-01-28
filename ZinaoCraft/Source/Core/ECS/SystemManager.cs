namespace ZinaoCraft;

public static class SystemManager
{
    private static List<System> earlySystems = new();
    private static List<System> normalSystems = new();
    private static List<System> lateSystems = new();
    private static List<System> renderSystems = new();

    public static void RegisterSystems()
    {
        // Early
        RegisterSystem(new TransformSystem());
        
        // Normal
        RegisterSystem(new CameraSystem());
        RegisterSystem(new MovementSystem());
        
        // Late
        
        
        // Render
        RegisterSystem(new MeshRenderer());
    }
    
    public static void RegisterSystem(System system)
    {
        switch (system.updateOrder)
        {
            case SystemUpdateOrder.Early:
                earlySystems.Add(system);
                break;
            case SystemUpdateOrder.Normal:
                normalSystems.Add(system);
                break;
            case SystemUpdateOrder.Late:
                lateSystems.Add(system);
                break;
            case SystemUpdateOrder.Render:
                renderSystems.Add(system);
                break;
        }
    }

    public static void Update()
    {
        for (int i = 0; i < earlySystems.Count; i++) earlySystems[i].Update();
        for (int i = 0; i < normalSystems.Count; i++) normalSystems[i].Update();
        for (int i = 0; i < lateSystems.Count; i++) lateSystems[i].Update();
    }

    public static void Render()
    {
        for (int i = 0; i < renderSystems.Count; i++) renderSystems[i].Update();
    }
}