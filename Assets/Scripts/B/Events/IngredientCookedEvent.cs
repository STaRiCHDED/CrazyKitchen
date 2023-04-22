using B.Controllers;
using SimpleEventBus.Events;

namespace B.Events
{
    public class IngredientCookedEvent : EventBase
    {
        public CookableIngredientController Controller { get; }

        public IngredientCookedEvent(CookableIngredientController controller)
        {
            Controller = controller;
        }
    }
}