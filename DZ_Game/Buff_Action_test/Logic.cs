using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    class Logic
    {
        public void FindPosition(Model mod, Dictionary<int, Units> red, Dictionary<int, Units> green) // метод возврата пользователю конечного результата доступности юнитов для атаки
        {
            CanUnitsOFAttack(mod, green);
        }
        private void CanUnitsOFAttack(Model mod, Dictionary<int, Units> team) //отбираем всех живых на поле
        {
            int i = 0;
            foreach (var item in team)
            {
                if (item.Value.Live == true)
                {
                    mod.CanUnitsOfAttack[i] = item.Key;
                    i++;
                }
            }
        }
        #region RoundLogic
        private void ResetSorting(Dictionary<int, Units> team) // сброс сортировки
        {
            foreach (int i in team.Keys)
            {
                team[i].Sorting = true;
            }
        }
        public void GetCurrentUnit(Model mod, Dictionary<int, Units> red, Dictionary<int, Units> green) // получение юнита, который должен походить, сейчас
        {
            RoundTurn(mod, red, green);
            mod.CurrentTeam = mod.TurnList.FirstOrDefault().team;
            var NameUnit = mod.TurnList.FirstOrDefault().name;
            if (mod.CurrentTeam == "Red")
            {
                var xxx = red.FirstOrDefault(x => x.Value.Name == NameUnit && x.Value.Live == true && x.Value.OnAction == true);
                mod.CurrentUnitAttak = xxx.Key;
            }
            else { mod.CurrentUnitAttak = green.Where(x => x.Value.Name == NameUnit && x.Value.Live == true && x.Value.OnAction == true).FirstOrDefault().Key; }
        }
        private void RoundTurn(Model mod, Dictionary<int, Units> red, Dictionary<int, Units> green) // создание списка очереди ходов
        {
            Dictionary<int, Units> reds = new Dictionary<int, Units>();
            Dictionary<int, Units> greens = new Dictionary<int, Units>();
            reds = ExecuteTurnDebuff(red);
            greens = ExecuteTurnDebuff(green);
            mod.TurnList = new List<Turn>();
            var redTurn = reds.Values.Where(x => x.Live == true && x.OnAction == true).OrderByDescending(z => z.GetStat(Stats.Initiative)).ToList();
            var greenTurn = greens.Values.Where(x => x.Live == true && x.OnAction == true).OrderByDescending(z => z.GetStat(Stats.Initiative)).ToList();
            if (redTurn.Count() == 0)
            {
                foreach (var item in greenTurn)
                {
                    Turn t = new Turn();
                    t.name = item.Name;
                    t.team = "Green";
                    mod.TurnList.Add(t);
                }
            }
            else if (greenTurn.Count() == 0)
            {
                foreach (var item in redTurn)
                {
                    Turn t = new Turn();
                    t.name = item.Name;
                    t.team = "Red";
                    mod.TurnList.Add(t);
                }
            }
            else if (redTurn.Count() == 0 && greenTurn.Count() == 0)
            {
                WaitSortTurn(mod, red, green);
            }
            else
                while ((redTurn.Last().Sorting == true) || (greenTurn.Last().Sorting == true))
                {
                    Turn t = new Turn();
                    if ((redTurn.Count(x => x.Sorting == true)) != 0 && (greenTurn.Count(x => x.Sorting == true)) != 0)
                    {
                        if (redTurn.FirstOrDefault(x => x.Sorting == true).GetStat(Stats.Initiative) >= greenTurn.FirstOrDefault(x => x.Sorting == true).GetStat(Stats.Initiative))
                        {
                            t.team = "Red";
                            t.name = redTurn.FirstOrDefault(x => x.Sorting == true).Name;
                            redTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                        }
                        else
                        {
                            t.team = "Green";
                            t.name = greenTurn.FirstOrDefault(x => x.Sorting == true).Name;
                            greenTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                        }
                    }
                    else if ((redTurn.Count(x => x.Sorting == true)) != 0)
                    {
                        t.team = "Red";
                        t.name = redTurn.FirstOrDefault(x => x.Sorting == true).Name;
                        redTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                    }
                    else
                    {
                        t.team = "Green";
                        t.name = greenTurn.FirstOrDefault(x => x.Sorting == true).Name;
                        greenTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                    }
                    mod.TurnList.Add(t);
                }
            ResetSorting(red);
            ResetSorting(green);
        }
        private void WaitSortTurn(Model mod, Dictionary<int, Units> reds, Dictionary<int, Units> greens) // обработка ходов после ожидания
        {
            mod.TurnList = new List<Turn>();
            var redTurn = reds.Values.Where(x => x.Live == true && x.OnAction == false && x.Wait == true)
                .OrderBy(z => z.GetStat(Stats.Initiative)).ToList();
            var greenTurn = greens.Values.Where(x => x.Live == true && x.OnAction == false && x.Wait == true)
                .OrderBy(z => z.GetStat(Stats.Initiative)).ToList();
            if (redTurn.Count() == 0)
            {
                foreach (var item in greenTurn)
                {
                    Turn t = new Turn();
                    t.name = item.Name;
                    t.team = "Green";
                    mod.TurnList.Add(t);
                }
            }
            else if (greenTurn.Count() == 0)
            {
                foreach (var item in redTurn)
                {
                    Turn t = new Turn();
                    t.name = item.Name;
                    t.team = "Red";
                    mod.TurnList.Add(t);
                }
            }
            else if (redTurn.Count() == 0 && greenTurn.Count() == 0)
            {

            }
            else
                while ((redTurn.Last().Sorting == true) || (greenTurn.Last().Sorting == true))
                {
                    Turn t = new Turn();
                    if ((redTurn.Count(x => x.Sorting == true)) != 0 && (greenTurn.Count(x => x.Sorting == true)) != 0)
                    {
                        if (redTurn.FirstOrDefault(x => x.Sorting == true).GetStat(Stats.Initiative) >= greenTurn.FirstOrDefault(x => x.Sorting == true).GetStat(Stats.Initiative))
                        {
                            t.team = "Red";
                            t.name = redTurn.FirstOrDefault(x => x.Sorting == true).Name;
                            redTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                        }
                        else
                        {
                            t.team = "Green";
                            t.name = greenTurn.FirstOrDefault(x => x.Sorting == true).Name;
                            greenTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                        }
                    }
                    else if ((redTurn.Count(x => x.Sorting == true)) != 0)
                    {
                        t.team = "Red";
                        t.name = redTurn.FirstOrDefault(x => x.Sorting == true).Name;
                        redTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                    }
                    else
                    {
                        t.team = "Green";
                        t.name = greenTurn.FirstOrDefault(x => x.Sorting == true).Name;
                        greenTurn.FirstOrDefault(x => x.Sorting == true).Sorting = false;
                    }
                    mod.TurnList.Add(t);
                }
            ResetSorting(reds);
            ResetSorting(greens);
        }
        private Dictionary<int, Units> ExecuteTurnDebuff(Dictionary<int, Units> team) // обработка дебаффов, которые сбрасывают возможноть хода (станы, контроли ...)
        {
            Dictionary<int, Units> resualt = new Dictionary<int, Units>();
            foreach (var item in team)
            {
                var helper = item.Value.BuffsDebuffs.FirstOrDefault(z => z.Atribute == "OnAction");
                if (helper == null)
                {
                    resualt.Add(item.Key, item.Value);
                }
            }
            return resualt;
        }
        public void ResetOnAction(Dictionary<int, Units> team) // сброс возможности ходить бойцам, для нового раунда
        {
            foreach (int i in team.Keys)
            {
                team[i].OnAction = true;
            }
        }

        public void EndRound(Model mod, Dictionary<int, Units> team) // по окончанию раунда проверка на количество убитых, и победу команды
        {
            int j = 0;
            foreach (int i in team.Keys)
            {
                if (!team[i].Live)
                { j++; }
            }
            if (j == 6) { mod.Die = true; }

        }
        public void ResetCounterAttack(Dictionary<int, Units> team) // обнуление возможности контратаки
        {
            foreach (var i in team.Keys)
            {
                double value = team.FirstOrDefault(x => x.Key == i).Value.GetStat(Stats.CounterAttack);
                team[i].CounterAttackLeft = value;
            }
        }
        #endregion
        #region MealePhysicalLogic
        private void AttackPosition(List<int> List, Model mod) // второй этам определения доступных позиций для юнитов ближнего боя
        {
            var list = new List<int>();
            foreach (var item in List) // перебор листа с несколькими юнитами в ряду, возврат их доступности для атаки
            {
                switch (item)
                {
                    case 0:
                    case 5:
                        list = new List<int> { 5, 4, 1, 0 };
                        mod.CanAttack.Add(item, list);//кей в словаре - позиция атакуемого юнита, лист - кто его может атаковать
                        break;
                    case 1:
                    case 4:
                        list = new List<int> { 5, 4, 3, 2, 1, 0 };
                        mod.CanAttack.Add(item, list);//кей в словаре - позиция атакуемого юнита, лист - кто его может атаковать
                        break;
                    case 2:
                    case 3:
                        list = new List<int> { 1, 4, 3, 2 };
                        mod.CanAttack.Add(item, list);//кей в словаре - позиция атакуемого юнита, лист - кто его может атаковать
                        break;
                    default: break;
                }
            }
        }
        private void MealeCanAttack(Model mod) // первая часть определения доступных для аттаки позиций, для юнитов ближнего боя
        {
            var list = new List<int>();
            var mealepositions = mod.CanUnitsOfAttack.Where(x => x > 2).ToList(); //находим все живие позиции первого ряда, создание листа юнитов первого ряда
            if (mealepositions.Count() != 0) //есди есть хоть один из первого ряда
            {
                if (mealepositions.Count() == 1) // один юнит в ряду, его может атаковать каждый
                {
                    list = new List<int> { 5, 4, 3, 2, 1, 0 };
                    mod.CanAttack.Add(mealepositions.FirstOrDefault(), list); //кей в словаре - позиция атакуемого юнита, лист - кто его может атаковать
                }
                else
                {
                    AttackPosition(mealepositions, mod); //вызов метода отбора с большим количеством доступных для атаки юнитов в ряду
                }
            }
            else
            {
                mealepositions = mod.CanUnitsOfAttack.Where(x => x < 3).ToList(); // создание листа юнитов второго ряда
                if (mealepositions.Count() == 1) // один юнит в ряду
                {
                    list = new List<int> { 5, 4, 3, 2, 1, 0 };
                    mod.CanAttack.Add(mealepositions.FirstOrDefault(), list);//кей в словаре - позиция атакуемого юнита, лист - кто его может атаковать
                }
                else
                {
                    AttackPosition(mealepositions, mod);//вызов метода отбора с большим количеством доступных для атаки юнитов в ряду
                }
            }
        }
        #endregion
        #region MagicLogic
        public void ResetAbbility(Dictionary<int, Units> team) ///сброс таймера абилок в начале каждого раунда
        {

        }
        private void BuffDecrieser(Dictionary<int, Units> team) // cброс бафф - дебафф с юнита, в начале хода юнита
        {

        }
        public void BuffActivations(Model mod) // выполнение баф-дебаф сценария на юните, во время его хода
        {
            //DebuffActivation

            //BuffActivation

        }
        #endregion
    }
}
