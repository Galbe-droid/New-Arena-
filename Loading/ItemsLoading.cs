using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using New_Arena_.Game_Objects;
using New_Arena_.Game_Objects.Base_Objects;
using Newtonsoft.Json.Linq;

namespace New_Arena_.Loading
{
    class ItemsLoading
    {
        public static List<Food> ConsumablesList = new();
        public static List<Potion> PotionList = new();
        public static List<Weapon> WeaponList = new();
        public static List<Armor> ArmorList = new();

        public static void Loading()
        {
            ConsumablesLoading();
            PotionsLoading();
            WeaponLoading();
            ArmorLoading();
        }

        private static List<Food> ConsumablesLoading()
        {
            string fileName = "./Lists/FoodList.json";
            string jsonString = File.ReadAllText(fileName);

            ConsumablesList = JsonSerializer.Deserialize<List<Food>>(jsonString);

            return ConsumablesList;
        }   

        private static List<Weapon> WeaponLoading()
        {
            string fileName = "./Lists/WeaponList.json";
            string jsonString = File.ReadAllText(fileName);

            WeaponList = JsonSerializer.Deserialize<List<Weapon>>(jsonString);
            
            return WeaponList;
        }

        private static List<Armor> ArmorLoading()
        {
            string fileName = "./Lists/ArmorList.json";
            string jsonString = File.ReadAllText(fileName);

            ArmorList = JsonSerializer.Deserialize<List<Armor>>(jsonString);
            
            return ArmorList;
        }

        private static List<Potion> PotionsLoading()
        {
            string fileName = $"./Lists/PotionList.json";
            string jsonString = File.ReadAllText(fileName);
            
            var resultObjects = AllChildren(JObject.Parse(jsonString))
            .First(c => c.Type == JTokenType.Array && c.Path.Contains("Potion"))
            .Children<JObject>();

            foreach(JObject result in resultObjects)
            {
                foreach(JProperty potionType in result.Properties())
                {
                    switch(potionType.Name){
                        case "HpAndMpPotion":
                            PotionList.AddRange(JsonSerializer.Deserialize<List<HpAndMpPotion>>(potionType.Value.ToString()));
                            break;

                        case "StatusPotion":
                            PotionList.AddRange(JsonSerializer.Deserialize<List<StatusPotion>>(potionType.Value.ToString()));
                            break;

                        default:
                            break;
                    }
                }
            }
            return PotionList;
        }

        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children()) {
                yield return c;
                foreach (var cc in AllChildren(c)) {
                    yield return cc;
                }
            }
        }     
    }
}