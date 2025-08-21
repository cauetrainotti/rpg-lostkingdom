using rpg_rewrite.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Item
{
    public enum AttributeType
    {
        STR,
        DEX,
        CON,
        INT
    }
    public class Weapon : Items.Item
    {
        public int Level { get; set; }
        public AttributeType BonusAttribute { get; set; }
        public List<ClassType> AllowedClasses { get; set; }
        private const int FlatBonus = 10;
        public int Bonus => FlatBonus + (Level * 5);

        public int BonusSTR => BonusAttribute == AttributeType.STR ? Bonus : 0;
        public int BonusDEX => BonusAttribute == AttributeType.DEX ? Bonus : 0;
        public int BonusCON => BonusAttribute == AttributeType.CON ? Bonus : 0;
        public int BonusINT => BonusAttribute == AttributeType.INT ? Bonus : 0;

        public Weapon(string name, string description, List<ClassType> allowedClasses, int playerLevel, AttributeType bonusAttribute) : base(name, description)
        {
            Level = LevelRangeRandomizer(playerLevel);
            BonusAttribute = bonusAttribute;
            AllowDuplicates = false;
        }
        private int LevelRangeRandomizer(int playerLevel)
        {
            Random levelRange = new Random();
            return playerLevel + levelRange.Next(-3, 3);
        }

        public class ArmaForte : Weapon
        {
            public ArmaForte(string name, string description, List<ClassType> allowedClasses, int playerLevel, AttributeType bonusAttribute) : base(name, description, allowedClasses, playerLevel, bonusAttribute)
            {
            }
        }
    }
}
