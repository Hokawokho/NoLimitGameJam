using System;
using Managers;
using UnityEngine;

namespace Managers
{
    public class RubishManager : GenericSingleton<RubishManager>
    {
        public static Func<Ingredient> GetIngredientSo;

        public static event Action<Ingredient> IngridentSelected;

        public Ingredient GetIngredient()
        {
            return GetIngredientSo?.Invoke();
        }

        public void SelectedIngredient(Ingredient ingredient)
        {
            IngridentSelected?.Invoke(ingredient);
        }

    }

}