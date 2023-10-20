using System;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Screens;

namespace New_Arena_.Menus
{
    class CharacterEquipamentMenu
    {
        public static void Decision(ref Character character)
        {
            string choice;
            
            do
            {
                GameScreen.CharacterStats(character);
                ChangeEquipamentScreen.PlayerEquipamentDisplay(character);

                Console.WriteLine("Change the equipament");
                Console.WriteLine("W - Weapon Change /// A - Armor Change \nWR - Weapon Remove /// AR - Armor Remove");
                Console.Write("Choose (X to go back):");
                choice = Console.ReadLine().ToUpper();

                switch(choice)
                {
                    case "W":
                        if(character.EquipamentBag.Where(weapon => weapon.GetType() == typeof(Weapon)).Count() != 0)
                            CharacterManipualtion.ChangeWeapon(character);
                        else
                            UpdateConsole.StaticMessage("No weapon to choose");
                        break;

                    case "A":
                        if(character.EquipamentBag.Where(armor => armor.GetType() == typeof(Armor)).Count() != 0)
                            CharacterManipualtion.ChangeArmor(character);
                        else
                            UpdateConsole.StaticMessage("No armor to choose");
                        break;

                    case "WR":
                        if(character.Weapon.Id == 0)
                            UpdateConsole.StaticMessage("No weapon to remove");
                        else
                            character.RemoveWeapon();
                        break;

                    case "AR":
                        if(character.Armor.Id == 0)
                            UpdateConsole.StaticMessage("No armor to remove");
                        else
                            character.RemoveArmor();
                        break;
                }

            }while(choice.ToUpper() != "X");
        }
    }
}