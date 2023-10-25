using System.Collections.Generic;
using System.IO;
using New_Arena_.Save;
using Newtonsoft.Json;

namespace New_Arena_.Loading
{
    class CharactersLoading
    {
        public static List<Character> GlobalCharacterList = new();

        public static List<Character> LoadingCharacters()
        {
            string fileName = "./Lists/SaveCharacterList.json";
            string jsonString = File.ReadAllText(fileName);

            if(jsonString.Length != 0)
            {
                GlobalCharacterList = JsonConvert.DeserializeObject<List<Character>>(jsonString, new JsonSerializerSettings 
                { 
                    TypeNameHandling = TypeNameHandling.Auto,
                    NullValueHandling = NullValueHandling.Ignore,   
                });
            }

            VerifySaveFile.ReloadSaveList();
            return GlobalCharacterList;
        }
    }
}