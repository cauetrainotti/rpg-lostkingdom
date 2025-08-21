using rpg_rewrite.Models.Character;
using rpg_rewrite.Models.Item;
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
            if (!HasAvailableItems())
                return "No available item in the item list.";

            int dropAmount = RandomGenerator.Next(1, 3);

            for (int i = 0; i < dropAmount; i++)
            {
                Items.Item droppedItem = ItemRandomizer();

                if (PlayerAlreadyHasNonPotion(player, droppedItem))
                    return GetAlreadyOwnedMessage(droppedItem);

                Items.Item createdItem = CreateNewItem(droppedItem);
                player.Inventory.Add(createdItem);

                return GetDropMessage(createdItem);
            }

            return null;
        }

        private bool HasAvailableItems()
        {
            return Items.Item.ItemList.Count > 0;
        }

        private bool PlayerAlreadyHasNonPotion(Player player, Items.Item droppedItem)
        {
            return player.Inventory.Contains(droppedItem) && droppedItem is not Potion;
        }

        private Items.Item CreateNewItem(Items.Item droppedItem)
        {
            return (Items.Item)Activator.CreateInstance(droppedItem.GetType());
        }

        private string GetAlreadyOwnedMessage(Items.Item droppedItem)
        {
            return $"You dropped {droppedItem.Name}, but you already have it.";
        }

        private string GetDropMessage(Items.Item item)
        {
            return item switch
            {
                Weapon weapon => $"You dropped: Level {weapon.Level} {weapon.Name}",
                _ => $"You dropped {item.Name}"
            };
        }

        private Items.Item ItemRandomizer()
        {
            int index = RandomGenerator.Next(0, Items.Item.ItemList.Count);
            return Items.Item.ItemList[index];
        }
    }
}
