using Controllers;
using SimpleEventBus.Events;

namespace Events
{
    public class ReleaseMeatRequestEvent : EventBase
    {
        public MeatController MeatController { get; }

        public ReleaseMeatRequestEvent(MeatController meatController)
        {
            MeatController = meatController;
        }
    }
}