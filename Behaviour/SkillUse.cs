using System;
using System.Collections.Generic;
using System.Linq;

namespace New_Arena_.Behaviour
{
    class SkillUse
    {
        public static void AttackSkillUse<T>(T attacker, T defender, AttackSkill attackSkill) where T : Creature
        {
            //Random numbers 
            Random rand = new();               

            int _damage = 0;
            int _protection = rand.Next(0,21);

            //Iniitiate Cooldown 
            attacker.SkillTrained[attacker.SkillTrained.IndexOf(attackSkill)].CooldownControl();

            //Add damage and them reduce with defense 
            _damage += StatCheck(attackSkill.Stat, attackSkill, defender);
            _damage += attackSkill.Applying();
            _damage -= (attacker.TotalDefense() + _protection);
            //

            if (_damage > 0)
            {
              Console.WriteLine($"{attacker.Name} uses {attackSkill.Name} on {defender.Name} it causes {_damage} Damage !");
              defender.Damage += _damage;
            }
            else
            {
                Console.WriteLine($"{attacker.Name} uses {attackSkill.Name} on {defender.Name} and {defender.Name} Blocks the incoming attack !");
            }
        }

        public static void DefenseSkillUse<T>(T user, DefenseSkill defenseSkill) where T : Creature
        {
            //Initiate a defense skill
            int _healing = 0;

            //Iniitiate Cooldown 
            user.SkillTrained[user.SkillTrained.IndexOf(defenseSkill)].CooldownControl();
            
            //Add healing points 
            _healing += StatCheck(defenseSkill.Stat, defenseSkill, user);
            _healing += defenseSkill.Applying();

            //Reduce the damage of the monster 
            user.Damage = _healing >= user.Damage ? 0 : user.Damage - _healing;

            Console.WriteLine($"{user.Name} uses {defenseSkill.Name} healing {Convert.ToString(_healing)} of Damage");
        }

        public static void BuffSkillUse<T>(T user, BuffSkill buffSkill) where T : Creature
        {
            //Add the buff and active the buff cooldown on the user 
            user.BuffActive.Add(buffSkill);
            user.SkillTrained[user.SkillTrained.IndexOf(buffSkill)].CooldownControl();

            string defBuff = $"{user.Name} uses {buffSkill.Name}, feeling protected !";
            string dodgeBuff = $"{user.Name} uses {buffSkill.Name}, increasing speed !";
            string atkBuff = $"{user.Name} uses {buffSkill.Name}, gonna hurt!";

            UpdateConsole.MultipleTexts(defBuff, dodgeBuff, atkBuff, buffSkill.WhereToApply);
        }

        public static void DebuffSkillUse<T>(T attacker, T defender, DebuffSkill debuffSkill) where T : Creature
        {
            //Add the debuff and active the buff cooldown on the user 
            defender.DebuffActive.Add(debuffSkill);
            attacker.SkillTrained[attacker.SkillTrained.IndexOf(debuffSkill)].CooldownControl();

            string defDebuff = $"{attacker.Name} uses {debuffSkill.Name} on {defender.Name} its look a little vulnearable now!";
            string dodgeDebuff = $"{attacker.Name} uses {debuffSkill.Name} on {defender.Name} its look a slower now!";
            string atkDebuff = $"{attacker.Name} uses {debuffSkill.Name} on {defender.Name} its look less aggressive now!";
            UpdateConsole.MultipleTexts(defDebuff, dodgeDebuff, atkDebuff, debuffSkill.WhereToApply);
        }

        public static void CooldownCounting(Character c, Monster m)
        {
            //Easy to navigate variables
            List<SkillBase> playerBuffs = c.BuffActive;
            List<SkillBase> playerDebuff = c.DebuffActive;

            List<SkillBase> monsterBuffs = m.BuffActive;
            List<SkillBase> monsterDebuffs = m.DebuffActive;

            if(playerBuffs.Count > 0)
                CooldownChecking(playerBuffs);
            if(playerDebuff.Count > 0)
                CooldownChecking(playerDebuff);

            if(monsterBuffs.Count > 0)
                CooldownChecking(monsterBuffs);
            if(monsterDebuffs.Count > 0)
                CooldownChecking(monsterDebuffs);
            
        }

        private static void CooldownChecking(List<SkillBase> list)
        {
            foreach(SkillBase s in list){
                //Check if the buff or debuff is still activated on enemy or player, if is them the cooldown wont count 
                bool _stillActive = false;
                //If this is true the cooldown start to count 
                bool _OnCooldown = false;

                //In order to initiate a cooldown count and turn the Cooldown boolean to false, first they need to be active.
                //This condition is here because it is checked every turn 
                if (s.Cooldown == true)
                {
                    if (s.GetType() == typeof(BuffSkill))
                    {
                        _stillActive = list.Exists(skill => skill.Id == s.Id) ? true : false;
                    }
                    else
                    {
                        //Attack and Defense Skill don't have an active state so it always false 
                        _stillActive = false;
                    }

                    _OnCooldown = s.CooldownTurns < s.TurnMax ? true : false;

                    if (!_stillActive)
                    {
                        if (_OnCooldown)
                            s.CooldownCount();
                        else
                            s.CooldownControl();
                    }
                }
            }            
        }

        private static int StatCheck<T>(StatsType stat, OneShotSkill skill, T m) where T : Creature
        {
            switch (stat)
            {
                case StatsType.Str:
                    return skill.ApplyModifier(m.Str);
                case StatsType.Inte:
                    return skill.ApplyModifier(m.Int);
                case StatsType.Agi:
                    return skill.ApplyModifier(m.Agi);
                case StatsType.Vig:
                    return skill.ApplyModifier(m.Vig);
                default:
                    Console.WriteLine("Error.");
                    return 0;
            }
        }
    }
}