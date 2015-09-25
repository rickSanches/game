using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    class Model
    {
        public List<Turn> TurnList { get; set; } //очередность хода
        public bool Die { get; set; } //отображает смерть комманды, необходим для проверки после каждого хода, и определения победителя
        public double Damage { get; set; } ///урон
        public double CounterDamage { get; set; } //// контр урон
        public string CurrentTeam { get; set; } // текущая команда, чей ход
        public int CurrentUnitAttak { get; set; } /// позиция юнита, чей ход
        public int UnitOnAttack { get; set; }  /// позиция юнита которого пользователь выбрал для атаки
        public int[] CanUnitsOfAttack { get; set; } //вспомогательный массив, необходим для определения всех живих целей
        public Dictionary<int, List<int>> CanAttack { get; set; }    ////возвращает пользователю конечно число возможных позиций для атаки
    }
    class Turn // вспомогательный класс, необходимый для определения порядка хода
    {
        public string team { get; set; } //имя команды, чей ход
        public string name { get; set; } //имя юнита, чей ход
    }
}
