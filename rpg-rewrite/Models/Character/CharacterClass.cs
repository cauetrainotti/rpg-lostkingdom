using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_rewrite.Models.Character
{
    public enum ClassType
    {
        Warrior = 1,
        Mage = 2,
        Tank = 3,
        Assassin = 4,
        Archer = 5
    }
    public class Class
    {
        public ClassType Type { get; set; }
        public int BonusSTR { get; set; }
        public int BonusDEX { get; set; }
        public int BonusCON { get; set; }
        public int BonusINT { get; set; }

        public Class(ClassType classType)
        {
            switch (classType)
            {
                case ClassType.Warrior:
                    BonusSTR = 5;
                    BonusDEX = 5;
                    BonusCON = 5;
                    BonusINT = 0;
                    break;
                case ClassType.Mage:
                    BonusSTR = 0;
                    BonusDEX = 0;
                    BonusCON = 0;
                    BonusINT = 15;
                    break;
                case ClassType.Tank:
                    BonusSTR = 5;
                    BonusDEX = 0;
                    BonusCON = 10;
                    BonusINT = 0;
                    break;
                case ClassType.Assassin:
                    BonusSTR = 5;
                    BonusDEX = 10;
                    BonusCON = 0;
                    BonusINT = 0;
                    break;
                case ClassType.Archer:
                    BonusDEX = 15;
                    break;
            }
        }
    }
}