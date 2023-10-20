using System;
using System.Collections.Generic;
using System.Linq;
using New_Arena_.Behaviour;
using New_Arena_.Configuration;
using New_Arena_.Game_Objects.Base_Objects;
using New_Arena_.Loading;

namespace New_Arena_.Generation.Market
{
    class PotionGeneration
    {
        private static List<Potion> PotionOfTheDay = new();
        private static List<Potion> PotionPrefab = ItemsLoading.PotionList;

        public static List<Potion> ListOfPotionsOfTheDay()
        {
          PotionOfTheDay = PotionCreator();

          return PotionOfTheDay;
        }

        public static void ClearPotion()
        {
          if(PotionOfTheDay.Count > 0)
          {
            PotionOfTheDay.Clear();
          }
        }

        private static List<Potion> PotionCreator()
        {
            
            List<int> potionId = new();
            int count = 0;

            foreach (Potion potion in PotionPrefab)
            {
                potionId.Add(potion.Id);
            }

            do{
                int randId = potionId.Find(id => id == potionId[ManagerRandom.GetThreadRandom().Next(potionId.Count)]);

                if(PotionPrefab.Find(potion => potion.Id == randId).GetType() == typeof(StatusPotion))
                {
                    Potion potion = StatusPotionCreation(randId);
                    Potion potionOnTheList = PotionOfTheDay.FirstOrDefault(X => X.Id == potion.Id && X.Quality.ToString() == potion.Quality.ToString());

                    if(potionOnTheList != null)
                        potionOnTheList.Quantity++;
                    else
                        PotionOfTheDay.Add(potion);
                }

                if(PotionPrefab.Find(potion => potion.Id == randId).GetType() == typeof(HpAndMpPotion)){
                    Potion potion = HpAndMpPotionCreation(randId);
                    Potion potionOnTheList = PotionOfTheDay.FirstOrDefault(X => X.Id == potion.Id && X.Quality.ToString() == potion.Quality.ToString());

                    if(potionOnTheList != null)
                        potionOnTheList.Quantity++;
                    else
                        PotionOfTheDay.Add(potion);
                }

                count++;
            }while(count <= ProgressBehaviour.PotionQuantity);           

            return PotionOfTheDay;
        }

        private static StatusPotion StatusPotionCreation(int id)
        {
            StatusPotion statusPotion = new((StatusPotion)PotionPrefab.Find(potion => potion.Id == id))
            {
                Quality = RandomQualityStatus()
            };

            switch (statusPotion.Quality){
                case StatusPotionType.Poorly:
                    statusPotion.StatusQuantity = 1;
                    break;

                case StatusPotionType.Regular:
                    break;

                case StatusPotionType.Luxury:
                    statusPotion.StatusQuantity += 1;
                    statusPotion.TurnMax += 1;
                    break;

                case StatusPotionType.Long_Duration:
                    statusPotion.StatusQuantity -= 2;
                    statusPotion.TurnMax += 3;
                    break;

                case StatusPotionType.Double_Dose:
                    statusPotion.StatusQuantity += 2;
                    statusPotion.TurnMax += 2;
                    break;

                case StatusPotionType.Extra_Strong:
                    statusPotion.StatusQuantity += 4;
                    break;

                default:
                    break;
            }

            return statusPotion;
        }

        private static HpAndMpPotion HpAndMpPotionCreation(int id)
        {
            HpAndMpPotion hpAndMpPotion = new((HpAndMpPotion)PotionPrefab.Find(potion => potion.Id == id))
            {
                Quality = RandomQualityHpAndMp()
            };

            switch (hpAndMpPotion.Quality){
                case HpAndMpPotionType.Poorly:
                    hpAndMpPotion.HpModifier -= (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.2f);
                    hpAndMpPotion.MpModifier -= (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.2f);
                    break;

                case HpAndMpPotionType.Regular:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.1f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.1f);
                    break;

                case HpAndMpPotionType.Luxury:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.4f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.4f);
                    break;

                case HpAndMpPotionType.Double_Dose:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.6f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.6f);
                    break;

                case HpAndMpPotionType.Extra_Strong:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.8f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.8f);
                    break;

                default:
                    break;
            }

            return hpAndMpPotion;
        }

        private static Enum RandomQualityStatus()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,101);

            if(choice < 24)
                return StatusPotionType.Poorly;            
            else if(choice >= 25 && choice <= 50)
                return StatusPotionType.Regular;
            else if(choice >= 50 && choice <= 70)
                return StatusPotionType.Luxury;
            else if(choice >= 70 && choice <= 80)
                return StatusPotionType.Long_Duration;
            else if(choice >= 80 && choice <= 90)
                return StatusPotionType.Extra_Strong;
            else
                return StatusPotionType.Double_Dose;
        }

        private static Enum RandomQualityHpAndMp()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,91);

            if(choice < 24)
                return HpAndMpPotionType.Poorly;            
            else if(choice >= 25 && choice <= 50)
                return HpAndMpPotionType.Regular;
            else if(choice >= 50 && choice <= 70)
                return HpAndMpPotionType.Luxury;
            else if(choice >= 70 && choice <= 80)
                return HpAndMpPotionType.Double_Dose;
            else if(choice > 81 )
                return HpAndMpPotionType.Extra_Strong;

            return null;
        }
    }
}