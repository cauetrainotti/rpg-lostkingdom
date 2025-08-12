using rpg_rewrite.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Item
{
    public class Weapon : Items.Item
    {
        public List<ClassType> AllowedClasses { get; set; }
        public int BonusSTR { get; set; }
        public int BonusDEX { get; set; }
        public int BonusCON { get; set; }
        public int BonusINT { get; set; }

        public Weapon(string name, string description, List<ClassType> allowedClasses) : base(name, description)
        {
        }
    }
    public class ArmaForte : Weapon
    { 
        public ArmaForte(string name, string description, List<ClassType> allowedClasses) : base(name, description, allowedClasses)
        {
            BonusSTR = 100;
        }
    }
}
