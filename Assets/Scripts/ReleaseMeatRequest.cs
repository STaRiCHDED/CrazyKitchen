using SimpleEventBus.Events;

public class ReleaseMeatRequest : EventBase
{
    public MeatController MeatController { get; }

    public ReleaseMeatRequest(MeatController meatController)
    {
        MeatController = meatController;
    }
}