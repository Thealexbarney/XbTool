using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using XbTool.BdatString;
using XbTool.CodeGen;

namespace XbTool.Xb1De.Drops
{
    public static class DropTableGen
    {
        private const int MaxLotItems = 10;

        public static void GenerateDropTables(BdatStringCollection bdats, string outputFile)
        {
            var enemies = ReadBdatTables(bdats);
            CalculateDropRates(enemies);

            string html = PrintDropTables(enemies);
            File.WriteAllText(outputFile, html, Encoding.UTF8);
        }

        private static List<Enemy> ReadBdatTables(BdatStringCollection bdats)
        {
            BdatStringTable enemyTable = bdats.Tables["BTL_enelist"];

            var enemies = new List<Enemy>();

            foreach (BdatStringItem item in enemyTable.Items)
            {
                Enemy enemy = TryGetEnemy(item);

                if (enemy != null)
                {
                    enemies.Add(enemy);
                }
            }

            return enemies;
        }

        private static void CalculateDropRates(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.SuperRareDropRate = enemy.SuperRareRate * 0.01;
                double noSuperRareProb = 1 - enemy.SuperRareDropRate;

                enemy.RareDropRate = (enemy.RareRate * 0.01) * noSuperRareProb;
                double noRareProb = 1 - (enemy.RareRate * 0.01);

                enemy.NormalDropRate = (enemy.NormalRate * 0.01) * noSuperRareProb * noRareProb;

                CalculateNormalDropRates(enemy.NormalDrops, enemy.IsUm);
                CalculateRareDropRates(enemy.RareDrops);
                CalculateSuperRareDropRates(enemy.SuperRareDrops);
            }
        }

        private static string PrintDropTables(List<Enemy> enemies)
        {
            var sb = new Indenter(2);
            sb.AppendLine("<!DOCTYPE html>");
            sb.AppendLineAndIncrease("<html>");
            sb.AppendLineAndIncrease("<head>");
            sb.AppendLine("<meta charset=\"utf-8\" />");
            sb.AppendLine($"<title>Xenoblade 1 Enemy Drop Tables</title>");
            sb.DecreaseAndAppendLine("</head>");

            sb.AppendLineAndIncrease("<body>");

            foreach (var enemy in enemies)
            {
                PrintEnemy(enemy, sb);
            }

            sb.DecreaseAndAppendLine("</body>");
            sb.DecreaseAndAppendLine("</html>");

            return sb.ToString();
        }

        private static void PrintEnemy(Enemy enemy, Indenter sb)
        {
            sb.AppendLine($"<h2>{enemy.Name} (#{enemy.Id})</h2>");

            sb.AppendLineAndIncrease("<table>");
            sb.AppendLine($"<tr><td>Normal</td><td>{enemy.NormalDropRate:P2}</td>");
            sb.AppendLine($"<tr><td>Rare</td><td>{enemy.RareDropRate:P2}</td>");
            sb.AppendLine($"<tr><td>Super Rare</td><td>{enemy.SuperRareDropRate:P2}</td>");
            sb.DecreaseAndAppendLine("</table>");

            if (enemy.HasNormalDrops())
            {
                sb.AppendLine("<h3>Normal:</h3>");
                sb.AppendLine("<h4>Materials (From normal chest)</h4>");
                sb.AppendLineAndIncrease("<table>");

                foreach (var item in enemy.NormalDrops.MaterialsDouble.OrderDrops())
                {
                    sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                }

                sb.DecreaseAndAppendLine("</table>");

                sb.AppendLine("<h4>Materials (From other chests)</h4>");
                sb.AppendLineAndIncrease("<table>");

                foreach (var item in enemy.NormalDrops.MaterialsSingle.OrderDrops())
                {
                    sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                }

                sb.DecreaseAndAppendLine("</table>");
            }

            if (enemy.HasRareDrops())
            {
                sb.AppendLine("<h3>Rare:</h3>");

                if (enemy.RareDrops.Crystals.Any(x => x.TotalDropRate != 0))
                {
                    if (enemy.RareDrops.Crystals.Any(x => x.Item.IsCylinder))
                    {
                        sb.AppendLine("<h4>Cylinders</h4>");
                    }
                    else
                    {
                        sb.AppendLine("<h4>Crystals</h4>");
                    }

                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.RareDrops.Crystals.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.GetDisplayString()}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.RareDrops.Weapons.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Weapons</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.RareDrops.Weapons.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{GetSlotsString(item.SlotCount)}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.RareDrops.Armor.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Armor</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.RareDrops.Armor.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{GetSlotsString(item.SlotCount)}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.RareDrops.ArtBooks.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Art Books</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.RareDrops.ArtBooks.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }
            }

