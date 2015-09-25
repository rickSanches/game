using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    class Action
    {
        UnitFactory _un = new UnitFactory();
        Units u = new Units();
        public Units AbstractTestUnit2;
        public Units AbstractTestUnit;

        public Units GetTest1()
        {
            _un.SetTypeSoldier(Test.Test1);
            return _un.GetUnit();
        }
        public Units GetTest2()
        {
            _un.SetTypeSoldier(Test.Test2);
            return _un.GetUnit();
        }
    }
}
