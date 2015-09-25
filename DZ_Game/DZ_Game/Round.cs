using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Game
{
    class Teams
    {

        UnitFactory _un = new UnitFactory();

        public Units GetSold()
        {
            _un.SetTypeSoldier(TypeSoldier.Soldier);
            return _un.GetUnit();
        }
        public Units GetRanger()
        {
            _un.SetTypeSoldier(TypeSoldier.Ranger);
            return _un.GetUnit();
        }
        public Units GetKnight()
        {
            _un.SetTypeSoldier(TypeSoldier.Knight);
            return _un.GetUnit();
        }

        public Units Soldier;
        public Units Ranger;
        public Units Knight;

        public Dictionary<int, Units> Team = new Dictionary<int, Units>();

    }

    class Round
    {
        public void ResetAbbility(Dictionary<int,Units> team) ///сброс таймера абилок в начале каждого раунда
        {
            foreach (int i in team.Keys)
            {
                if (team[i].AbilityCD < 1)
                {
                    team[i].AbilityCD ++;
                }
                
            }
        }
        public void BuffDecrieser(Dictionary<int,Units> team)
        { 
        
        }
        public void BuffActivations(Model mod)
        { 
            //DebuffActivation

            //BuffActivation
        
        }
        public void ResetOnAction(Dictionary<int, Units> team) // сброс возможности ходить бойцам, для нового раунда
        {
            foreach (int i in team.Keys)
            {
                team[i].onAction = true;
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

            foreach (int i in team.Keys)
            {
                if (team[i].Name == "Soldier")
                {
                    team[i].CounterAttack = 1;
                }
                else if (team[i].Name == "Knight")
                {
                    team[i].CounterAttack = 2;
                }

            }
        }

        public void UnitsCanAttack(Dictionary<int, Units> team, Model mod) // проверка юнитов, которых можно атаковать, по критерию(жив - мертв)
        {
            for (int m = 0; m < 6; m++)
            {
                mod.CanAttack[m] = 0;
            }
            int j = 0;
            foreach (int i in team.Keys)
            {
                if (team[i].Live == true)
                {
                    mod.CanAttack[j] = i;
                    j++;
                }
            }
        }

        public void CanAttackPositopn(Model M)
        {
            if (!M.CanAttack.Contains(4) && !M.CanAttack.Contains(5) && !M.CanAttack.Contains(6)) // нет переднего ряда
            {
                if (M.CanAttack.Contains(1) && M.CanAttack.Contains(2) && M.CanAttack.Contains(3))
                {
                    M.CanAttack[3] = 23;
                    M.CanAttack[5] = 12;
                    M.CanAttack[4] = 123;
                }
                else if (!M.CanAttack.Contains(1) && M.CanAttack.Contains(2) && M.CanAttack.Contains(3))
                {
                    M.CanAttack[3] = 23;
                    M.CanAttack[5] = 2;
                    M.CanAttack[4] = 23;
                }
                else if (!M.CanAttack.Contains(3) && M.CanAttack.Contains(1) && M.CanAttack.Contains(2))
                {
                    M.CanAttack[3] = 2;
                    M.CanAttack[5] = 12;
                    M.CanAttack[4] = 12;
                }
                else if (!M.CanAttack.Contains(2) && M.CanAttack.Contains(1) && M.CanAttack.Contains(3))
                {
                    M.CanAttack[3] = 13;
                    M.CanAttack[5] = 13;
                    M.CanAttack[4] = 13;
                }
                else
                {
                    var LastOfLine = M.CanAttack.FirstOrDefault(x => x > 0);
                    M.CanAttack[3] = LastOfLine;
                    M.CanAttack[5] = LastOfLine;
                    M.CanAttack[4] = LastOfLine;
                }
            }
            else
            {
                if (M.CanAttack.Contains(4) && M.CanAttack.Contains(5) && M.CanAttack.Contains(6))
                {
                    M.CanAttack[3] = 45;
                    M.CanAttack[5] = 56;
                    M.CanAttack[4] = 456;
                }
                else if (!M.CanAttack.Contains(4) && M.CanAttack.Contains(6) && M.CanAttack.Contains(5))
                {
                    M.CanAttack[3] = 5;
                    M.CanAttack[5] = 56;
                    M.CanAttack[4] = 56;

                }
                else if (!M.CanAttack.Contains(5) && M.CanAttack.Contains(6) && M.CanAttack.Contains(4))
                {
                    M.CanAttack[3] = 4;
                    M.CanAttack[5] = 6;
                    M.CanAttack[4] = 46;
                }
                else if (!M.CanAttack.Contains(6) && M.CanAttack.Contains(4) && M.CanAttack.Contains(5))
                {
                    M.CanAttack[3] = 45;
                    M.CanAttack[5] = 5;
                    M.CanAttack[4] = 45;
                }
                else
                {
                    var LastOfLine = M.CanAttack.FirstOrDefault(x => x > 3);
                    M.CanAttack[3] = LastOfLine;
                    M.CanAttack[5] = LastOfLine;
                    M.CanAttack[4] = LastOfLine;
                }
            }
        }

        public void ChangeRangeUnitAttack(Model M)
        {

            while (true)
            {
                int[] array = { 0 };
                int position = 0;
                Console.WriteLine("Ход воина на позиции {0}", M.CurrentUnitAttack);
                Console.WriteLine("Вы можете атаковать вражеские позиции {0}. Выберите цель для атаки:", string.Join(", ", M.CanAttack.Except<int>(array)));
                try
                {
                    position = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e) { }
                if (M.CanAttack.Any(x => x == position))
                {
                    M.PositionUnitOfAttack = position;
                    return;
                }
            }
        }

        public void ChangeMealeUnitAttack(Model M)
        {
            Console.WriteLine("Ход воина на позиции {0}", M.CurrentUnitAttack);
            int position = 0;
            int pos0 = 0;
            int pos1 = 0;
            int pos2 = 0;
            string VariantAtatck = "";
            if (M.CurrentUnitAttack == 5)
            {
                string tostr = M.CanAttack[4].ToString();
                char[] pos = tostr.ToCharArray();
                try
                {
                    int.TryParse(pos[0].ToString(), out pos0);
                    int.TryParse(pos[1].ToString(), out pos1);
                    int.TryParse(pos[2].ToString(), out pos2);
                }
                catch (Exception e) { }

                if (pos1 == 0 && pos2 == 0)
                {
                    VariantAtatck = "Вы можете атаковать вражеские позиции {0}. Выберите цель для атаки:";
                }
                else if (pos2 == 0)
                {
                    VariantAtatck = "Вы можете атаковать вражеские позиции {0}, {1}. Выберите цель для атаки:";
                }
                else VariantAtatck = "Вы можете атаковать вражеские позиции {0}, {1}, {2}. Выберите цель для атаки:";

                while (pos0 > 0)
                {
                    Console.WriteLine(VariantAtatck, pos0, pos1, pos2);
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e) { }
                    if (position != null && position != 0)
                    {
                        if (position == Convert.ToInt32(pos0) || position == Convert.ToInt32(pos2) || position == Convert.ToInt32(pos1))
                        {
                            M.PositionUnitOfAttack = position;
                            pos0 = -100;
                        }
                    }
                }


            }
            else if (M.CurrentUnitAttack == 4)
            {
                string tostr = M.CanAttack[3].ToString();
                char[] pos = tostr.ToCharArray();
                try
                {
                    int.TryParse(pos[0].ToString(), out pos0);
                    int.TryParse(pos[1].ToString(), out pos1);

                }
                catch (Exception e) { }

                if (pos1 == 0)
                {
                    VariantAtatck = "Вы можете атаковать вражеские позиции {0}. Выберите цель для атаки:";
                }
                else VariantAtatck = "Вы можете атаковать вражеские позиции {0}, {1}. Выберите цель для атаки:";

                while (pos0 > 0)
                {
                    Console.WriteLine(VariantAtatck, pos0, pos1);
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e) { }
                    if (position != null && position != 0)
                    {
                        if (position == Convert.ToInt32(pos0) || position == Convert.ToInt32(pos1))
                        {
                            M.PositionUnitOfAttack = position;
                            pos0 = -100;
                        }
                    }
                }
            }
            else
            {
                string tostr = M.CanAttack[5].ToString();
                char[] pos = tostr.ToCharArray();
                try
                {
                    int.TryParse(pos[0].ToString(), out pos0);
                    int.TryParse(pos[1].ToString(), out pos1);
                }
                catch (Exception e) { }

                if (pos1 == 0)
                {
                    VariantAtatck = "Вы можете атаковать вражеские позиции {0}. Выберите цель для атаки:";
                }
                else VariantAtatck = "Вы можете атаковать вражеские позиции {0}, {1}. Выберите цель для атаки:";

                while (pos0 > 0)
                {
                    Console.WriteLine(VariantAtatck, pos0, pos1);
                    try
                    {
                        position = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e) { }
                    if (position != null && position != 0)
                    {
                        if (position == Convert.ToInt32(pos0) || position == Convert.ToInt32(pos1))
                        {
                            M.PositionUnitOfAttack = position;
                            pos0 = -100;
                        }
                    }
                }
            }
        }

        

       

    }


    class Attack // класс атаки
    {
        Random Rand = new Random();
        public void AttackU(Model mod, Dictionary<int, Units> Attack, Dictionary<int, Units> Def)
        {
            mod.CounterDmg = 0;
            ///////////////////////////////////////////////////////////////////// исходящий урон
            var AttackUnit = Attack.FirstOrDefault(x => x.Key == mod.CurrentUnitAttack);
            var DefUnit = Def.FirstOrDefault(x => x.Key == mod.PositionUnitOfAttack);
            string Crit = "";
            var Damage = Rand.Next(AttackUnit.Value.LowDmg, AttackUnit.Value.UpDmg);
            if (Rand.Next(1, 100) <= AttackUnit.Value.Crit)
            {
                mod.Damage = Damage * 2;
                Crit = "КРИТИЧЕСКИЙ";
            }
            else { mod.Damage = Damage; }

            /////////////////////////////////////////////////////////////////
            if (DefUnit.Value.Dodge > Rand.Next(1, 100))
            {
                Console.WriteLine("Боец {0} увернулся от атаки {1}.", mod.PositionUnitOfAttack, mod.CurrentUnitAttack);
                mod.Damage = 0;
            }
            else
            {
                if (Crit != "")
                {
                    mod.Damage = mod.Damage;
                }
                else
                {
                    if (DefUnit.Value.DefenceStatus == true)
                    {
                        mod.Damage = mod.Damage - 10 - (mod.Damage * DefUnit.Value.Armor) / 100;
                    }
                    else
                    { 
                    mod.Damage = mod.Damage - (mod.Damage * DefUnit.Value.Armor)/100;}
                }
                Console.Write("Боец {0} нанес",mod.CurrentUnitAttack);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" {0} ", Crit);
                Console.ResetColor();
                Console.WriteLine("урон в {0} единиц бойцу {1}.", mod.Damage, mod.PositionUnitOfAttack);
            }
            if (AttackUnit.Value.Range == false && DefUnit.Value.CounterAttack > 0) // расчет возможности ответного удара
            {
                mod.CounterDmg = DefUnit.Value.LowDmg - (DefUnit.Value.LowDmg * AttackUnit.Value.Armor) / 100;
                DefUnit.Value.CounterAttack--;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Боец {0} КОНТРАТАКОВАЛ и нанес {1} урона бойцу {2}", mod.PositionUnitOfAttack, mod.CounterDmg, mod.CurrentUnitAttack);
                Console.ResetColor();
            }

        }
    }
}
