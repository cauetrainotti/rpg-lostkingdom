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
        public int XPperLevel = 100;
        public int XP { get; set; }
        public Classes CharacterClass { get; set; }

        private const int BaseConstitution = 1;
        private const int BaseDexterity = 1;
        private const int BaseStrength = 1;
        private const int BaseIntelligence = 1;

        public int TotalConstitution => BaseConstitution + CharacterClass.BonusCON;
        public int TotalDexterity => BaseDexterity + CharacterClass.BonusDEX;
        public int TotalStrength => BaseStrength + CharacterClass.BonusSTR;
        public int TotalIntelligence => BaseIntelligence + CharacterClass.BonusINT;

        public int CurrentConstitution { get; set; }

        public Weapon EquippedWeapon { get; private set; }

        public BaseCharacter(string name)
        {
            Name = name;
            Level = 1;
            XP = 0;
            CurrentConstitution = TotalConstitution;
        }
    }
}