using System;
using New_Arena_.Configuration;
using New_Arena_.Save;

namespace New_Arena_.Behaviour
{
    class CombatStart
    {
        //Combat Screen
        public static void Combat(Character chosen, Monster monster)
        {
            bool CombatOn = true;
            bool SomeoneDied = false;
            bool charBigInit;

            //If both caracter are alive this boolean is true
            while(CombatOn)
            {      
                //Ignore values that are the same 
                do
                {
                    chosen.Initiative = ManagerRandom.GetThreadRandom().Next(0,21) + chosen.Agi;
                    monster.Initiative = ManagerRandom.GetThreadRandom().Next(0,21) + monster.Agi;
                }while(chosen.Initiative == monster.Initiative);

                //Send to the game if the character will be the first to act
                if (chosen.Initiative > monster.Initiative){
                    charBigInit = true;
                }
                else{
                    charBigInit = false;
                }

                Console.Clear();
                if(chosen.DeathCheck() || monster.DeathCheck()){
                    SomeoneDied = true;
                }

                //Checks if both caracter and player arent dead
                if(!SomeoneDied)
                {
                    ArenaBehaviour.TurnControl(ref chosen, ref monster, charBigInit);
                    Console.WriteLine("End of Turn !");
                    Console.ReadLine();
                }
                else
                {
                    //Only Vicotry screen for now 
                    if(monster.Dead == true)
                    {
                        Console.WriteLine($"                  VICTORY !!!\n================================================\n       Xp gain: {monster.XpReward}            Gold gain: {monster.GoldReward}");
                        chosen.ReceiveReward(monster.XpReward, monster.GoldReward);
                        CombatOn = false;
                        Console.ReadLine();
                        chosen.CleanBuffDebuffsAndPotionList();
                        VerifySaveFile.GameSave(chosen);
                    }
                    else if(chosen.Dead == true)
                    {
                        chosen.Damage = 0;
                        chosen.LostABattle();
                        Console.WriteLine($"                  DEFEATED !!!\n================================================\n       Xp lost: {(int)MathF.Truncate(chosen.Xp - (chosen.Xp * 0.20f))}            Gold lost: {(int)MathF.Truncate(chosen.Gold - (chosen.Gold * 0.20f))}");
                        CombatOn = false;
                        chosen.Dead = false;
                        Console.ReadLine();
                        chosen.CleanBuffDebuffsAndPotionList();
                        VerifySaveFile.GameSave(chosen);
                    }
                }
            }
        }
    }
}