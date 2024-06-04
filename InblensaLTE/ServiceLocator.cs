namespace InblensaLTE;

public static class ServiceLocator
{
    public static IServiceProvider Current { get; private set; }
    
    public static void Init(IServiceProvider serviceProvider)
    {
        Current = serviceProvider;
    }
}