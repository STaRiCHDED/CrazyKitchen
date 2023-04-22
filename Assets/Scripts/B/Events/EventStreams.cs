using SimpleEventBus;
using SimpleEventBus.Interfaces;

namespace B.Events
{
    public static class EventStreams
    {
        public static IEventBus Game { get; } = new EventBus();
    }
}