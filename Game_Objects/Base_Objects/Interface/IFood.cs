using System;

namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IFood
    {
        int Cost {get; set;}  
        int Rarity {get; set;}
        int RecoveryHp {get; set;}
        int RecoveryMp {get; set;}
        Enum Quality {get; set;}
        bool FoodEaten {get; set;}
    }
}