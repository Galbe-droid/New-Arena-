using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Loading;

namespace New_Arena_.Generation.Market
{
    public class ArmorGeneration
    {
        private static List<Armor> ArmorOfTheDay = new();
        private static List<Armor> ArmorPrefab = ItemsLoading.ArmorList;

        public static List<Armor> ListOfArmorOfTheDay()
        {
          ArmorOfTheDay = ArmorCreator();

          return ArmorOfTheDay;
        }

        public static void ClearArmor()
        {
          if(ArmorOfTheDay.Count > 0)
          {
            ArmorOfTheDay.Clear();
          }
        }

        private static List<Armor> ArmorCreator()
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
                        break;

                    case WeaponType.Poorly:
                        armor.MaxDefense -= 1;
                        armor.MaxDefenseModifier -= 0.1f;
                        break;

                    case WeaponType.Prime:
                        armor.MinDefense += 1;
                        armor.MaxDefense += 2;
                        armor.MinDefenseModifier += 0.10f;
                        armor.MaxDefenseModifier += 0.25f;
                        break;
                }
                ArmorOfTheDay.Add(armor);

                count++;
            }while(count < ProgressBehaviour.WeaponAndArmorQuantity);

            return ArmorOfTheDay;
        }

        private static WeaponType RandomQualityStatus()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,101);

            if(choice >= 0 && choice <= 15)
                return WeaponType.Rust;
            else if(choice >= 15 && choice <= 35)
                return WeaponType.Poorly;
            else if(choice >= 35 && choice <= 85)
                return WeaponType.Regular;
            else
                return WeaponType.Prime;
        }
    }
}