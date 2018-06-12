using System;
using XbTool.Types;

namespace XbTool.CreateBlade
{
    public static class Run
    {
        private static bool TryReadInt(int min, int max, out int value)
        {
            var line = Console.ReadLine();
            if (!int.TryParse(line, out value))
            {
                return false;
            }

            return value >= min && value <= max;
        }

        private static int ReadIntFromConsole(int min, int max, string message)
        {
            while (true)
            {
                Console.Write($"{message}: ");
                if (TryReadInt(min, max, out int value)) return value;
            }
        }

        public static void Create(BdatCollection tables)
        {
            var driver = new DriverInfo();
            var createParams = new BladeCreateParams();
            driver.Level = 99;
            createParams.Crystal = CrystalType.Legendary;
            driver.IdeaLevels[0] = 10;
            driver.IdeaLevels[1] = 10;
            driver.IdeaLevels[2] = 10;
            driver.IdeaLevels[3] = 10;
            createParams.BoosterCount = 0;

            if (createParams.BoosterCount > 0)
            {
                createParams.IdeaCategory = IdeaCategory.Compassion;
            }

            int times = 10;

            var delim = new string('=', 25);
            var create = new CreateCommon(tables, driver, createParams);

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Blade #{i + 1:D5}");
                Console.WriteLine(delim);
                Console.Write(OutputBlade.GetString(create.Create()));
                Console.WriteLine(delim);
            }
        }

        public static void PromptCreate(BdatCollection tables)
        {
            var driver = new DriverInfo();
            var createParams = new BladeCreateParams();
            driver.Level = ReadIntFromConsole(1, 99, "Enter Player Level (1-99)");
            createParams.Crystal = ReadIntFromConsole(1, 3, "Core Crystal Type; 1 - Common, 2 - Rare, 3 - Legendary") + CrystalType.Common - 1;
            driver.IdeaLevels[0] = ReadIntFromConsole(1, 10, "Bravery Idea Level (1-10)");
            driver.IdeaLevels[1] = ReadIntFromConsole(1, 10, "Truth Idea Level (1-10)");
            driver.IdeaLevels[2] = ReadIntFromConsole(1, 10, "Compassion Idea Level (1-10)");
            driver.IdeaLevels[3] = ReadIntFromConsole(1, 10, "Justice Idea Level (1-10)");
            createParams.BoosterCount = ReadIntFromConsole(0, 5, "Use how many boosters? (0-5)");

            if (createParams.BoosterCount > 0)
            {
                createParams.IdeaCategory = (IdeaCategory)(ReadIntFromConsole(1, 4, "Booster type; Bravery - 1, Truth - 2, Compassion - 3, Justice - 4") - 1);
            }

            int times = ReadIntFromConsole(1, 100, "Number of blades to generate (1-100)");

            var delim = new string('=', 25);
            var create = new CreateCommon(tables, driver, createParams);

            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
                Console.WriteLine(delim);
                Console.Write(OutputBlade.GetString(create.Create()));
                Console.WriteLine(delim);
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }
    }
}
