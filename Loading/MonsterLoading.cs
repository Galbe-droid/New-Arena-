using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace New_Arena_.Loading
{
    partial class MonsterLoading
    {
        public static List<Monster> Monsters = new();
        public static List<MonsterVariation> SlimeVariation = new();
        public static List<MonsterVariation> SpiderVariation = new();
        public static List<MonsterVariation> GolemVariation = new();
        public static List<MonsterVariation> KoboldVariation = new();
        public static List<MonsterVariation> ArtificialLifeVariation = new();
        public static List<MonsterVariation> UndeadVariation = new();
        public static List<MonsterVariation> MageVariation = new();
        public static Dictionary<int, List<MonsterVariation>> ListOfMonsterVariation = new();

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
            name = MyRegex().Replace(name, "");
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
                case 3:
                    return KoboldVariation;
                case 4:
                    return ArtificialLifeVariation;
                case 5:
                    return UndeadVariation;
                case 6:
                    return MageVariation;
                default:
                    return null;
            }
        }

        [GeneratedRegex("\\s")]
        private static partial Regex MyRegex();

    }
}