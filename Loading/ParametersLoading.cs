using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace New_Arena_.Loading
{
    public class ParametersLoading
    {
        public static Dictionary<int, int> GlobalLevels = new();
        public static Dictionary<int, int> GlobalMarketPotionQuantity = new();
        public static Dictionary<int, int> GlobalMarketWeaponAndArmorQuantity = new();
        public static Dictionary<int, int> GlobalMonsterCageQuantity = new();
        public static Dictionary<int, int> GlobalInnFoodQuantity = new();
        public static Dictionary<int, List<int>> GlobalHpAndMpPotionQualityChance = new();
        public static Dictionary<int, List<int>> GlobalStatusPotionQualityChance = new();
        public static Dictionary<int, List<int>> GlobalWeaponAndArmorQualityChance = new();
        public static void Loading()
        {
            LevelLoading();
            MarketQuantityLoading();
            MonsterCageQuantityLoading();
            InnFoodQuantityLoading();
            MarketQualityChanceLoading();
        }

        private static void LevelLoading()
        {
            string fileName = "./Lists/Parameters/LevelValues.json";
            string jsonString = File.ReadAllText(fileName);

            Dictionary<string, string> GlobalLevelsString = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            foreach (KeyValuePair<string, string> item in GlobalLevelsString)
            {
                GlobalLevels.Add(Convert.ToInt32(item.Key), Convert.ToInt32(item.Value));
            }
        }

        private static void MarketQuantityLoading()
        {
            string fileName = "./Lists/Parameters/MarketQuantityValues.json";
            string jsonString = File.ReadAllText(fileName);

            Dictionary<string, Dictionary<string, string>> AllMarketValuesString = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonString);

            foreach (KeyValuePair<string, Dictionary<string, string>> item in AllMarketValuesString)
            {
                string itemKey = item.Key;
                foreach(KeyValuePair<string, string> innerItem in item.Value)
                {
                    if(itemKey == "potion")
                        GlobalMarketPotionQuantity.Add(Convert.ToInt32(innerItem.Key), Convert.ToInt32(innerItem.Value));
                    
                    if(itemKey == "weaponsAndArmor")
                        GlobalMarketWeaponAndArmorQuantity.Add(Convert.ToInt32(innerItem.Key), Convert.ToInt32(innerItem.Value));
                }
            }
        }

        private static void MarketQualityChanceLoading()
        {
            string fileName = "./Lists/Parameters/MarketQualityValues.json";
            string jsonString = File.ReadAllText(fileName);

            Dictionary<string, Dictionary<string, List<int>>> AllMarketChanceValuesString = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<int>>>>(jsonString);

            foreach (KeyValuePair<string, Dictionary<string, List<int>>> item in AllMarketChanceValuesString)
            {
                string itemKey = item.Key;
                foreach(KeyValuePair<string, List<int>> innerItem in item.Value)
                {
                    if(itemKey == "hpAndMpPotionChance")
                        GlobalHpAndMpPotionQualityChance.Add(Convert.ToInt32(innerItem.Key), innerItem.Value);
                    
                    if(itemKey == "statusPontionChance")
                        GlobalStatusPotionQualityChance.Add(Convert.ToInt32(innerItem.Key), innerItem.Value);

                    if(itemKey == "weaponAndArmorChance")
                        GlobalWeaponAndArmorQualityChance.Add(Convert.ToInt32(innerItem.Key), innerItem.Value);                        
                }
            }
        }

        private static void MonsterCageQuantityLoading()
        {
            string fileName = "./Lists/Parameters/MonsterCagesQuantityValues.Json";
            string jsonString = File.ReadAllText(fileName);

            Dictionary<string, string> MonsterCageValuesString = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            foreach (KeyValuePair<string, string> item in MonsterCageValuesString)
            {
                GlobalMonsterCageQuantity.Add(Convert.ToInt32(item.Key), Convert.ToInt32(item.Value));
            }
        }

        private static void InnFoodQuantityLoading()
        {
            string fileName = "./Lists/Parameters/InnQuantityValues.Json";
            string jsonString = File.ReadAllText(fileName);

            Dictionary<string, string> InnFoodQuantityString = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);

            foreach (KeyValuePair<string, string> item in InnFoodQuantityString)
            {
                GlobalInnFoodQuantity.Add(Convert.ToInt32(item.Key), Convert.ToInt32(item.Value));
            }
        }
    }
}