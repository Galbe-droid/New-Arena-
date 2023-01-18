using System;

class ArenaBehaviour
{
  //Controls Day and night behaviour, certain activities depend on it 
  public static bool DayToNight(bool dayTime)
  {
    if(dayTime == true)
    {
      dayTime = false;
      return dayTime;
    }
    else
    {
      dayTime = true;
      return dayTime;
    }
  }

  //Count the days passing no usage for now 
  public static int DayPassing(int day, bool dayTime)
  {
    if(!dayTime){
      day++;
    }    
    return day;
  } 
}