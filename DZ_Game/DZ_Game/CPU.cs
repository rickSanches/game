using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Game
{
    class CPU
    {
        public string CPUDeffence(Model mod, Dictionary<int,Units> team)
        {
            var Health = team.Where(x => x.Key == mod.CurrentUnitAttack).FirstOrDefault();
            var CanAttack = mod.CanAttack.TakeWhile(x => x != 0).Count();
            if (Health.Value.HP < 35 && Health.Value.HP > 15 && Health.Value.Range == false && CanAttack > 3)
            {
                mod.Deffence = true;
                return "Deffence";    
            }
            else { return "Attack";  }
        }

        public void ChangeRangeUnitAttack(Model M, Dictionary<int, Units> team)
        {
            var Target = team.Where(z => z.Value.Live == true).OrderBy(x => x.Value.HP).FirstOrDefault();
            M.PositionUnitOfAttack = Target.Key;
        }

        public void ChangeMealeUnitAttack(Model M, Dictionary<int, Units> team)
        {
            int pos0 = 0;
            int pos1 = 0;
            int pos2 = 0;

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
                var Target = team.Where(z => z.Value.Live == true)
                    .Where(y => y.Key == pos0 || y.Key == pos1 || y.Key == pos2)
                    .OrderBy(x => x.Value.HP)
                    .FirstOrDefault();
                M.PositionUnitOfAttack = Target.Key;
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


                var Target = team.Where(z => z.Value.Live == true)
                    .Where(y => y.Key == pos0 || y.Key == pos1)
                    .OrderBy(x => x.Value.HP)
                    .FirstOrDefault();
                M.PositionUnitOfAttack = Target.Key;
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

                var Target = team.Where(z => z.Value.Live == true)
                    .Where(y => y.Key == pos0 || y.Key == pos1)
                    .OrderBy(x => x.Value.HP)
                    .FirstOrDefault();
                M.PositionUnitOfAttack = Target.Key;
            }
        }
    }
}
