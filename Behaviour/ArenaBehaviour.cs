using System;

class ArenaBehaviour
{
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

  public static int DayPassing(int day)
  {
    day++;
    return day;
  } 
}