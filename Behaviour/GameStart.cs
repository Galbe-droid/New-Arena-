using System;

namespace New_Arena_.Behaviour
{
    class GameStart
    {
           //Game start it must contains a character, contains screen and info about the main game screen   
        public static void Start(Character chosen)
        {
            bool GameOn = true;
            int days = chosen.Days;
            string dayMoment;
            bool daytime = chosen.Daytime;    
            bool timePass = chosen.TimePass;   

            while(GameOn)
            {
                ProgressBehaviour.CheckingValuesInLevel(chosen);
                if(daytime == true)
                {
                  //Make list persistent
                  if(timePass){
                    chosen.CleanTodayLists();
                    chosen.GetTodayLists();
                    days++;
                  }
                  ArenaBehaviour.ReceiveLists(chosen);
                  dayMoment = " Daytime";
                }
                else
                {
                  //Make list persistent
                  if(timePass){    
                    chosen.CleanTodayLists();
                    chosen.GetTodayLists();      
                  }
                  ArenaBehaviour.ReceiveLists(chosen);
                  dayMoment = " Nightime";        
                }     
                
                //If player dont advance time the list doens't change 
                if(timePass){
                  chosen.TimePass = !chosen.TimePass;
                }
                
                //Screen info for caracter stats 
                GameScreen.CharacterStats(chosen);
                //Screen info for Game activities
                GameScreen.ArenaChoices(days, dayMoment);
                
                Console.Write("Chose:");      
                string Decision = Console.ReadLine().ToUpper();
                
                if(Decision == "E")
                {
                  GameOn = false;
                }
                else
                {
                  //Exit waits for a boolean value its enter on the other screen and then go back to the main game screen        
                  GameStartMenu.ArenaMenu(Decision,ref chosen, ref daytime, ref timePass);        
                }      
                
                Console.Clear();
            }        
        }
    }
}