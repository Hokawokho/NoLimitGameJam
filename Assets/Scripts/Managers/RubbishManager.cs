using System;
using Managers;
using UnityEngine;

namespace Managers
{
    public class RubbishManager : GenericSingleton<RubbishManager>
    {
        IngridientsDatas ingridientsDatas;

        public void Init(IngridientsDatas ingridientsDatas)
        {
            this.ingridientsDatas = ingridientsDatas;   
        }

        public IngridientData GetIngredient()
        {
            return ingridientsDatas.GetIngridient();
        }

    }

}