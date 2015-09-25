using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Game
{
    class Model
    {
        public int PositionUnitOfAttack { get; set; } // позиция юнита, которого атакуют
        public int CurrentUnitAttack { get; set; } // позиция юнита, который атакует
        public int[] CanAttack = new int[6];
        public int CounterDmg { get; set; }
        public int Damage { get; set; }
        public int Position { get; set; }
        public bool Deffence = true; // 
        public bool Die = false;
    }
    class Buffs
    {
        public string Buff { get; set; }
        public int Duration { get; set; }
        public int Debuff { get; set; }
    }
}
