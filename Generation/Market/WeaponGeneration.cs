using System;
using System.Collections.Generic;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Loading;

namespace New_Arena_.Generation.Market
{
    class WeaponGeneration
    {
        private static List<Weapon> WeaponPrefab = ItemsLoading.WeaponList;

        public static List<Weapon> ListOfWeaponsOfTheDay(ref List<Weapon> todayWeapon)
        {
          todayWeapon = WeaponCreator(todayWeapon);

          return todayWeapon;
        }

        public static void ClearWeapons(List<Weapon> todayWeapon)
        {
          if(todayWeapon.Count > 0)
          {
            todayWeapon.Clear();
          }
        }

        private static List<Weapon> WeaponCreator(List<Weapon> todayWeapon)
        {
            List<int> weaponId = new();
            int count = 0;

            foreach(Weapon weapon in WeaponPrefab)
            {
                if(weapon.Id != 0)
                    if(weapon.Rarity <= ProgressBehaviour.CharacterLevel)
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
                        weapon.Cost -= (int)MathF.Truncate(weapon.Cost * 0.2f);
                        break;

                    case WeaponType.Poorly:
                        weapon.MaxDamage -= 1;
                        weapon.MaxDamageModifier -= 0.05f;
                        weapon.Cost -= (int)MathF.Truncate(weapon.Cost * 0.1f);
                        break;

                    case WeaponType.Prime:
                        weapon.MinDamage += 1;
                        weapon.MaxDamage += 2;
                        weapon.MinDamageModifier += 0.05f;
                        weapon.MaxDamageModifier += 0.15f;
                        weapon.Cost += (int)MathF.Truncate(weapon.Cost * 0.3f);
                        break;
                }
                todayWeapon.Add(weapon);

                count++;
            }while(count < ProgressBehaviour.WeaponAndArmorQuantity);

            return todayWeapon;
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