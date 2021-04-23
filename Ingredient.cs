using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
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
