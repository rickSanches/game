using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    public enum TypeMagic { Fire, Cold, Holy, Shadow, Nature, Physical }
    public class Magic
    {
        public bool DoT { get; set; } //damage on time
        public bool HoT { get; set; } // heal on time
        public int Damage { get; set; } // 
        public List<Stats> DecreaseEffect { get; set; } // цифра на которую уменьшается stat
        public List<Stats> IncreaseEffect { get; set; } // цифра на которую увеличевается stat
        public List<TypeMagic> MagicAmplifaire { get; set; } // увеличение\уменьшение магического урона
        public string TypeOfMagic { get; set; } 
        public int Durations { get; set; } // длительность
        public bool OnTurn { get; set; } // расчет на каждом ходу
        public string Val { get; set; } // специальное значение, для расчета специфичных или комплексных бафф-дебаффов
        public string Atribute { get; set; } //атрибут на который действует дебафф
    }
    public class Ability
    {
        public int Chanse { get; set; } //////////chanseOnTarget = (Chanse - resistMagic) > Rand.next(0,100)
        public string TypeOfMagic { get; set; }
        public string Name { get; set; }
        public int CoolDown { get; set; } //обновление способности (в раундах)
        public bool endTurn { get; set; } //после выполнение абилки заканчивается ход или нет
        public bool Passive { get; set; } // активная - пассивная способность

    }

}
