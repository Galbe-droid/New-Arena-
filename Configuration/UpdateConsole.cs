using System;

class UpdateConsole{
    //Help with update the console when need 
    public static void UpdateCombatStats(Character c, Monster m){
        Console.Clear();
        CombatScreen.Stats(c, m);
    }

    //Generate a static message for the player
    public static void StaticMessage(string text){
        Console.WriteLine(text + " (Press any key to continue.)");
        Console.ReadLine();
    }

    //Generate a multiple text for the buffs and debuffs
    public static void MultipleTexts(string defText, string dodgeText, string atkText, BuffType type){
        if(type == BuffType.Defense){
            Console.WriteLine(defText);
        }
        else if(type == BuffType.Dodge){
            Console.WriteLine(dodgeText);
        }else{
            Console.WriteLine(atkText);
        }
    }
}