using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rpg_rewrite.Models.Item;

namespace rpg_rewrite.Models.Character
{
    public abstract class BaseCharacter
    {
        public string Name { get; set; }
        public Class CharacterClass { get; set; }

        private const int BaseStats = 1;

        public int TotalConstitution => (BaseStats + CharacterClass.BonusCON + (EquippedWeapon?.BonusCON ?? 0));
        public int TotalDexterity => BaseStats + CharacterClass.BonusDEX + (EquippedWeapon?.BonusDEX ?? 0);
        public int TotalStrength => BaseStats + CharacterClass.BonusSTR + (EquippedWeapon?.BonusSTR ?? 0);
        public int TotalIntelligence => BaseStats + CharacterClass.BonusINT + (EquippedWeapon?.BonusINT ?? 0);

        public int TotalHealth => TotalConstitution * 10;
        public int CurrentHealth { get; set; }
        public bool IsAlive => CurrentHealth > 0;

        public Weapon? EquippedWeapon { get; set; }
        public int Level { get; set; }

        public BaseCharacter(string name, ClassType classType)
        {
            Name = name;
            Level = 1;
            CharacterClass = new Class(classType);
            CurrentHealth = TotalHealth;
        }
        public BaseCharacter(string name, ClassType classType, int level) : this (name, classType)
        {
            Level = level;
        }

        public int CalculateDamage()
        {
            switch (this.CharacterClass.Type)
            {
                case ClassType.Warrior:
                    return TotalStrength;
                case ClassType.Mage:
                    return TotalIntelligence;
                case ClassType.Tank:
                    return TotalConstitution / 2;
                case ClassType.Assassin:
                    return TotalDexterity + TotalStrength;
                case ClassType.Archer:
                    return TotalDexterity;
                default:
                    return TotalStrength;
            }
        }
    }
}