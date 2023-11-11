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
        private static List<Potion> PotionPrefab = ItemsLoading.PotionList;

        public static List<Potion> ListOfPotionsOfTheDay(ref List<Potion> todayPotion)
        {
          todayPotion = PotionCreator(todayPotion);

          return todayPotion;
        }

        public static void ClearPotion(List<Potion> todayPotion)
        {
          if(todayPotion.Count > 0)
          {
            todayPotion.Clear();
          }
        }

        private static List<Potion> PotionCreator(List<Potion> todayPotion)
        {
            todayPotion = new();
            
            List<int> potionId = new();
            int count = 0;

            foreach (Potion potion in PotionPrefab)
            {
                if(potion.Rarity <= ProgressBehaviour.CharacterLevel)
                    potionId.Add(potion.Id);
            }

            do{
                int randId = potionId.Find(id => id == potionId[ManagerRandom.GetThreadRandom().Next(potionId.Count)]);

                if(PotionPrefab.Find(potion => potion.Id == randId).GetType() == typeof(StatusPotion))
                {
                    Potion potion = StatusPotionCreation(randId);
                    if(todayPotion.Count != 0)
                    {
                        Potion potionOnTheList = todayPotion.FirstOrDefault(X => X.Id == potion.Id && X.Quality.ToString() == potion.Quality.ToString());

                        if(potionOnTheList != null)
                            potionOnTheList.Quantity++;
                        else
                            todayPotion.Add(potion);
                    }  
                    else    
                        todayPotion.Add(potion);            
                }

                if(PotionPrefab.Find(potion => potion.Id == randId).GetType() == typeof(HpAndMpPotion)){
                    Potion potion = HpAndMpPotionCreation(randId);

                    if(todayPotion.Count != 0)
                    {
                        Potion potionOnTheList = todayPotion.FirstOrDefault(X => X.Id == potion.Id && X.Quality.ToString() == potion.Quality.ToString());

                        if(potionOnTheList != null)
                            potionOnTheList.Quantity++;
                        else
                            todayPotion.Add(potion);
                    }  
                    else    
                        todayPotion.Add(potion);                    
                }

                count++;
            }while(count <= ProgressBehaviour.PotionQuantity);           

            return todayPotion;
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
                    statusPotion.Cost -= (int)MathF.Truncate(statusPotion.Cost * 0.1f);
                    break;

                case StatusPotionType.Luxury:
                    statusPotion.StatusQuantity += 1;
                    statusPotion.TurnMax += 1;
                    statusPotion.Cost += (int)MathF.Truncate(statusPotion.Cost * 0.15f);
                    break;

                case StatusPotionType.Long_Duration:
                    statusPotion.StatusQuantity -= 2;
                    statusPotion.TurnMax += 3;
                    statusPotion.Cost += (int)MathF.Truncate(statusPotion.Cost * 0.20f);
                    break;

                case StatusPotionType.Double_Dose:
                    statusPotion.StatusQuantity += 2;
                    statusPotion.TurnMax += 2;
                    statusPotion.Cost += (int)MathF.Truncate(statusPotion.Cost * 0.35f);
                    break;

                case StatusPotionType.Extra_Strong:
                    statusPotion.StatusQuantity += 4;
                    statusPotion.Cost += (int)MathF.Truncate(statusPotion.Cost * 0.20f);
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
                    hpAndMpPotion.Cost -= (int)MathF.Truncate(hpAndMpPotion.Cost * 0.1f);
                    break;

                case HpAndMpPotionType.Regular:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.1f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.1f);
                    break;

                case HpAndMpPotionType.Luxury:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.4f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.4f);
                    hpAndMpPotion.Cost += (int)MathF.Truncate(hpAndMpPotion.Cost * 0.2f);
                    break;

                case HpAndMpPotionType.Double_Dose:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.6f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.6f);
                    hpAndMpPotion.Cost += (int)MathF.Truncate(hpAndMpPotion.Cost * 0.3f);
                    break;

                case HpAndMpPotionType.Extra_Strong:
                    hpAndMpPotion.HpModifier += (int)Math.Truncate(hpAndMpPotion.HpModifier * 0.8f);
                    hpAndMpPotion.MpModifier += (int)Math.Truncate(hpAndMpPotion.MpModifier * 0.8f);
                    hpAndMpPotion.Cost += (int)MathF.Truncate(hpAndMpPotion.Cost * 0.5f);
                    break;

                default:
                    break;
            }

            return hpAndMpPotion;
        }

        private static StatusPotionType RandomQualityStatus()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,101);
            List<int> chance = ProgressBehaviour.StatusPotionQualityChance;

            if(choice < chance[0])
                return StatusPotionType.Poorly;            
            else if(choice >= chance[0] && choice < chance[1])
                return StatusPotionType.Regular;
            else if(choice >= chance[1] && choice < chance[2])
                return StatusPotionType.Luxury;
            else if(choice >= chance[2] && choice < chance[3])
                return StatusPotionType.Long_Duration;
            else if(choice >= chance[3] && choice < chance[4])
                return StatusPotionType.Extra_Strong;
            else
                return StatusPotionType.Double_Dose;
        }

        private static HpAndMpPotionType RandomQualityHpAndMp()
        {
            int choice = ManagerRandom.GetThreadRandom().Next(0,101);
            List<int> chance = ProgressBehaviour.StatusPotionQualityChance;

            if(choice < chance[0])
                return HpAndMpPotionType.Poorly;            
            else if(choice >= chance[0] && choice < chance[1])
                return HpAndMpPotionType.Regular;
            else if(choice >= chance[1] && choice < chance[2])
                return HpAndMpPotionType.Luxury;
            else if(choice >= chance[2] && choice < chance[3])
                return HpAndMpPotionType.Double_Dose;
            else
                return HpAndMpPotionType.Extra_Strong;
        }
    }
}