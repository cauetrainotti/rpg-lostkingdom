using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Items
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public static int _IdCounter = 0;
        public Item() { }
        public Item(string name, string description)
        {
            Name = name;
            Description = description;
            Id = _IdCounter;
            _IdCounter++;
        }
    }
}