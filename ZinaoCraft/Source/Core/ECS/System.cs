namespace ZinaoCraft;

public enum SystemUpdateOrder
{
    Early,
    Normal,
    Late,
    Render
}

public abstract class System
{
    public readonly SystemUpdateOrder updateOrder;

    protected System(SystemUpdateOrder systemUpdateOrder) => updateOrder = systemUpdateOrder;
    
    public abstract void Update();
}