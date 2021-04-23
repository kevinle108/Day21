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
            //Digimon agumon = new Digimon("Agumon", 5);

            //string nameVal = agumon.GetType().GetProperty("DigimonName").GetValue(agumon, null).ToString();
            //string levelVal = agumon.GetType().GetProperty("DigimonLevel").GetValue(agumon, null).ToString();

            //Console.WriteLine(nameVal);
            //Console.WriteLine(levelVal);


            HttpClient client = new HttpClient();
            HttpRequestMessage webRequest = new HttpRequestMessage(HttpMethod.Get, "https://www.themealdb.com/api/json/v1/1/search.php?f=y");
            HttpResponseMessage response = client.Send(webRequest);
            Stream stream = response.Content.ReadAsStream();
            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();
            JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            ListMealsBase oldMeals = JsonSerializer.Deserialize<ListMealsBase>(data, options);

            ListMealsIngredients oldIngredients = JsonSerializer.Deserialize<ListMealsIngredients>(data, options);

            MealsNew newMeals = new MealsNew();
            Console.WriteLine($"oldmeals length: {oldMeals.Meals.Length}");
            Console.WriteLine($"oldIngredients length: {oldIngredients.Meals.Length}");

            for (int i = 0; i < oldMeals.Meals.Length; i++)
            {
                MealBase baseMeal = oldMeals.Meals[i];
                OldIngredData ingredients = oldIngredients.Meals[i];
                newMeals.Meals.Add(baseMeal.CreateFormattedMeal(ingredients));
            }

            Console.WriteLine("Finished Program...");
        }

        public class Digimon
        {
            public string DigimonName { get; set; }
            public int DigimonLevel { get; set; }

            public Digimon(string name, int level)
            {
                DigimonName = name;
                DigimonLevel = level;
            }
        }

        public class ListMealsBase
        {
            public MealBase[] Meals { get; set; }
        }

        public class ListMealsIngredients
        {
            public OldIngredData[] Meals { get; set; }
        }

        public class MealsNew
        {
            public List<MealNew> Meals { get; set; }

            public MealsNew()
            {
                Meals = new List<MealNew>();
            }


        }


    }


    

    
}
