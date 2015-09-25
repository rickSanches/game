/*
 ДОбавить АйдиГуид для каждого юнита
 * статы хранить в ХML
 * Создаем экземпляр класса, парсим хml, отправляем, распарвиваем, принимаем
 * добавить скелетона, как воскрешаемого юнита, андедами
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buff_Action_test
{
    public enum Stats
    {
        HP, // здоровье
        UpDmg, // Верхний урон
        LowDmg, // нижний урон  
        Armor, // броня
        Dodge, // шанс уворота
        Hit, // шанс попадания
        Will, // воля - шанс сопротивления магии контроля
        Initiative, // инициатива, влияет на очередность хода
        FireRes, // шанс сопротивления магии огня
        ColdRes, // холод
        NatureRes, // природа
        ShadowRes, // тьмы
        HolyRes, // святой магии
        CritChanse, // шанс крита
        CounterAttack // количество контратак за ход
    }
    public class Units
    {
        public double GetStat(Stats stat) // возвращаяет значение Стата
        {
            return _Stat[stat]; //принужденный возврат значения ячейки
        }
        public void GhangeStat(Stats stat, double Value) // задает-меняет значение стата
        {
            _Stat[stat] += Value; // принужденное изменение значение ячейки ( [] - способ обращения к ячейке словаря)
        }
        public double CounterAttackLeft; //осталось контратак
        public bool Sorting; // вспомогательная переменная для сортировки
        public bool Range; // мили-ренж юнит
        public bool OnAction; // вспомогательная переменная для определения порядка хода
        public bool Live; // жив или нет
        public string TypeOfAttack; // тип атаки физ или маг
        public string TypeRace; // тип расы
        public string Name; // название юнита
        public bool Deffence; // статус юнита, заканчивает ход, до конца раунда, приобредает дополнительную физ защиту
        public bool Wait; // пропускает очередь, после ходит в обратной зависимости инициативы (с низкой первыми, с высокой последними)
        private Dictionary<Stats, double> _Stat; // статы
        public List<Magic> BuffsDebuffs = new List<Magic>(); //лист баф-дебаффов которые применяются к юниту
        public List<Ability> Abil = new List<Ability>(); // лист абилок, пассивок

        private static Dictionary<Stats, double> _GetDefaultStatMap() // автозаполнение словаря нулями
        {
            var result = new Dictionary<Stats, double>();
            foreach (Stats stat in Enum.GetValues(typeof(Stats))) // пример форыча через энум
            {
                result.Add(stat, 0);
            }
            return result;
        }
        public Units() // конструктор, вызывает метод заполнения нулями словаря статов
        {
            _Stat = _GetDefaultStatMap();
        }

    }

    /// <summary>
    /// //////////////////////////////////////////////// Rase change
    /// </summary>

    public class Rase
    {
        public string rase { get; set; }
    }
    public enum Rases { Humans, Elfs, Undeads, Demons, Orcs }
    public interface IRases
    {
        Rase GetRase();
    }
    #region RaseCounstructor
    public class Human : IRases
    {
        public Rase GetRase()
        { return new Rase { rase = "Humans" }; }
    }
    public class Elf : IRases
    {
        public Rase GetRase()
        { return new Rase { rase = "Elfs" }; }
    }
    public class Undead : IRases
    {
        public Rase GetRase()
        { return new Rase { rase = "Undeads" }; }
    }
    public class Orc : IRases
    {
        public Rase GetRase()
        { return new Rase { rase = "Orcs" }; }
    }
    public class Demon : IRases
    {
        public Rase GetRase()
        { return new Rase { rase = "Demons" }; }
    }
    #endregion
    //////////////////////////////// Get Rase Factory
    class RaseFactory
    {
        IRases _rases;
        Rases _rase;
        public Rase GetRase()
        {
            ResetRase();
            return _rases.GetRase();
        }
        public void GetTypeRase(Rases rase)
        {
            _rase = rase;
        }
        public void ResetRase()
        {
            switch (_rase)
            {
                case Rases.Humans: _rases = new Human(); break;
                case Rases.Elfs: _rases = new Elf(); break;
                case Rases.Undeads: _rases = new Undead(); break;
                case Rases.Orcs: _rases = new Orc(); break;
                case Rases.Demons: _rases = new Demon(); break;
                default: break;
            }
        }

    }

    public interface ICrator
    {
        Units GetUnit();
    }
    #region TypeSoldierOfRases
    public enum ElfTypeUnit
    {
        Scout,
        Archer,
        Werewolf,
        Druid,
        Oracle,
        Kentaurus,
        Dendroid,
        FiereDragon,
        Bear,
        Wolf
    }
    public enum DeamonTypeUnit
    {
        HellDog,
        FireCaller,
        PitLord,
        FallenMage,
        HellWorm,
        SoulEater,
        Diablo,
        Efrit
    }
    public enum UndeadTypeUnit
    {
        Skeleton,
        Zombie,
        Vurdalak,
        Banshi,
        Vampire,
        Ghost,
        CorpseEater,
        Warlock,
        DeathKnit
    }
    public enum OrcTypeUnit
    {
        Gonlin,
        Ogr,
        AxeTrower,
        Shaman,
        VoodooDoctor,
        Berserk,
        Minotaurus,
        StoneGolem
    }
    public enum HumanTypeUnit
    {
        Soldier,
        Ranger,
        Knight,
        Mage,
        Priest,
        Rogue,
        Champion,
        Palladin
    }
    #endregion

    /// <summary>
    /// ///////////////////////////////////////// Factory start
    /// </summary>

    #region HumanUnit
    public class GetSoldier : ICrator
    {
        public Units GetUnit()
        {
            return new Units
            {
            };
        }
    }
    public class GetRanger : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetKnight : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetMage : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetPriest : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetRogue : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetChampion : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetPalladin : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    #endregion
    #region ElfUnit
    public class GetScout : ICrator
    {
        public Units GetUnit()
        {
            return new Units
            {
            };
        }
    }
    public class GetArcher : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetOracle : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetDruid : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetWerewolf : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetKentaurus : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetDendroid : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetFiereDragon : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    #endregion
    #region OrcUnits
    public class GetGoblin : ICrator
    {
        public Units GetUnit()
        {
            return new Units
            {
            };
        }
    }
    public class GetOgr : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetAxeTrower : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetShaman : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetVoodooDoctor : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetBerserk : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetMinotaurus : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetStoneGolem : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    #endregion
    #region UndeadUnit
    public class GetZombie : ICrator
    {
        public Units GetUnit()
        {
            return new Units
            {
            };
        }
    }
    public class GetVurdalak : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetVampire : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetBanshi : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetGhost : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetCorpseEater : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetWarlock : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetDeathKnight : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    #endregion
    #region DeamonUnit
    public class GetHellDog : ICrator
    {
        public Units GetUnit()
        {
            return new Units
            {
            };
        }
    }
    public class GetFireCaller : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetPitLord : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetFallenMage : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetHellWorm : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetSoulEater : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetDiablo : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    public class GetEfrit : ICrator
    {
        public Units GetUnit()
        {
            return new Units { };
        }
    }
    #endregion

    /// <summary>
    /// /////////////////////////////////////Test unit
    /// </summary>
    public class GetAbstractTestUnit : ICrator
    {
        public Units GetUnit()
        {
            Units u = new Units();
            u.GhangeStat(Stats.Armor, 10);
            u.Sorting = true;
            u.Range = false;
            u.OnAction = true;
            u.Name = "Unit";
            u.Deffence = false;
            u.Live = true;
            u.TypeOfAttack = "Physical";
            u.TypeRace = "Human";
            return u;
        }
    }
    public class GetAbstractTestUnit2 : ICrator
    {
        public Units GetUnit()
        {
            Units u = new Units();
            u.GhangeStat(Stats.Armor, 10);
            u.Sorting = true;
            u.Range = false;
            u.OnAction = true;
            u.Name = "Unit";
            u.Deffence = false;
            u.Live = true;
            u.TypeOfAttack = "Magic";
            u.TypeRace = "Human";
            return u;
        }
    }
    public enum Test { Test1, Test2 }
    ////////////////////////////// Unit Factory
    public class UnitFactory
    {
        Rase _rase;
        ICrator _create;
        HumanTypeUnit _human;
        OrcTypeUnit _orc;
        UndeadTypeUnit _undead;
        ElfTypeUnit _elf;
        DeamonTypeUnit _demon;
        Test _test;
        public Units GetUnit()
        {
            ResetUnit();
            return _create.GetUnit();
        }
        public void SetTypeSoldier(Test test)
        {
            //HumanTypeUnit human, OrcTypeUnit orc, UndeadTypeUnit undead, DeamonTypeUnit demon, ElfTypeUnit elf, 
            //_human = human;
            //_elf = elf;
            //_undead = undead;
            //_orc = orc;
            //_demon = demon;
            _test = test;

        }
        public void ResetUnit()
        {
            switch (_test)
            {
                case Test.Test1: _create = new GetAbstractTestUnit(); break;
                case Test.Test2: _create = new GetAbstractTestUnit2(); break;
            }
            //if (_rase.rase == "Humans")
            //{
            //    switch (_human)
            //    {
            //        case HumanTypeUnit.Soldier: _create = new GetSoldier(); break;
            //        case HumanTypeUnit.Ranger: _create = new GetRanger(); break;
            //        case HumanTypeUnit.Knight: _create = new GetKnight(); break;
            //        case HumanTypeUnit.Mage: _create = new GetMage(); break;
            //        case HumanTypeUnit.Rogue: _create = new GetRogue(); break;
            //        case HumanTypeUnit.Champion: _create = new GetChampion(); break;
            //        case HumanTypeUnit.Priest: _create = new GetPriest(); break;
            //        case HumanTypeUnit.Palladin: _create = new GetPalladin(); break;
            //        default: break;
            //    }
            //}
            //else if (_rase.rase == "Elfs")
            //{
            //    switch (_elf)
            //    {
            //        case ElfTypeUnit.Scout: _create = new GetScout(); break;
            //        case ElfTypeUnit.Archer: _create = new GetArcher(); break;
            //        case ElfTypeUnit.Druid: _create = new GetDruid(); break;
            //        case ElfTypeUnit.Oracle: _create = new GetOracle(); break;
            //        case ElfTypeUnit.Werewolf: _create = new GetWerewolf(); break;
            //        case ElfTypeUnit.Kentaurus: _create = new GetKentaurus(); break;
            //        case ElfTypeUnit.Dendroid: _create = new GetDendroid(); break;
            //        case ElfTypeUnit.FiereDragon: _create = new GetFiereDragon(); break;
            //        default: break;
            //    }
            //}
            //else if (_rase.rase == "Undeads")
            //{
            //    switch (_undead)
            //    {
            //        case UndeadTypeUnit.Zombie: _create = new GetZombie(); break;
            //        case UndeadTypeUnit.Vurdalak: _create = new GetVurdalak(); break;
            //        case UndeadTypeUnit.Vampire: _create = new GetVampire(); break;
            //        case UndeadTypeUnit.Ghost: _create = new GetGhost(); break;
            //        case UndeadTypeUnit.Warlock: _create = new GetWarlock(); break;
            //        case UndeadTypeUnit.CorpseEater: _create = new GetCorpseEater(); break;
            //        case UndeadTypeUnit.DeathKnit: _create = new GetDeathKnight(); break;
            //        case UndeadTypeUnit.Banshi: _create = new GetBanshi(); break;
            //        default: break;
            //    }
            //}
            //else if (_rase.rase == "Orcs")
            //{
            //    switch (_orc)
            //    {
            //        case OrcTypeUnit.Gonlin: _create = new GetGoblin(); break;
            //        case OrcTypeUnit.AxeTrower: _create = new GetAxeTrower(); break;
            //        case OrcTypeUnit.Berserk: _create = new GetBerserk(); break;
            //        case OrcTypeUnit.Ogr: _create = new GetOgr(); break;
            //        case OrcTypeUnit.Shaman: _create = new GetShaman(); break;
            //        case OrcTypeUnit.VoodooDoctor: _create = new GetVoodooDoctor(); break;
            //        case OrcTypeUnit.Minotaurus: _create = new GetMinotaurus(); break;
            //        case OrcTypeUnit.StoneGolem: _create = new GetStoneGolem(); break;
            //        default: break;
            //    }
            //}
            //else
            //{
            //    switch (_demon)
            //    {
            //        case DeamonTypeUnit.HellDog: _create = new GetHellDog(); break;
            //        case DeamonTypeUnit.FireCaller: _create = new GetFireCaller(); break;
            //        case DeamonTypeUnit.FallenMage: _create = new GetFallenMage(); break;
            //        case DeamonTypeUnit.HellWorm: _create = new GetHellWorm(); break;
            //        case DeamonTypeUnit.PitLord: _create = new GetPitLord(); break;
            //        case DeamonTypeUnit.SoulEater: _create = new GetSoulEater(); break;
            //        case DeamonTypeUnit.Diablo: _create = new GetDiablo(); break;
            //        case DeamonTypeUnit.Efrit: _create = new GetEfrit(); break;
            //        default: break;
            //    }
            //}
        }
    }


}
