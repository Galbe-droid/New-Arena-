using System.Collections.Generic;

namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    public interface IXp
    {
        public int Level {get; set;}
        public int XpTotal { get; set; }
        public int Xp { get; set; }
        public Dictionary<int, int> Levels {get; set;}
        void InitializeLevel();
        bool CheckXpCost(int cost);
        void CheckCharacterLevel();        
    }
}