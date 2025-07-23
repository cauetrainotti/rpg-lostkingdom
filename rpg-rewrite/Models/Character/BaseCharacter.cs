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
        public int XP { get; set; }
        public int MaxHealth { get; protected set; }
        private int CurrentHealth { get; set; }
        public int Constitution { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public List<Item.Item> Inventory { get; private set; } = new List<Item.Item>();
        public Weapon EquippedWeapon { get; private set; }


        public BaseCharacter(string name)
        {
            Name = name;
            Level = 1;
            XP = 0;
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
        }
    }
}