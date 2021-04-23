using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21
{
    public class MealNew
    {
        public string strMeal { get; set; }
        public string idMeal { get; set; }
        public string strDrinkAlternate { get; set; }
        public string strCategory { get; set; }
        public string strArea { get; set; }
        public string strInstructions { get; set; }
        public string strMealThumb { get; set; }
        public string strTags { get; set; }
        public string strYoutube { get; set; }
        public string strSource { get; set; }
        public string strImageSource { get; set; }
        public string strCreativeCommonsConfirmed { get; set; }
        public string dateModified { get; set; }
        public List<Ingredient> ingredients { get; set; }

        public void addIngredients(OldIngredData ingredInfo)
        {
            ingredients = new List<Ingredient>();
            int index = 1;
            string ingredName = "";
            string ingredAmt = "";
            while (index <= 20)
            {
                if (ingredInfo.GetType().GetProperty("strIngredient" + index).GetValue(ingredInfo, null) != null && ingredInfo.GetType().GetProperty("strIngredient" + index).GetValue(ingredInfo, null).ToString() != "")
                {
                    ingredName = ingredInfo.GetType().GetProperty("strIngredient" + index).GetValue(ingredInfo, null).ToString();
                    ingredAmt = ingredInfo.GetType().GetProperty("strMeasure" + index).GetValue(ingredInfo, null).ToString();
                    ingredients.Add(new Ingredient(ingredName, ingredAmt));
                }
                else 
                {
                    break;
                }                
                index++;
            }
        }        
    }

    
}
