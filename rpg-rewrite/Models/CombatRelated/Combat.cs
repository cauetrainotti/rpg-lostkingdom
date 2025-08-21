using rpg_rewrite.Models.Character;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.CombatRelated
{
    public class Combat
    {
        private static readonly Random attackerRandomizer = new Random();
        public static void CombatStart(Player player, Enemy enemy)
        {
            (BaseCharacter attacker, BaseCharacter defender) = DetermineAttacker(player, enemy);
            PrintCombatInterface(attacker, defender);
            do
            {
                if (attacker == player)
                    PlayerTurn();
                else
                    EnemyTurn();
            } while (attacker.IsAlive && defender.IsAlive);
        }

        public static (BaseCharacter attacker, BaseCharacter defender) DetermineAttacker(Player player, Enemy enemy)
        {
            if (player.TotalDexterity > enemy.TotalDexterity)
                return (player, enemy);

            else if (player.TotalDexterity < enemy.TotalDexterity)
                return (enemy, player);

            else
            {
                if (attackerRandomizer.Next(0, 2) == 0)
                    return (player, enemy);
                else
                    return (enemy, player);
            }
        }
        public static int PlayerTurn()
        {
            return 1;
        }
        public static int EnemyTurn()
        {
            return 2;
        }
    }
}
