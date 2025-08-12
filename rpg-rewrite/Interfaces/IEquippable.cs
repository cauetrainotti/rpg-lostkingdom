using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Interfaces
{
    internal interface IEquippable
    {
        bool Equip();
        bool Unequip();
    }
}
