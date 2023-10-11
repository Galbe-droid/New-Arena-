using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace New_Arena_.Loading
{
    class SkillsLoading
    {
        public static List<SkillBase> AllSkills = new List<SkillBase>();
        public static List<SkillBase> SlimeSkillList = new List<SkillBase>();
        public static List<SkillBase> SpiderSkillList = new List<SkillBase>();
        public static List<SkillBase> GolemSkillList = new List<SkillBase>();
        public static Dictionary<int, List<SkillBase>> ListPerMonster = new Dictionary<int, List<SkillBase>>();


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
    }
}