using System;

namespace rpg_rewrite.Models
{
    public enum PotionType
    {
        Health = 0,
        Mana = 1,
        Purpur = 2
    }

    public class Potion : Item.Item
    {
        public PotionType Type { get; set; }
        public int HealthRegen { get; set; }
        public int ManaRegen { get; set; }

        public Potion(PotionType type)
        {
            SetAttributes(type);
            Name = SetName(type);
            Description = SetDescription(type);
            Type = type;
        }

        public void SetAttributes(PotionType type)
        {
            switch (type)
            {
                case PotionType.Health:
                    HealthRegen = AttributeRandomizer();
                    break;
                case PotionType.Mana:
                    ManaRegen = AttributeRandomizer();
                    break;
                case PotionType.Purpur:
                    ManaRegen = AttributeRandomizer();
                    HealthRegen = AttributeRandomizer();
                    break;
            }
        }
        public int AttributeRandomizer()
        {
            Random random = new Random();
            return random.Next(20, 100);
        }

        public string SetName(PotionType type)
        {
            string potionSize = SizeCalculator(type);
            string potionType = type == PotionType.Health ? "Health Potion" : type == PotionType.Mana ? "Mana Potion" : "Purpur Potion";
            return $"{potionSize} {potionType}";
        }
        public string SizeCalculator(PotionType type)
        {
            int purpurRegen = ManaRegen + HealthRegen / 2;
            int valor = type == PotionType.Health ? HealthRegen : type == PotionType.Mana ? ManaRegen : purpurRegen;
            return valor switch
            {
                <= 25 => "Small",
                <= 50 => "Medium",
                _ => "Big"
            };
        }

        public string SetDescription(PotionType type)
        {
            int purpurRegen = ManaRegen + HealthRegen / 2;
            int potionRegen = type == PotionType.Health ? HealthRegen : type == PotionType.Mana ? ManaRegen : purpurRegen;

            if (type == PotionType.Purpur)
            {
                return $"Restores {HealthRegen} health and {ManaRegen} mana points.";
            }
            else
            {
                return $"Restores {potionRegen} {type.ToString().ToLower()} points.";
            }
        }
    }
}
