using System.Collections.Generic;

namespace New_Arena_.Game_Objects.Base_Objects.Interface
{
    interface IPotionEffect
    {
        List<Potion> PotionEffect {get; set;}

        void AddEffects(StatusPotion statusPotion);

        void StatusPotionTurnPass();

        void PotionEffectRemoval();

        void Checking();
    }
}