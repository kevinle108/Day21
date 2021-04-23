﻿using System;
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

        public class MealsNew
        {
            public MealNew[] meals { get; set; }
        }


    }


    

    
}
