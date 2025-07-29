using rpg_rewrite;
using rpg_rewrite.Models.Character;
using rpg_rewrite.Models.Item;

Main();
static void Main()
{
    List<ClassType> classes = new List<ClassType>()
    {
        ClassType.Mage
    };
    Weapon armaForte = new ArmaForte("arma forte", "forte", classes);
    Player player = new Player("Cauê", ClassType.Mage);
    Console.WriteLine(player.TotalStrength);
    player.EquipWeapon(armaForte);
    Console.WriteLine(player.TotalStrength);
}