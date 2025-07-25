using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Character
{
     public class Classes
    {
        public string Name { get; set; }
        public int BonusSTR { get; set; }
        public int BonusDEX { get; set; }
        public int BonusCON { get; set; } = 1;
        public int BonusINT { get; set; }
    }
}
