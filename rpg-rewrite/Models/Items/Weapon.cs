using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Item
{
    public class Weapon : Items.Item
    {
        public List<string> AllowedClasses { get; set; }
        public int Damage { get; set; }
        public Weapon(string name, string description, List<string> allowedClasses, int damage) : base(name, description)
        {
            Damage = damage;
        }
    }
}
