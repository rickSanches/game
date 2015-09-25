using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    class Program
    {

        static void Main(string[] args)
        {
            Model Mod = new Model();
            Action A = new Action();
            Units u = new Units();
            Magic m = new Magic();
            double d = 12;
            Logic Log = new Logic();

            var Unit1 = A.GetTest1();
            Unit1.GhangeStat(Stats.Initiative, 10);
            Unit1.Name = "Unit1";
            var Unit2 = A.GetTest1();
            Unit2.GhangeStat(Stats.Initiative, 9);
            Unit2.Name = "Unit2";
            var Unit3 = A.GetTest1();
            Unit3.GhangeStat(Stats.Initiative, 2);
            Unit3.Name = "Unit3";
            var Unit4 = A.GetTest1();
            Unit4.GhangeStat(Stats.Initiative, 1);
            Unit4.Name = "Unit4";
            var Unit5 = A.GetTest1();
            Unit5.GhangeStat(Stats.Initiative, 3);
            Unit5.Name = "Unit5";
            var Unit6 = A.GetTest1();
            Unit6.GhangeStat(Stats.Initiative, 14);
            Unit6.Name = "Unit6";
            var Unit7 = A.GetTest1();
            Unit7.GhangeStat(Stats.Initiative, 5);
            Unit7.Name = "Unit7";
            var Unit8 = A.GetTest1();
            Unit8.GhangeStat(Stats.Initiative, 6);
            Unit8.Name = "Unit8";
            var Unit9 = A.GetTest1();
            Unit9.GhangeStat(Stats.Initiative, 7);
            Unit9.Name = "Unit9";
            var Unit10 = A.GetTest1();
            Unit10.GhangeStat(Stats.Initiative, 8);
            Unit10.Name = "Unit10";
            var Unit11 = A.GetTest1();
            Unit11.GhangeStat(Stats.Initiative, 11);
            Unit11.Name = "Unit11";
            var Unit12 = A.GetTest2();
            Unit12.GhangeStat(Stats.Initiative, 12);
            Unit12.Name = "Unit12";
            Dictionary<int, Units> Red = new Dictionary<int, Units>();
            Dictionary<int, Units> Green = new Dictionary<int, Units>();
            Red.Add(0, Unit1);
            Red.Add(1, Unit2);
            Red.Add(2, Unit3);
            Red.Add(3, Unit4);
            Red.Add(4, Unit5);
            Red.Add(5, Unit6);
            Green.Add(0, Unit7);
            Green.Add(1, Unit8);
            Green.Add(2, Unit9);
            Green.Add(3, Unit10);
            Green.Add(4, Unit11);
            Green.Add(5, Unit12);

            m.Atribute = "OnAction";
            Green[2].BuffsDebuffs.Add(m);
            Green[1].BuffsDebuffs.Add(m);
            Green[3].BuffsDebuffs.Add(m);
            Green[4].BuffsDebuffs.Add(m);
            Green[5].BuffsDebuffs.Add(m);
            Red[1].Wait = true;
            Red[2].Wait = true;
            Green[1].Wait = true;
            int i = 0;
            while (i<10)
            {
                i++;
                Log.GetCurrentUnit(Mod, Red, Green);
                if (Mod.CurrentTeam == "red")
                {
                    Red.FirstOrDefault(x => x.Key == Mod.CurrentUnitAttak).Value.OnAction = false;
                }
                else
                { Green.FirstOrDefault(x => x.Key == Mod.CurrentUnitAttak).Value.OnAction = false; }
                var olol = Mod.TurnList;
            }
            Log.GetCurrentUnit(Mod, Red, Green);
            var z = Mod.TurnList;
        }
    }
}
