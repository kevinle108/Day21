using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public class MealNew : MealBase
    {
        public List<Ingredient> ingredients { get; set; }

        public MealNew(OldIngredData ingredInfo) : base()
        {
            ingredients = new List<Ingredient>();
            int index = 1;
            string ingredName = "";
            string ingredAmt = "";
            while (index <= 20)
            {
                ingredName = ingredInfo.GetType().GetProperty("strIngredient" + index).GetValue(ingredInfo, null).ToString();
                ingredAmt = ingredInfo.GetType().GetProperty("strMeasure" + index).GetValue(ingredInfo, null).ToString();
                ingredients.Add(new Ingredient(ingredName, ingredAmt));
                index++;
            }
        }
    }

    public class Ingredient
    {
        public string strIngredient { get; set; }
        public string strMeasure { get; set; }

        public Ingredient(string ingredientName, string ingredientAmt)
        {
            strIngredient = ingredientName;
            strMeasure = ingredientAmt;
        }
    }
}
