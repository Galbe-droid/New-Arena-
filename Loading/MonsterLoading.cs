using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace New_Arena_.Loading
{
    class MonsterLoading
    {
        public static List<Monster> Monsters = new List<Monster>();
        public static List<MonsterVariation> SlimeVariation = new List<MonsterVariation>();
        public static List<MonsterVariation> SpiderVariation = new List<MonsterVariation>();
        public static List<MonsterVariation> GolemVariation = new List<MonsterVariation>();
        public static Dictionary<int, List<MonsterVariation>> ListOfMonsterVariation = new Dictionary<int, List<MonsterVariation>>();

        public static void Loading()
        {
            BaseMonsterLoading();
            MonsterVariationsDictionaryLoading();
        }
        private static List<Monster> BaseMonsterLoading()
        {
            string fileName = "./Lists/MonsterList.json";
            string jsonString = File.ReadAllText(fileName);

            Monsters = JsonSerializer.Deserialize<List<Monster>>(jsonString);

            return Monsters;
        }

        private static Dictionary<int, List<MonsterVariation>> MonsterVariationsDictionaryLoading()
        {
            foreach (Monster monster in Monsters)
            {
                ListOfMonsterVariation.Add(monster.Id, MonsterVariationsLoading(monster.Name, monster.Id));
            }
            return ListOfMonsterVariation;
        }

        private static List<MonsterVariation> MonsterVariationsLoading(string name, int id)
        {
            List<MonsterVariation> tempList = GettingListById(id);
            string fileName = $"./Lists/MonsterVariation/{name}List.json";
            string jsonString = File.ReadAllText(fileName);

            tempList = JsonSerializer.Deserialize<List<MonsterVariation>>(jsonString);

            return tempList;
        }

        private static List<MonsterVariation> GettingListById(int id)
        {
            switch(id){
                case 0:
                    return SlimeVariation; 
                case 1:
                    return SpiderVariation;
                case 2: 
                    return GolemVariation;
                default:
                    return null;
            }
        }
    }
}