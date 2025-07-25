using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Character
{
    internal class Player : BaseCharacter
    {
        public List<Items.Item> Inventory { get; private set; } = new List<Items.Item>();
        public Player(string name) : base(name)
        {
        }

        public void GetXP(int xpQuantity)
        {
            if (xpQuantity > 0)
            {
                XP += xpQuantity;
                while (XP >= XPperLevel)
                {
                    LevelUp();
                }
            }
        }
        public void LevelUp()
        {
            XP -= XPperLevel;
            Level++;
        }
        public void GetItem(Items.Item item)
        {
            Inventory.Add(item);
        }
        public void RemoveItem(Items.Item item)
        {
            Inventory.Remove(item);
        }
    }
}
