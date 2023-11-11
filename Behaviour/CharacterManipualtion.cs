using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Screens;

namespace New_Arena_.Behaviour
{
    class CharacterManipualtion
    {
        public static Character ChangeWeapon(Character character)
        {
            int choice;
            int page = 1;

            //Recreates the item bag but with only weapon
            List<ItemBase> weaponList = character.EquipamentBag.Where(weapon => weapon.GetType() == typeof(Weapon)).ToList();
            //This int needs to be initiated after everything, it controls the 3 itens per page and need to be initiated after the list but before the pageLimite
            int itemCount = weaponList.Count;
            //Create pages in case the skill list has more then 3 itens
            decimal pageLimit = (weaponList.Count < 3) ? 1 : Math.Ceiling(Convert.ToDecimal(itemCount)/3);

            WeaponListScreen.Display(page, pageLimit, weaponList);

            //Loop for changing the page in case it has more then 3 Itens 
            do
            {
              if(pageLimit > 1)
              {
                choice = InputCheck.LimitCheck("Choose Skill by number (0 to go back) / 4 - last page / 5 - next page", 5);
                if (choice == 4 && page > 1){
                  page -= 1;
                }
                else if (choice == 5 && page < pageLimit){
                  page += 1; 
                }
                else if(choice == 4 && page == 1){
                  page = Convert.ToInt32(pageLimit);
                }
                else if(choice == 5 && page == pageLimit){
                  page = 1;
                }
                else if(choice == 0){
                  return character;
                }
                else{
                  //multiplay the choice with the page getting the correct position 
                  choice = (choice * page) - 1;
        
                  if(choice != -1)
                  {
                    character = ChoiceMade(weaponList[choice], character);
                    return character;
                  }
                  else
                    return character;           
                }        
              }
              else
              {
                choice = InputCheck.ListLength("Choose Item by number: ", itemCount);
                choice -= 1;
        
                if(choice != -1)
                {
                  character = ChoiceMade(weaponList[choice], character);
                  return character;
                }
                else
                  return character;          
              }  
            }while(choice == 4 || choice == 5);   
        
            return character;
        }

        public static Character ChangeArmor(Character character)
        {
            int choice;
            int page = 1;

            //Recreates the item bag but with only armor
            List<ItemBase> armorList = character.EquipamentBag.Where(armor => armor.GetType() == typeof(Armor)).ToList();
            //This int needs to be initiated after everything, it controls the 3 itens per page and need to be initiated after the list but before the pageLimite
            int itemCount = armorList.Count;
            //Create pages in case the skill list has more then 3 itens
            decimal pageLimit = (armorList.Count < 3) ? 1 : Math.Ceiling(Convert.ToDecimal(itemCount)/3);

            ArmorListScreen.Display(page, pageLimit, armorList);

            //Loop for changing the page in case it has more then 3 Itens 
            do
            {
              if(pageLimit > 1)
              {
                choice = InputCheck.LimitCheck("Choose Skill by number (0 to go back) / 4 - last page / 5 - next page", 5);
                if (choice == 4 && page > 1){
                  page -= 1;
                }
                else if (choice == 5 && page < pageLimit){
                  page += 1; 
                }
                else if(choice == 4 && page == 1){
                  page = Convert.ToInt32(pageLimit);
                }
                else if(choice == 5 && page == pageLimit){
                  page = 1;
                }
                else if(choice == 0){
                  return character;
                }
                else{
                  //multiplay the choice with the page getting the correct position 
                  choice = (choice * page) - 1;
        
                  if(choice != -1)
                  {
                    character = ChoiceMade(armorList[choice], character);
                    return character;
                  }
                  else
                    return character;           
                }        
              }
              else
              {
                choice = InputCheck.ListLength("Choose Item by number: ", itemCount);
                choice -= 1;
        
                if(choice != -1)
                {
                  character = ChoiceMade(armorList[choice], character);
                  return character;
                }
                else
                  return character;          
              }  
            }while(choice == 4 || choice == 5);   
        
            return character;
        }

        private static Character ChoiceMade<T>(T equipament, Character character) where T : ItemBase
        {               
            if(equipament.GetType() == typeof(Armor))
            {
                Armor newArmor = (Armor)(object)equipament;
                character.ChangeArmor(newArmor);

            }
            else
            {
                Weapon newWeapon = (Weapon)(object)equipament;
                character.ChangeWeapon(newWeapon);
            }

            character.UpdateMinMaxValues();

            return character;
        }
    }

    
}