            if (enemy.HasSuperRareDrops())
            {
                sb.AppendLine("<h3>Super Rare:</h3>");

                if (enemy.SuperRareDrops.Weapons.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Weapons</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.SuperRareDrops.Weapons.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{GetSlotsString(item.SlotCount)}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.SuperRareDrops.UniqueWeapons.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Unique Weapons</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.SuperRareDrops.UniqueWeapons.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.SuperRareDrops.UniqueArmor.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Unique Armor</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.SuperRareDrops.UniqueArmor.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }

                if (enemy.SuperRareDrops.ArtBooks.Any(x => x.TotalDropRate != 0))
                {
                    sb.AppendLine("<h4>Art Books</h4>");
                    sb.AppendLineAndIncrease("<table>");

                    foreach (var item in enemy.SuperRareDrops.ArtBooks.OrderDrops())
                    {
                        sb.AppendLine($"<tr><td>{item.Item.Name}</td><td>{item.TotalDropRate:P2}</td>");
                    }

                    sb.DecreaseAndAppendLine("</table>");
                }
            }
        }

        private static IEnumerable<DropEntry<T>> OrderDrops<T>(this IEnumerable<DropEntry<T>> entries) where T : new()
        {
            return entries.Where(x => x.TotalDropRate > 0).OrderByDescending(x => x.TotalDropRate);
        }

        private static string GetSlotsString(int count)
        {
            if (count == 1)
                return "1 slot";

            return $"{count} slots";
        }

        private static void CalculateNormalDropRates(DropNormalEntry entry, bool isUm)
        {
            List<DropEntry<MaterialEntry>> materialsSingle = entry.MaterialsSingle;
            List<DropEntry<MaterialEntry>> materialsDouble = entry.MaterialsDouble;

            double rate0 = (double)materialsSingle[0].Rate / 100;
            double rate1 = (double)materialsSingle[1].Rate / 100;

            materialsDouble[0].LotDropRate = rate0;
            materialsDouble[0].TotalDropRate = rate0;

            materialsDouble[1].LotDropRate = (1 - rate0) + rate0 * rate1;
            materialsDouble[1].TotalDropRate = (1 - rate0) + rate0 * rate1;

            if (isUm)
            {
                materialsSingle[0].LotDropRate = rate0;
                materialsSingle[0].TotalDropRate = rate0;

                materialsSingle[1].LotDropRate = 1 - rate0;
                materialsSingle[1].TotalDropRate = 1 - rate0;
            }
            else
            {
                materialsSingle[0].LotDropRate = 1;
                materialsSingle[0].TotalDropRate = 1;

                materialsSingle[1].LotDropRate = 0;
                materialsSingle[1].TotalDropRate = 0;
            }
        }

        private static void CalculateRareDropRates(DropRareEntry entry)
        {
            int lotTotal = entry.CrystalRate + entry.WeaponRate + entry.EquipRate + entry.ArtsRate;

            entry.CrystalDropRate = (double)entry.CrystalRate / lotTotal;
            entry.WeaponDropRate = (double)entry.WeaponRate / lotTotal;
            entry.EquipDropRate = (double)entry.EquipRate / lotTotal;
            entry.ArtsDropRate = (double)entry.ArtsRate / lotTotal;

            var crystals = entry.Crystals;
            int crystalTotal = crystals.Sum(x => x.Rate);

            foreach (var item in crystals)
            {
                item.LotDropRate = (double)item.Rate / crystalTotal;
                item.TotalDropRate = item.LotDropRate * entry.CrystalDropRate;
            }

            var weapons = entry.Weapons;
            int weaponTotal = weapons.Sum(x => x.Rate);

            foreach (var item in weapons)
            {
                item.LotDropRate = (double)item.Rate / weaponTotal;
                item.TotalDropRate = item.LotDropRate * entry.WeaponDropRate;
            }

            var equips = entry.Armor;
            int equipTotal = equips.Sum(x => x.Rate);

            foreach (var item in equips)
            {
                item.LotDropRate = (double)item.Rate / equipTotal;
                item.TotalDropRate = item.LotDropRate * entry.EquipDropRate;
            }

            var arts = entry.ArtBooks;
            int artsTotal = arts.Sum(x => x.Rate);

            foreach (var item in arts)
            {
                item.LotDropRate = (double)item.Rate / artsTotal;
                item.TotalDropRate = item.LotDropRate * entry.ArtsDropRate;
            }
        }

        private static void CalculateSuperRareDropRates(DropSuperRareEntry entry)
        {
            int lotTotal = entry.WeaponRate + entry.UniqueWeaponRate + entry.UniqueArmorRate + entry.ArtsRate;

            entry.WeaponDropRate = (double)entry.WeaponRate / lotTotal;
            entry.UniqueWeaponDropRate = (double)entry.UniqueWeaponRate / lotTotal;
            entry.UniqueArmorDropRate = (double)entry.UniqueArmorRate / lotTotal;
            entry.ArtsDropRate = (double)entry.ArtsRate / lotTotal;

            var weapons = entry.Weapons;
            int weaponTotal = weapons.Sum(x => x.Rate);

            foreach (var item in weapons)
            {
                item.LotDropRate = (double)item.Rate / weaponTotal;
                item.TotalDropRate = item.LotDropRate * entry.WeaponDropRate;
            }

            var uniqueWeapons = entry.UniqueWeapons;
            int uniqueWeaponTotal = uniqueWeapons.Sum(x => x.Rate);

            foreach (var item in uniqueWeapons)
            {
                item.LotDropRate = (double)item.Rate / uniqueWeaponTotal;
                item.TotalDropRate = item.LotDropRate * entry.UniqueWeaponDropRate;
            }

            var uniqueEquips = entry.UniqueArmor;
            int uniqueEquipTotal = uniqueEquips.Sum(x => x.Rate);

            foreach (var item in uniqueEquips)
            {
                item.LotDropRate = (double)item.Rate / uniqueEquipTotal;
                item.TotalDropRate = item.LotDropRate * entry.UniqueArmorDropRate;
            }

            var arts = entry.ArtBooks;
            int artsTotal = arts.Sum(x => x.Rate);

            foreach (var item in arts)
            {
                item.LotDropRate = (double)item.Rate / artsTotal;
                item.TotalDropRate = item.LotDropRate * entry.ArtsDropRate;
            }
        }

        private static Enemy TryGetEnemy(BdatStringItem row)
        {
            if (string.IsNullOrWhiteSpace(row.Display.DisplayString))
                return null;

            var enemy = new Enemy();

            BdatStringItem enemyMapRow = row["stats"].Reference;

            if (enemyMapRow == null ||
                enemyMapRow["drop_nml"].Reference == null ||
                enemyMapRow["drop_rar"].Reference == null ||
                enemyMapRow["drop_spr"].Reference == null)
            {
                return null;
            }

            enemy.NormalRate = int.Parse(enemyMapRow["drop_nml_per"].ValueString);
            enemy.RareRate = int.Parse(enemyMapRow["drop_rar_per"].ValueString);
            enemy.SuperRareRate = int.Parse(enemyMapRow["drop_spr_per"].ValueString);

            if (enemy.NormalRate + enemy.RareRate + enemy.SuperRareRate == 0)
                return null;

            enemy.Id = enemyMapRow.Id;
            enemy.Name = enemyMapRow["name"].DisplayString;
            enemy.IsUm = int.Parse(enemyMapRow["named"].ValueString) == 2;

            enemy.NormalDrops = TryGetNormalTable(enemyMapRow["drop_nml"].Reference);
            enemy.RareDrops = TryGetRareTable(enemyMapRow["drop_rar"].Reference);
            enemy.SuperRareDrops = TryGetSuperRareTable(enemyMapRow["drop_spr"].Reference);

            return enemy;
        }

        private static DropNormalEntry TryGetNormalTable(BdatStringItem row)
        {
            var entry = new DropNormalEntry();

            for (int i = 0; i < MaxLotItems; i++)
            {
                DropEntry<MaterialEntry> item = GetMaterialEntry(row, i);
                if (item == null) break;

                entry.MaterialsSingle.Add(item);
                entry.MaterialsDouble.Add(GetMaterialEntry(row, i));
            }

            return entry;
        }

        private static DropRareEntry TryGetRareTable(BdatStringItem row)
        {
            var entry = new DropRareEntry();

            entry.CrystalRate = int.Parse(row["crystal_per"].ValueString);
            entry.WeaponRate = int.Parse(row["wpn_per"].ValueString);
            entry.EquipRate = int.Parse(row["equip_per"].ValueString);
            entry.ArtsRate = int.Parse(row["arts_per"].ValueString);

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetCrystalEntry(row, i);
                if (item == null) break;

                entry.Crystals.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetWeaponEntry(row, i);
                if (item == null) break;

                entry.Weapons.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetArmorEntry(row, i);
                if (item == null) break;

                entry.Armor.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetArtBookEntry(row, i);
                if (item == null) break;

                entry.ArtBooks.Add(item);
            }

            return entry;
        }

        private static DropSuperRareEntry TryGetSuperRareTable(BdatStringItem row)
        {
            var entry = new DropSuperRareEntry();

            entry.WeaponRate = int.Parse(row["wpn_per"].ValueString);
            entry.UniqueWeaponRate = int.Parse(row["uni_wpn_per"].ValueString);
            entry.UniqueArmorRate = int.Parse(row["uni_equip_per"].ValueString);
            entry.ArtsRate = int.Parse(row["arts_per"].ValueString);

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetWeaponEntry(row, i);
                if (item == null) break;

                entry.Weapons.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetUniqueWeaponEntry(row, i);
                if (item == null) break;

                entry.UniqueWeapons.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetUniqueArmorEntry(row, i);
                if (item == null) break;

                entry.UniqueArmor.Add(item);
            }

            for (int i = 0; i < MaxLotItems; i++)
            {
                var item = GetArtBookEntry(row, i);
                if (item == null) break;

                entry.ArtBooks.Add(item);
            }

            return entry;
        }

        private static DropEntry<MaterialEntry> GetMaterialEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"materia{index + 1}"))
                return null;

            BdatStringValue value = row[$"materia{index + 1}"];
            BdatStringValue percent = row[$"materia{index + 1}Per"];

            var material = new DropEntry<MaterialEntry>
            {
                Item = new MaterialEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse(percent.ValueString)
            };

            return material;
        }

        private static DropEntry<CrystalItemEntry> GetCrystalEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"crystal{index + 1}"))
                return null;

            BdatStringValue value = row[$"crystal{index + 1}"];
            BdatStringValue percent = row[$"crystal{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<CrystalItemEntry>
            {
                Item = new CrystalItemEntry
                {
                    Id = value.Reference.Id,
                    Rank = int.Parse(value.Reference["rank"].ValueString),
                    Skill1Name = value.Reference["skill1"].DisplayString,
                    Skill2Name = value.Reference["skill2"].DisplayString,
                    IsCylinder = value.Reference["cylinder"].ValueString == "1"
                },

                Rate = int.Parse(percent.ValueString)
            };

            return entry;
        }

        private static DropEntry<WeaponItemEntry> GetWeaponEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"wpn{index + 1}"))
                return null;

            BdatStringValue value = row[$"wpn{index + 1}"];
            BdatStringValue slot = row[$"wpn{index + 1}_slot"];
            BdatStringValue percent = row[$"wpn{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<WeaponItemEntry>
            {
                Item = new WeaponItemEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse(percent.ValueString),
                SlotCount = int.Parse(slot.ValueString)
            };

            return entry;
        }

        private static DropEntry<EquipItemEntry> GetArmorEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"equip{index + 1}"))
                return null;

            BdatStringValue value = row[$"equip{index + 1}"];
            BdatStringValue slot = row[$"equip{index + 1}_slot"];
            BdatStringValue percent = row[$"equip{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<EquipItemEntry>
            {
                Item = new EquipItemEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse((string)percent.Value),
                SlotCount = int.Parse(slot.ValueString)
            };

            return entry;
        }

        private static DropEntry<WeaponItemEntry> GetUniqueWeaponEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"uni_wpn{index + 1}"))
                return null;

            BdatStringValue value = row[$"uni_wpn{index + 1}"];
            BdatStringValue percent = row[$"uni_wpn{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<WeaponItemEntry>
            {
                Item = new WeaponItemEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse((string)percent.Value)
            };

            return entry;
        }

        private static DropEntry<EquipItemEntry> GetUniqueArmorEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"uni_equip{index + 1}"))
                return null;

            BdatStringValue value = row[$"uni_equip{index + 1}"];
            BdatStringValue percent = row[$"uni_equip{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<EquipItemEntry>
            {
                Item = new EquipItemEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse((string)percent.Value)
            };

            return entry;
        }

        private static DropEntry<ArtBookItemEntry> GetArtBookEntry(BdatStringItem row, int index)
        {
            if (!row.Values.ContainsKey($"arts{index + 1}"))
                return null;

            BdatStringValue value = row[$"arts{index + 1}"];
            BdatStringValue percent = row[$"arts{index + 1}Per"];

            if (value.Reference == null)
                return null;

            var entry = new DropEntry<ArtBookItemEntry>
            {
                Item = new ArtBookItemEntry
                {
                    Id = value.Reference.Id,
                    Name = value.DisplayString
                },

                Rate = int.Parse((string)percent.Value)
            };

            return entry;
        }
    }

    [DebuggerDisplay("{Name}")]
    internal class Enemy
    {
        public int Id;
        public string Name;
        public bool IsUm;

        public int NormalRate;
        public int RareRate;
        public int SuperRareRate;

        public double NormalDropRate;
        public double RareDropRate;
        public double SuperRareDropRate;

        public DropNormalEntry NormalDrops;
        public DropRareEntry RareDrops;
        public DropSuperRareEntry SuperRareDrops;

        public bool HasNormalDrops()
        {
            return NormalDrops.MaterialsSingle.Any(x => x.TotalDropRate > 0);
        }

        public bool HasRareDrops()
        {
            return RareDrops.Crystals.Any(x => x.TotalDropRate > 0) ||
                   RareDrops.Weapons.Any(x => x.TotalDropRate > 0) ||
                   RareDrops.Armor.Any(x => x.TotalDropRate > 0) ||
                   RareDrops.ArtBooks.Any(x => x.TotalDropRate > 0);
        }

        public bool HasSuperRareDrops()
        {
            return SuperRareDrops.Weapons.Any(x => x.TotalDropRate > 0) ||
                   SuperRareDrops.UniqueWeapons.Any(x => x.TotalDropRate > 0) ||
                   SuperRareDrops.UniqueArmor.Any(x => x.TotalDropRate > 0) ||
                   SuperRareDrops.ArtBooks.Any(x => x.TotalDropRate > 0);
        }
    }

    internal class DropNormalEntry
    {
        public List<DropEntry<MaterialEntry>> MaterialsSingle = new List<DropEntry<MaterialEntry>>();
        public List<DropEntry<MaterialEntry>> MaterialsDouble = new List<DropEntry<MaterialEntry>>();
    }

    internal class DropRareEntry
    {
        public int CrystalRate;
        public int WeaponRate;
        public int EquipRate;
        public int ArtsRate;

        public double CrystalDropRate;
        public double WeaponDropRate;
        public double EquipDropRate;
        public double ArtsDropRate;

        public List<DropEntry<CrystalItemEntry>> Crystals = new List<DropEntry<CrystalItemEntry>>();
        public List<DropEntry<WeaponItemEntry>> Weapons = new List<DropEntry<WeaponItemEntry>>();
        public List<DropEntry<EquipItemEntry>> Armor = new List<DropEntry<EquipItemEntry>>();
        public List<DropEntry<ArtBookItemEntry>> ArtBooks = new List<DropEntry<ArtBookItemEntry>>();
    }

    internal class DropSuperRareEntry
    {
        public int WeaponRate;
        public int UniqueWeaponRate;
        public int UniqueArmorRate;
        public int ArtsRate;

        public double WeaponDropRate;
        public double UniqueWeaponDropRate;
        public double UniqueArmorDropRate;
        public double ArtsDropRate;

        public List<DropEntry<WeaponItemEntry>> Weapons = new List<DropEntry<WeaponItemEntry>>();
        public List<DropEntry<WeaponItemEntry>> UniqueWeapons = new List<DropEntry<WeaponItemEntry>>();
        public List<DropEntry<EquipItemEntry>> UniqueArmor = new List<DropEntry<EquipItemEntry>>();
        public List<DropEntry<ArtBookItemEntry>> ArtBooks = new List<DropEntry<ArtBookItemEntry>>();
    }

    [DebuggerDisplay("{Skill1Name} / {Skill2Name} {Rank}")]
    internal class CrystalItemEntry
    {
        public int Id;
        public int Rank;
        public string Skill1Name;
        public string Skill2Name;
        public bool IsCylinder;

        public string GetDisplayString()
        {
            string rank;

            switch (Rank)
            {
                case 1:
                    rank = "I";
                    break;
                case 2:
                    rank = "II";
                    break;
                case 3:
                    rank = "II";
                    break;
                case 4:
                    rank = "IV";
                    break;
                case 5:
                    rank = "V";
                    break;
                case 6:
                    rank = "VI";
                    break;
                default:
                    throw new IndexOutOfRangeException(nameof(Rank));
            }

            if (!string.IsNullOrWhiteSpace(Skill2Name))
            {
                return $"{Skill1Name} {rank} / {Skill2Name} {rank}";
            }

            return $"{Skill1Name} {rank}";
        }
    }

    [DebuggerDisplay("{Name}")]
    internal class MaterialEntry
    {
        public int Id;
        public string Name;
    }

    [DebuggerDisplay("{Name}")]
    internal class WeaponItemEntry
    {
        public int Id;
        public string Name;
    }

    [DebuggerDisplay("{Name}")]
    internal class EquipItemEntry
    {
        public int Id;
        public string Name;
    }

    [DebuggerDisplay("{Name}")]
    internal class ArtBookItemEntry
    {
        public int Id;
        public string Name;
    }

    [DebuggerDisplay("{Item} {GetPercentage}")]
    internal class DropEntry<T> where T : new()
    {
        public T Item = new T();
        public int Rate;
        public int SlotCount;
        public double LotDropRate;
        public double TotalDropRate;

        public string GetPercentage => $"{TotalDropRate:P2}";
    }
}
