using System;
using System.Collections.Generic;
using New_Arena_.Game_Objects.Base_Objects;

namespace New_Arena_.Screens
{
    public class PotionMarketScreen
    {
        public static void PotionDisplay()
        {
            int count = 0;
            Console.WriteLine("============Potions==============");

            foreach(Potion p in ArenaBehaviour.potionsOfTheDay)
            {
                if(p.GetType() == typeof(StatusPotion))
                {
                    StatusPotion s = (StatusPotion)p;

                    string qualityString;
                    if(s.Quality.ToString() == StatusPotionType.Double_Dose.ToString())
                        qualityString = "Double Dose";
                    else if(s.Quality.ToString() == StatusPotionType.Extra_Strong.ToString())
                        qualityString = "Extra Strong";
                    else if(s.Quality.ToString() == StatusPotionType.Long_Duration.ToString())
                        qualityString = "Long Duration";
                    else
                        qualityString = s.Quality.ToString();

                    if(p.Quantity >= 1)
                        Console.WriteLine(count + 1 + $" - Name: {s.Name} / Mod: {s.BuffManipulated}  Qty: {s.StatusQuantity}  Turns: {s.TurnMax} / Quality: {qualityString}  Cost: {s.Cost}  x{s.Quantity}");
                    else{
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(count + 1 + $" - Name: {s.Name} / Mod: {s.BuffManipulated}  Qty: {s.StatusQuantity}  Turns: {s.TurnMax} / Quality: {qualityString}  Cost: {s.Cost} x{s.Quantity}");
                        Console.ResetColor();
                    }                        
                }
                else{
                    HpAndMpPotion h = (HpAndMpPotion)p;

                    string qualityString;
                    if(h.Quality.ToString() == HpAndMpPotionType.Double_Dose.ToString())
                        qualityString = "Double Dose";
                    else if(h.Quality.ToString() == HpAndMpPotionType.Extra_Strong.ToString())
                        qualityString = "Extra Strong";
                    else
                        qualityString = h.Quality.ToString();

                    if(h.Quantity >= 1)
                        Console.WriteLine(count + 1 + $" - Name: {h.Name} / Hp: {h.HpModifier}  Mp: {h.MpModifier} / Quality: {qualityString}  Cost: {h.Cost} x{h.Quantity}");
                    else{
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(count + 1 + $" - Name: {h.Name} / Hp: {h.HpModifier}  Mp: {h.MpModifier} / Quality: {qualityString}  Cost: {h.Cost} x{h.Quantity}");
                        Console.ResetColor();
                    }
                }
                count ++ ;
            }
        }       
    }
}