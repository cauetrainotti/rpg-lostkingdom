using rpg_rewrite.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.CombatRelated
{
    internal class RewardSystem
    {
        private static readonly Random RandomGenerator = new Random();

        private const int DropChancePercent = 40;
        private const int MinXP = 20;
        private const int MaxXP = 50;
        public string? RewardRoll(Player player, bool isAlive)
        {
            if (!isAlive)
            {
                return "You are dead and cannot get drops";
            }

            if (isAlive)
            {

                if (!PlayerGetDrops())
                    return "You didn't get a drop";

                return GiveItemDrop(player);
            };
            return null;
        }

        private void GrantXP(Player player)
        {
            int xp = (RandomGenerator.Next(MinXP, MaxXP));
            player.GetXP(xp);
        }
        private bool PlayerGetDrops()
        {
            return RandomGenerator.Next(100) > DropChancePercent;
        }
        private string? GiveItemDrop(Player player)
        {
            int dropAmount = RandomGenerator.Next(1, 3);
            for (int i = 0; i < dropAmount; i++)
            {
                Items.Item droppedItem = ItemRandomizer();

                if (player.Inventory.Contains(droppedItem))
                {
                    return $"You dropped {droppedItem.Name}, but you already have it.";
                }
                else
                {
                    player.Inventory.Add(droppedItem);
                    return $"You dropped: Level {droppedItem.Level} {droppedItem.Name}";
                }
            }
            return null;
        }
        private Items.Item ItemRandomizer()
        {
            int index = RandomGenerator.Next(0, Items.Item.ItemList.Count);
            return Items.Item.ItemList[index];
        }
    }
}
