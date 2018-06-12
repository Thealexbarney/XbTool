using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using XbTool.Types;

namespace XbTool
{
    public static class Enemies
    {
        public static void PrintEnemies(BdatCollection tables, StreamWriter writer)
        {
            var enemies = ReadEnemies(tables);
            var csv = new CsvWriter(writer);
            csv.WriteRecords(enemies);
        }

        public static List<Xb2Enemy> ReadEnemies(BdatCollection tables)
        {
            var enemies = new List<Xb2Enemy>();

            foreach (CHR_EnArrange enemy in tables.CHR_EnArrange.Where(x => x.Lv > 0 && x._ParamID != null))
            {
                var en = new Xb2Enemy();
                enemies.Add(en);
                en.Id = enemy.Id;
                en.Name = enemy._Name?.name;
                en.Level = enemy.Lv;
                en.LevelRange = enemy.LvRand;
                en.Genus = enemy._ParamID._ResourceID._TypeGenus?._NAME.name;
                en.Family = enemy._ParamID._ResourceID._TypeFamily?._name.name;

                CHR_EnParamTable lvParam = tables.CHR_EnParamTable[en.Level];
                en.Strength = (int)(enemy._ParamID.StrengthRev * 0.001 * lvParam.StrengthBase * ((enemy._ParamRev?.StrengthRev ?? 0) * 0.001));
                en.Ether = (int)(enemy._ParamID.PowEtherRev * 0.001 * lvParam.PowEtherBase * ((enemy._ParamRev?.PowEtherRev ?? 0) * 0.001));
                en.Dexterity = (int)(enemy._ParamID.DexRev * 0.001 * lvParam.DexBase * ((enemy._ParamRev?.DexRev ?? 0) * 0.001));
                en.Agility = (int)(enemy._ParamID.AiID * 0.001 * lvParam.AgilityBase * ((enemy._ParamRev?.AgilityRev ?? 0) * 0.001));
                en.Strength = (int)(enemy._ParamID.StrengthRev * 0.001 * lvParam.StrengthBase * ((enemy._ParamRev?.StrengthRev ?? 0) * 0.001));
                en.Luck = (int)(enemy._ParamID.LuckRev * 0.001 * lvParam.LuckBase * ((enemy._ParamRev?.LuckRev ?? 0) * 0.001));
                en.MaxHp = (int)(enemy._ParamID.HpMaxRev * 0.001 * lvParam.HpMaxBase * ((enemy._ParamRev?.HpMaxRev ?? 0) * 0.001));
                en.PhyRst = enemy._ParamID.RstPower;
                en.EtherRst = enemy._ParamID.RstEther;
                en.Element = (BladeAttribute)enemy._ParamID.Atr;

                var lv = Math.Min(130, en.Level);
                en.Exp = (int)(enemy.ExpRev * 0.01 * tables.BTL_Grow[lv].EnemyExp);
                en.Gold = (int)(enemy.GoldRev * 0.01 * tables.BTL_Grow[lv].EnemyGold);
                en.Wp = (int)(enemy.WPRev * 0.01 * tables.BTL_Grow[lv].EnemyWP);
                en.Sp = (int)(enemy.SPRev * 0.01 * tables.BTL_Grow[lv].EnemySP);
            }

            return enemies;
        }

        public class Xb2Enemy
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Family { get; set; }
            public string Genus { get; set; }
            public int Level { get; set; }
            public int LevelRange { get; set; }
            public BladeAttribute Element { get; set; }
            public int Strength { get; set; }
            public int Ether { get; set; }
            public int Dexterity { get; set; }
            public int Agility { get; set; }
            public int Luck { get; set; }
            public int MaxHp { get; set; }
            public int PhyRst { get; set; }
            public int EtherRst { get; set; }
            public int Exp { get; set; }
            public int Gold { get; set; }
            public int Wp { get; set; }
            public int Sp { get; set; }
            public string Enhance1 { get; set; }
        }
    }
}
