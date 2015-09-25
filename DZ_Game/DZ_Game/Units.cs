using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Game
{
    class Units
    {
        public string Name;
        public bool Live = true;
        public int HP;
        public bool DefenceStatus = false;
        public int Armor;
        public int UpDmg;
        public int LowDmg;
        public bool Range;
        public int Initiate;
        public int CounterAttack;
        public int Crit;
        public int Dodge;
        public bool onAction;
        public int AbilityCD;
    }

    interface ICreateUnit
    {
        Units GetUnit();
    }
    enum TypeSoldier
    {
        Soldier,
        Ranger,
        Knight
    }
    class GetSoldier : ICreateUnit
    {
        public Units GetUnit()
        {
            return new Units
            {
                Name = "Soldier",
                Live = true,
                onAction = true,
                DefenceStatus = false,
                Armor = 13,
                UpDmg = 20,
                LowDmg = 13,
                Range = false,
                HP = 115,
                Initiate = 5,
                CounterAttack = 1,
                Dodge = 15,
                Crit = 15
            };
        }
    }
    class GetRanger : ICreateUnit
    {
        public Units GetUnit()
        {
            return new Units
            {
                Name = "Ranger",
                Live = true,
                onAction = true,
                DefenceStatus = false,
                Armor = 1,
                UpDmg = 35,
                LowDmg = 25,
                Range = true,
                HP = 95,
                Initiate = 7,
                CounterAttack = 0,
                Dodge = 25,
                Crit = 20
            };
        }
    }
    class GetKnight : ICreateUnit
    {
        public Units GetUnit()
        {
            return new Units
            {
                Name = "Knight",
                Live = true,
                onAction = true,
                DefenceStatus = false,
                Armor = 20,
                UpDmg = 28,
                LowDmg = 20,
                Range = false,
                HP = 145,
                Initiate = 3,
                CounterAttack = 2,
                Dodge = 10,
                Crit = 10
            };
        }
    }

    class UnitFactory
    {
        ICreateUnit _create;
        TypeSoldier _type;

        public Units GetUnit()
        {
            ResetUnits();
            return _create.GetUnit();
        }
        public void SetTypeSoldier(TypeSoldier type)
        {
            _type = type;
        }
        public void ResetUnits()
        {
            switch (_type)
            {
                case TypeSoldier.Soldier: _create = new GetSoldier(); break;
                case TypeSoldier.Ranger: _create = new GetRanger(); break;
                case TypeSoldier.Knight: _create = new GetKnight(); break;
                default: break;
            }
        }
    }

}
