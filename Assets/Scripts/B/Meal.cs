using System.Linq;
using B.Interfaces;

namespace B
{
    public class Meal
    {
        public IIngredient[] Ingredients;

        public float GetPrice()
        {
            return Ingredients.Sum(ingredient => ingredient.Price);
        }
    }
}