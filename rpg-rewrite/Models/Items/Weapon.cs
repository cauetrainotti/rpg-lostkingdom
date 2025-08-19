using rpg_rewrite.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Item
{
    public class Weapon : Items.Item
    {
        public int Level { get; set; }
        public List<ClassType> AllowedClasses { get; set; }
        public int BonusSTR => BaseBonusSTR + (Level * 4);
        public int BonusDEX { get; set; }
        public int BonusCON { get; set; }
        public int BonusINT { get; set; }

        public Weapon(string name, string description, List<ClassType> allowedClasses, int playerLevel) : base(name, description)
        {
            Level = LevelRangeRandomizer(playerLevel);
            AllowDuplicates = false;
        }
        private int LevelRangeRandomizer(int playerLevel)
        {
            Random levelRange = new Random();
            return playerLevel + levelRange.Next(-3, 3);
        }

        public class ArmaForte : Weapon
        {
            public ArmaForte(string name, string description, List<ClassType> allowedClasses, int playerLevel) : base(name, description, allowedClasses, playerLevel)
            {
                BaseBonus = 100;
            }
        }
    }
}
