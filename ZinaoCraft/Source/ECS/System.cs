namespace ZinaoCraft;

public class System
{
    protected readonly List<Component> components = new();

    public void AddComponent(Component component) => components.Add(component);
}
