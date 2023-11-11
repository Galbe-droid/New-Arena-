using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

/*
    Skills Ids: 
        0 - Basic Defense, not a skill but it was made by the same method
        10 - 100 - BuffSkills
        101 - 200 - DebuffSkills
        201 - 300 - AttackSkills
        301 - 400 - DefenseSkills

        1001 - 1100 - SlimeSkills
        1101 - 1200 - SpiderSkills
        1201 - 1300 - GolemSkills
        1301 - 1400 - KoboldSkills
        1401 - 1500 - AtificialLifeSkills
        1501 - 1600 - UndeadSkills
        1601 - 1700 - MageSkills
*/

namespace New_Arena_.Loading
{
    partial class SkillsLoading
    {
        public static List<SkillBase> AllSkills = new();
        public static List<SkillBase> SlimeSkillList = new();
        public static List<SkillBase> SpiderSkillList = new();
        public static List<SkillBase> GolemSkillList = new();
        public static List<SkillBase> KoboldSkillList = new();
        public static List<SkillBase> ArtificialLifeSkillList = new();
        public static List<SkillBase> UndeadSkillList = new();
        public static List<SkillBase> MageSkillList = new();
        public static Dictionary<int, List<SkillBase>> ListPerMonster = new();


        public static void Loading()
        {
            PlayerSkillLoading();
            DictionaryMonsterLoading();
        }

        private static List<SkillBase> PlayerSkillLoading()
        {
            string[] skillType = {"Buff", "Debuff", "Attack", "Defense"};
            List<SkillBase> tempList = AllSkills;

            foreach(string s in skillType)
            {
                tempList.AddRange(GettingPlayerSkillByType(s));
            }     

            return tempList;   
        }

        private static Dictionary<int, List<SkillBase>> DictionaryMonsterLoading()
        {
            foreach(Monster monster in MonsterLoading.Monsters)
            {
                ListPerMonster.Add(monster.Id, MonsterSkillLoadingById(monster.Name, monster.Id));
            }

            return ListPerMonster;
        }

        private static List<SkillBase> MonsterSkillLoadingById(string name, int id)
        {
            name = MyRegex().Replace(name, "");
            string fileName = $"./Lists/MonsterSkill/{name}SkillList.json";
            string jsonString = File.ReadAllText(fileName);            
            
            var resultObjects = AllChildren(JObject.Parse(jsonString))
            .First(c => c.Type == JTokenType.Array && c.Path.Contains("skills"))
            .Children<JObject>();
            List<SkillBase> tempList = GettingListById(id);
            

           foreach (JObject result in resultObjects) {
                foreach (JProperty property in result.Properties()) {
                    // do something with the property belonging to result
                    switch(property.Name){
                    case "Buff":
                        tempList.AddRange(JsonSerializer.Deserialize<List<BuffSkill>>(property.Value.ToString()));
                        break;

                    case "Debuff":
                        tempList.AddRange(JsonSerializer.Deserialize<List<DebuffSkill>>(property.Value.ToString()));
                        break;

                    case "Attack":
                        tempList.AddRange(JsonSerializer.Deserialize<List<AttackSkill>>(property.Value.ToString()));
                        break;

                    case "Defense":
                        tempList.AddRange(JsonSerializer.Deserialize<List<DefenseSkill>>(property.Value.ToString()));
                        break;

                    default:
                        return null;
                    }
                }
            }

            return tempList;
        }

        private static List<SkillBase> GettingPlayerSkillByType(string type)
        {
            string fileName;
            string jsonString;
            List<SkillBase> tempList = new();

            switch(type){
                case "Buff":
                    fileName = $"./Lists/PlayerSkill/{type}SkillList.json";
                    jsonString = File.ReadAllText(fileName);
                    tempList.AddRange(JsonSerializer.Deserialize<List<BuffSkill>>(jsonString));
                    return tempList;

                case "Debuff":
                    fileName = $"./Lists/PlayerSkill/{type}SkillList.json";
                    jsonString = File.ReadAllText(fileName);
                    tempList.AddRange(JsonSerializer.Deserialize<List<DebuffSkill>>(jsonString));
                    return tempList;

                case "Attack":
                    fileName = $"./Lists/PlayerSkill/{type}SkillList.json";
                    jsonString = File.ReadAllText(fileName);
                    tempList.AddRange(JsonSerializer.Deserialize<List<AttackSkill>>(jsonString));
                    return tempList;

                case "Defense":
                    fileName = $"./Lists/PlayerSkill/{type}SkillList.json";
                    jsonString = File.ReadAllText(fileName);
                    tempList.AddRange(JsonSerializer.Deserialize<List<DefenseSkill>>(jsonString));
                    return tempList;

                default:
                    return null;
            }
        }
        private static List<SkillBase> GettingListById(int id)
        {
            switch(id){
                case 0:
                    return SlimeSkillList; 
                case 1:
                    return SpiderSkillList;
                case 2: 
                    return GolemSkillList;
                case 3:
                    return KoboldSkillList;
                case 4:
                    return ArtificialLifeSkillList;
                case 5:
                    return UndeadSkillList;
                case 6:
                    return MageSkillList;
                default:
                    return null;
            }
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

        [GeneratedRegex("\\s")]
        private static partial Regex MyRegex();
    }
}