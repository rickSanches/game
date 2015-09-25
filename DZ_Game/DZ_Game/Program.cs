using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Console.ForegroundColor = ConsoleColor.Green;
//Console.WriteLine("Зеленый цвет текста");
//Console.ForegroundColor = ConsoleColor.DarkGray;
//Console.WriteLine("Темно серый цвет текста");
//Console.ForegroundColor = ConsoleColor.DarkYellow;
//Console.WriteLine("Темно желтый цвет текста");
//Console.ResetColor();\\Сброс цвет текста
//Console.WriteLine("Обычный цвет текста");

namespace DZ_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Random Rand = new Random();
            Round R = new Round();
            Model M = new Model();
            Teams Te = new Teams();
            Attack A = new Attack();
            CPU CPU = new CPU();

            Dictionary<int, Units> Red = new Teams().Team;
            Dictionary<int, Units> Green = new Teams().Team;
            for (int i = 1; i < 7; i++)
            {
                Console.WriteLine("Выберите бойца на позицию {0}, 1 - лучник, 2 - воин, 3 - рыцарь:", i);
                int typeFighter = Convert.ToInt32(Console.ReadLine());
                switch (typeFighter)
                {
                    case 1: Red.Add(i, Te.GetRanger()); break;
                    case 2: Red.Add(i, Te.GetSold()); break;
                    case 3: Red.Add(i, Te.GetKnight()); break;
                    default: return;
                }
            }
            /////////////////////////////////////////////////////// вынести в фабрику с установкой уровня сложности, пожже
            Green.Add(1, Te.GetRanger());
            Green.Add(2, Te.GetRanger());
            Green.Add(3, Te.GetRanger());
            Green.Add(4, Te.GetKnight());
            Green.Add(5, Te.GetKnight());
            Green.Add(6, Te.GetSold());
            /////////////////////////////////////////////////////////

            while (!M.Die)
            {
                int j = 1;

                R.ResetOnAction(Red);     ///////////////// обновляем возможность хода
                R.ResetOnAction(Green); ////////////////
                R.ResetCounterAttack(Red); //////////////// обновление контратаки
                R.ResetCounterAttack(Green); //////////////// обновление контратаки

                while (j < 13)
                {

                    switch (j)
                    {

                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 9:
                        case 11:
                            Console.Clear();
                            /////////////////////////////////////////////////////////// Vizualization ))))))))))) :D
                            Console.WriteLine("+----------------+-----------------+---+----------------+----------------+");
                            Console.Write("| 1.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 1).Value.Name.ToString());
                            Console.Write("HP {0}", Red.FirstOrDefault(x => x.Key == 1).Value.HP);
                            Console.ResetColor();
                            Console.Write(" | 6.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 6).Value.Name);
                            Console.Write("HP {0}", Red.FirstOrDefault(x => x.Key == 6).Value.HP);
                            Console.ResetColor();
                            Console.Write("|   | 6.");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}", Green.FirstOrDefault(x => x.Key == 6).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 6).Value.HP);
                            Console.ResetColor();
                            Console.Write("| 1.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}.", Green.FirstOrDefault(x => x.Key == 1).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 1).Value.HP);
                            Console.ResetColor();
                            Console.WriteLine(" |");
                            Console.WriteLine("+----------------+-----------------+---+----------------+----------------+");
                            Console.Write("| 2.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 2).Value.Name.ToString());
                            Console.Write("HP {0} ", Red.FirstOrDefault(x => x.Key == 2).Value.HP);
                            Console.ResetColor();
                            Console.Write("| 5. ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 5).Value.Name);
                            Console.Write("HP {0}", Red.FirstOrDefault(x => x.Key == 5).Value.HP);
                            Console.ResetColor();
                            Console.Write("|   | 5.");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}.", Green.FirstOrDefault(x => x.Key == 5).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 5).Value.HP);
                            Console.ResetColor();
                            Console.Write("| 2.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}.", Green.FirstOrDefault(x => x.Key == 2).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 2).Value.HP);
                            Console.ResetColor();
                            Console.WriteLine(" |");
                            Console.WriteLine("+----------------+-----------------+---+----------------+----------------+");
                            Console.Write("| 3.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 3).Value.Name.ToString());
                            Console.Write("HP {0} ", Red.FirstOrDefault(x => x.Key == 3).Value.HP);
                            Console.ResetColor();
                            Console.Write("| 4.");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0}.", Red.FirstOrDefault(x => x.Key == 4).Value.Name);
                            Console.Write("HP {0}", Red.FirstOrDefault(x => x.Key == 4).Value.HP);
                            Console.ResetColor();
                            Console.Write("|   | 4.");

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}.", Green.FirstOrDefault(x => x.Key == 4).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 4).Value.HP);
                            Console.ResetColor();
                            Console.Write("| 3.");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("{0}.", Green.FirstOrDefault(x => x.Key == 3).Value.Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("HP {0}", Green.FirstOrDefault(x => x.Key == 3).Value.HP);
                            Console.ResetColor();
                            Console.WriteLine(" |");
                            Console.WriteLine("+----------------+-----------------+---+----------------+----------------+");
                            /////////////////////////////////////////////////////////////////////////////

                            R.UnitsCanAttack(Green, M); // проверка кого можно атаковать
                            if (M.CanAttack.Sum() == 0)
                            { j = 15; break; }

                            var UnAttack = Red.FirstOrDefault(x => x.Value.onAction == true && x.Value.Live == true);
                            var DamageReciever = Green.FirstOrDefault(x => x.Key == M.PositionUnitOfAttack);
                            try
                            {
                                UnAttack.Value.DefenceStatus = false;
                                UnAttack.Value.onAction = false;
                            }
                            catch { j++; break; }

                            M.CurrentUnitAttack = UnAttack.Key;
                            Console.WriteLine("Ход бойца {0}",M.CurrentUnitAttack);
                            Console.WriteLine("Стать в защитную стойку? (Дополнительное игнорирование 10 ед. урона). d - защита. Атака - любая клавиша.");
                            string Deffense = Console.ReadKey().KeyChar.ToString();
                            Console.WriteLine("");
                            switch (Deffense)
                            {
                                case "d":
                                    UnAttack.Value.DefenceStatus = true;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Боец {0} занял оборонительную позицию.", M.CurrentUnitAttack);
                                    Console.ResetColor();
                                    break;
                                default:
                                    if (!UnAttack.Value.Range)
                                    { //mDPS unit
                                        R.CanAttackPositopn(M);
                                        R.ChangeMealeUnitAttack(M);
                                    }
                                    else { R.ChangeRangeUnitAttack(M); }
                                    A.AttackU(M, Red, Green);
                                    DamageReciever = Green.FirstOrDefault(x => x.Key == M.PositionUnitOfAttack);
                                    DamageReciever.Value.HP = DamageReciever.Value.HP - M.Damage;
                                    UnAttack.Value.HP = UnAttack.Value.HP - M.CounterDmg;
                                    if (DamageReciever.Value.HP < 0)
                                    {
                                        DamageReciever.Value.HP = 0;
                                    }
                                    if (UnAttack.Value.HP < 0)
                                    {
                                        UnAttack.Value.HP = 0;
                                    }
                                    break;
                            }

                            Console.WriteLine("Для продолжения нажмите любую клавишу.");
                            Console.ReadKey();

                            var DieFighter = Red.FirstOrDefault(x => x.Value.HP <= 0 && x.Value.Live == true);
                            try
                            {
                                DieFighter.Value.Live = false;
                            }
                            catch (Exception e) { }

                            try
                            {
                                DieFighter = Green.FirstOrDefault(x => x.Value.HP <= 0 && x.Value.Live == true);
                                DieFighter.Value.Live = false;
                            }
                            catch (Exception e) { }
                            j++;
                            break;


                        case 2:
                        case 4:
                        case 6:
                        case 8:
                        case 10:
                        case 12:
                            R.UnitsCanAttack(Red, M); // проверка кого можно атаковать
                            if (M.CanAttack.Sum() == 0)
                            { j = 15; break; }

                            UnAttack = Green.FirstOrDefault(x => x.Value.onAction == true && x.Value.Live == true);

                            try
                            {
                                UnAttack.Value.onAction = false;
                                UnAttack.Value.DefenceStatus = false;
                            }
                            catch { j++; break; }

                            M.CurrentUnitAttack = UnAttack.Key;

                            string action = CPU.CPUDeffence(M, Green);
                            switch (action)
                            {
                                case "Attack":
                                    if (!UnAttack.Value.Range)
                                    {
                                        R.CanAttackPositopn(M);
                                        CPU.ChangeMealeUnitAttack(M, Red);
                                    }
                                    else
                                    {
                                        CPU.ChangeRangeUnitAttack(M, Red);
                                    }


                                    A.AttackU(M, Green, Red);

                                    DamageReciever = Red.FirstOrDefault(x => x.Key == M.PositionUnitOfAttack);
                                    DamageReciever.Value.HP = DamageReciever.Value.HP - M.Damage;
                                    UnAttack.Value.HP = UnAttack.Value.HP - M.CounterDmg;
                                    if (DamageReciever.Value.HP < 0)
                                    {
                                        DamageReciever.Value.HP = 0;
                                    }
                                    break;
                                case "Deffence":
                                    UnAttack.Value.DefenceStatus = M.Deffence;
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Боец {0} занял оборонительную позицию.", M.CurrentUnitAttack);
                                    Console.ResetColor();
                                    break;
                                default: break;
                            }
                            if (UnAttack.Value.HP < 0)
                            {
                                UnAttack.Value.HP = 0;
                            }

                            Console.WriteLine("Для продолжения нажмите любую клавишу.");
                            Console.ReadKey();

                            DieFighter = Red.FirstOrDefault(x => x.Value.HP <= 0 && x.Value.Live == true);
                            try
                            {
                                DieFighter.Value.Live = false;
                            }
                            catch (Exception e) { }
                            DieFighter = Green.FirstOrDefault(x => x.Value.HP <= 0 && x.Value.Live == true);
                            try
                            {
                                DieFighter.Value.Live = false;
                            }
                            catch (Exception e) { }

                            j++;
                            break;
                        default:
                            break;
                    }

                }

                R.EndRound(M, Red);
                if (M.Die == true) { Console.WriteLine("Green team win"); }

                else
                {
                    R.EndRound(M, Green);
                    if (M.Die == true) { Console.WriteLine("Red team win"); }
                }

            }
            Console.ReadKey();
        }

    }
}
