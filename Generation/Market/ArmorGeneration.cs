using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Loading;

namespace New_Arena_.Generation.Market
{
    class ArmorGeneration
    {
        private static List<Armor> ArmorPrefab = ItemsLoading.ArmorList;

        public static List<Armor> ListOfArmorOfTheDay(List<Armor> todayArmor)
        {
          todayArmor = ArmorCreator(todayArmor);

          return todayArmor;
        }

        public static void ClearArmor(List<Armor> todayArmor)
        {
          if(todayArmor.Count > 0)
          {
            todayArmor.Clear();
          }
        }

        private static List<Armor> ArmorCreator(List<Armor> todayArmor)
        {
            List<int> armorId = new();
            int count = 0;

            foreach(Armor weapon in ArmorPrefab)
            {
                if(weapon.Id != 0)
                    armorId.Add(weapon.Id);
            }

            do
            {
                int randId = armorId[ManagerRandom.GetThreadRandom().Next(armorId.Count)];

                Armor armor = new(ArmorPrefab.Find(armor => armor.Id == randId))
                {
                    Quality = RandomQualityStatus()
                };

                switch (armor.Quality)
                {
                    case WeaponType.Rust:
                        armor.MinDefense -= 1;
                        armor.MaxDefense -= 1;
                        armor.MinDefenseModifier -= 0.05f;
                        armor.MaxDefenseModifier -= 0.25f;
                        armor.Cost -= (int)MathF.Truncate(armor.Cost * 0.2f);
                        break;

                    case WeaponType.Poorly:
                        armor.MaxDefense -= 1;
                        armor.MaxDefenseModifier -= 0.1f;
                        armor.Cost -= (int)MathF.Truncate(armor.Cost * 0.1f);
                        break;

                    case WeaponType.Prime:
                        armor.MinDefense += 1;
                        armor.MaxDefense += 2;
                        armor.MinDefenseModifier += 0.10f;
                        armor.MaxDefenseModifier += 0.25f;
                        armor.Cost += (int)MathF.Truncate(armor.Cost * 0.3f);
                        break;
                }
                todayArmor.Add(armor);

                count++;
            }while(count < ProgressBehaviour.WeaponAndArmorQuantity);

            return todayArmor;
        }

        private static WeaponType RandomQualityStatus()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,101);
            List<int> chance = ProgressBehaviour.WeaponAndArmorQualityChance;

            if(choice < chance[0])
                return WeaponType.Rust;
            else if(choice >= chance[0] && choice < chance[1])
                return WeaponType.Poorly;
            else if(choice >= chance[1] && choice < chance[2])
                return WeaponType.Regular;
            else
                return WeaponType.Prime;
        }
    }
}