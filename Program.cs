using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

namespace Day21
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "https://www.themealdb.com/api/json/v1/1/search.php?f=a";
            HttpClient client = new HttpClient();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, url);
            HttpResponseMessage response = client.Send(webRequest);
            Stream stream = response.Content.ReadAsStream();
            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ListMealsIngredients oldIngredients = JsonSerializer.Deserialize<ListMealsIngredients>(data, options);
            MealsNew newMeals = JsonSerializer.Deserialize<MealsNew>(data, options);

            for (int i = 0; i < newMeals.meals.Length; i++)
            {
                OldIngredData ingredients = oldIngredients.Meals[i];
                newMeals.meals[i].addIngredients(ingredients);
            }

            string serializedMeals = JsonSerializer.Serialize(newMeals);
            string outputFileName = ("MEALS_" + url[^1]).ToUpper() + ".json";
            File.WriteAllText(outputFileName, serializedMeals);
            Console.WriteLine($"Finished restructuring ingredients!");
            Console.WriteLine("Output: " + outputFileName);
        }

        public class ListMealsIngredients
        {
            public OldIngredData[] Meals { get; set; }
        }

        public class OldIngredData
        {
            public string strIngredient1 { get; set; }
            public string strIngredient2 { get; set; }
            public string strIngredient3 { get; set; }
            public string strIngredient4 { get; set; }
            public string strIngredient5 { get; set; }
            public string strIngredient6 { get; set; }
            public string strIngredient7 { get; set; }
            public string strIngredient8 { get; set; }
            public string strIngredient9 { get; set; }
            public string strIngredient10 { get; set; }
            public string strIngredient11 { get; set; }
            public string strIngredient12 { get; set; }
            public string strIngredient13 { get; set; }
            public string strIngredient14 { get; set; }
            public string strIngredient15 { get; set; }
            public string strIngredient16 { get; set; }
            public string strIngredient17 { get; set; }
            public string strIngredient18 { get; set; }
            public string strIngredient19 { get; set; }
            public string strIngredient20 { get; set; }
            public string strMeasure1 { get; set; }
            public string strMeasure2 { get; set; }
            public string strMeasure3 { get; set; }
            public string strMeasure4 { get; set; }
            public string strMeasure5 { get; set; }
            public string strMeasure6 { get; set; }
            public string strMeasure7 { get; set; }
            public string strMeasure8 { get; set; }
            public string strMeasure9 { get; set; }
            public string strMeasure10 { get; set; }
            public string strMeasure11 { get; set; }
            public string strMeasure12 { get; set; }
            public string strMeasure13 { get; set; }
            public string strMeasure14 { get; set; }
            public string strMeasure15 { get; set; }
            public string strMeasure16 { get; set; }
            public string strMeasure17 { get; set; }
            public string strMeasure18 { get; set; }
            public string strMeasure19 { get; set; }
            public string strMeasure20 { get; set; }
        }

        public class MealsNew
        {
            public MealNew[] meals { get; set; }
        }
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
                    else break;
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
}
