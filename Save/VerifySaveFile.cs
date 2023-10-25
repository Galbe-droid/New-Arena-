using System.Collections.Generic;
using System.IO;
using System.Linq;

using New_Arena_.Loading;
using Newtonsoft.Json;


namespace New_Arena_.Save
{
    class VerifySaveFile
    {
        public static List<Character> SaveCharacterList {get; set;}
        private readonly static string _path = @"./Lists/SaveCharacterList.json";
        public static void CreateFile()
        {
            if(!File.Exists(_path))
            {
                using var steam = File.Create(_path);
                steam.Close();

            }            
        }

        public static void NewCharacterSave(Character character)
        {
            AddNewCharacterOnList(character);
            UpdateSaveCharacterList();
        }

        public static void GameSave(Character character)
        {
            UpdateConsole.StaticMessage($"Game Saved.");
            UpdateCharacterSave(character);
            UpdateSaveCharacterList();
        }

        public static void ReloadSaveList()
        {
            SaveCharacterList = CharactersLoading.GlobalCharacterList;
        }

        private static void UpdateSaveCharacterList()
        {   
            using(StreamWriter file = File.CreateText(_path)){
                JsonSerializer serializer = new();
                serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
                serializer.NullValueHandling = NullValueHandling.Ignore;
                serializer.TypeNameHandling = TypeNameHandling.Auto;
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, SaveCharacterList);
                file.Close();
            }
        }

        private static void UpdateCharacterSave(Character character)
        {
            Character newSaveCharacter = SaveCharacterList.FirstOrDefault(saveCharacter => saveCharacter.Id == character.Id);

            newSaveCharacter = character;
        }

        private static void AddNewCharacterOnList(Character character)
        {
            SaveCharacterList.Add(character);
        }      
    }
}