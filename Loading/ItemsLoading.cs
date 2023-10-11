using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace New_Arena_.Loading
{
    class ItemsLoading
    {
        public static List<Consumable> ConsumablesList = new List<Consumable>();
        public static List<Consumable> ConsumablesLoading()
        {
            string fileName = "./Lists/ConsumableList.json";
            string jsonString = File.ReadAllText(fileName);

            ConsumablesList = JsonSerializer.Deserialize<List<Consumable>>(jsonString);

            return ConsumablesList;
        }        
    }
}