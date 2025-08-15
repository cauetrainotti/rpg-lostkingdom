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
        public int Level { get; set; }
        public Class CharacterClass { get; set; }

        private const int BaseConstitution = 1;
        private const int BaseDexterity = 1;
        private const int BaseStrength = 1;
        private const int BaseIntelligence = 1;

        public int TotalConstitution => BaseConstitution + CharacterClass.BonusCON + EquippedWeapon.BonusCON;
        public int TotalDexterity => BaseDexterity + CharacterClass.BonusDEX + EquippedWeapon.BonusDEX;
        public int TotalStrength => BaseStrength + CharacterClass.BonusSTR + EquippedWeapon.BonusSTR;
        public int TotalIntelligence => BaseIntelligence + CharacterClass.BonusINT + EquippedWeapon.BonusINT;

        public int CurrentConstitution { get; set; }

        public Weapon? EquippedWeapon { get; set; }

        public BaseCharacter(string name, ClassType classType)
        {
            Name = name;
            Level = 1;
            CharacterClass = new Class(classType);
            CurrentConstitution = TotalConstitution;
        }
        public BaseCharacter(string name, ClassType classType, int level) : this (name, classType)
        {
            Level = level;
        }
    }
}