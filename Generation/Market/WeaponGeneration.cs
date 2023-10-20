using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Loading;

namespace New_Arena_.Generation.Market
{
    class WeaponGeneration
    {
        private static List<Weapon> WeaponOfTheDay = new();
        private static List<Weapon> WeaponPrefab = ItemsLoading.WeaponList;

        public static List<Weapon> ListOfWeaponsOfTheDay()
        {
          WeaponOfTheDay = WeaponCreator();

          return WeaponOfTheDay;
        }

        public static void ClearWeapons()
        {
          if(WeaponOfTheDay.Count > 0)
          {
            WeaponOfTheDay.Clear();
          }
        }

        private static List<Weapon> WeaponCreator()
        {
            List<int> weaponId = new();
            int count = 0;

            foreach(Weapon weapon in WeaponPrefab)
            {
                if(weapon.Id != 0)
                    weaponId.Add(weapon.Id);
            }

            do
            {
                int randId = weaponId[ManagerRandom.GetThreadRandom().Next(weaponId.Count)];

                Weapon weapon = new(WeaponPrefab.Find(weapon => weapon.Id == randId))
                {
                    Quality = RandomQualityStatus()
                };

                switch (weapon.Quality)
                {
                    case WeaponType.Rust:
                        weapon.MinDamage -= 1;
                        weapon.MaxDamage -= 1;
                        weapon.MinDamageModifier -= 0.10f;
                        weapon.MaxDamageModifier -= 0.15f;
                        break;

                    case WeaponType.Poorly:
                        weapon.MaxDamage -= 1;
                        weapon.MaxDamageModifier -= 0.05f;
                        break;

                    case WeaponType.Prime:
                        weapon.MinDamage += 1;
                        weapon.MaxDamage += 2;
                        weapon.MinDamageModifier += 0.05f;
                        weapon.MaxDamageModifier += 0.15f;
                        break;
                }
                WeaponOfTheDay.Add(weapon);

                count++;
            }while(count < ProgressBehaviour.WeaponAndArmorQuantity);

            return WeaponOfTheDay;
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