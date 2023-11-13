using System.Collections.Generic;
using System.Linq;
using New_Arena_.Loading;

namespace New_Arena_.Behaviour
{
    class ProgressBehaviour
    {
        public static int CharacterLevel;
        public static int PotionQuantity;
        public static int WeaponAndArmorQuantity;
        public static int MonsterCageQuantity;
        public static int InnFoodQuantity;
        public static List<int> HpAndMpPotionQualityChance = new();
        public static List<int> StatusPotionQualityChance = new();
        public static List<int> WeaponAndArmorQualityChance = new();

        public static void CheckingValuesInLevel(Character character)
        {
            LevelCheck(character);
            MarketValuesCheck();
            MonsterQuantityCheck();
            InnFoodQuantityCheck();
            MarketQualityCheck();
        }

        public static void LevelCheck(Character character)
        {
            CharacterLevel = character.Level;
        }

        public static void LevelUpCheck(Character character)
        {
            int oldLevel = character.Level;
            character.CheckCharacterLevel();
            int newLevel = character.Level;

            if(oldLevel != newLevel){
                UpdateConsole.StaticMessage("LEVEL UP !!!!!!!!");
            }
        }

        private static void MarketValuesCheck()
        {
            PotionQuantity = ParametersLoading.GlobalMarketPotionQuantity.FirstOrDefault(level => level.Key == CharacterLevel).Value;
            WeaponAndArmorQuantity = ParametersLoading.GlobalMarketWeaponAndArmorQuantity.FirstOrDefault(level => level.Key == CharacterLevel).Value;
        }

        private static void MonsterQuantityCheck()
        {
            MonsterCageQuantity = ParametersLoading.GlobalMonsterCageQuantity.FirstOrDefault(level => level.Key == CharacterLevel).Value;
        }

        private static void InnFoodQuantityCheck()
        {
            InnFoodQuantity = ParametersLoading.GlobalInnFoodQuantity.FirstOrDefault(level => level.Key == CharacterLevel).Value;
        }

        private static void MarketQualityCheck()
        {
            HpAndMpPotionQualityChance = ParametersLoading.GlobalHpAndMpPotionQualityChance.FirstOrDefault(level => level.Key == CharacterLevel).Value;
            StatusPotionQualityChance = ParametersLoading.GlobalStatusPotionQualityChance.FirstOrDefault(level => level.Key == CharacterLevel).Value;
            WeaponAndArmorQualityChance = ParametersLoading.GlobalWeaponAndArmorQualityChance.FirstOrDefault(level => level.Key == CharacterLevel).Value;
        }
    }
}