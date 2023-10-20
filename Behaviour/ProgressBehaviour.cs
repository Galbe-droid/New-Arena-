using System.Linq;
using New_Arena_.Loading;

namespace New_Arena_.Behaviour
{
    class ProgressBehaviour
    {
        private static int _CharacterLevel;
        public static int PotionQuantity;
        public static int WeaponAndArmorQuantity;
        public static int MonsterCageQuantity;
        public static int InnFoodQuantity;

        public static void CheckingValuesInLevel()
        {
            MarketValuesCheck();
            MonsterQuantityCheck();
            InnFoodQuantityCheck();
        }

        public static void LevelCheck(Character character)
        {
            _CharacterLevel = character.Level;
        }

        private static void MarketValuesCheck()
        {
            PotionQuantity = ParametersLoading.GlobalMarketPotionQuantity.FirstOrDefault(level => level.Key == _CharacterLevel).Value;
            WeaponAndArmorQuantity = ParametersLoading.GlobalMarketWeaponAndArmorQuantity.FirstOrDefault(level => level.Key == _CharacterLevel).Value;
        }

        private static void MonsterQuantityCheck()
        {
            MonsterCageQuantity = ParametersLoading.GlobalMonsterCageQuantity.FirstOrDefault(level => level.Key == _CharacterLevel).Value;
        }

        private static void InnFoodQuantityCheck()
        {
            InnFoodQuantity = ParametersLoading.GlobalInnFoodQuantity.FirstOrDefault(level => level.Key == _CharacterLevel).Value;
        }
    }
}