using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace XbTool
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Options options = CliArguments.Parse(args);
            if (options == null) return;
            Tasks.RunTask(options);
        }
    }

    public static class Stuff
    {
        public static string ReadUTF8Z(this BinaryReader reader)
        {
            var start = reader.BaseStream.Position;

            // Read until we hit the end of the stream (-1) or a zero
            while (reader.BaseStream.ReadByte() - 1 > 0) { }

            int size = (int)(reader.BaseStream.Position - start - 1);
            reader.BaseStream.Position = start;

            string text = reader.ReadUTF8(size);
            reader.BaseStream.Position++; // Skip the null byte
            return text;
        }

        public static string ReadUTF8(this BinaryReader reader, int size)
        {
            return Encoding.UTF8.GetString(reader.ReadBytes(size), 0, size);
        }

        public static void CopyStream(this Stream input, Stream output, int length)
        {
            int remaining = length;
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, Math.Min(buffer.Length, remaining))) > 0)
            {
                output.Write(buffer, 0, read);
                remaining -= read;
            }
        }

        public static string GetUTF8Z(byte[] value, int offset)
        {
            var length = 0;

            while (value[offset + length] != 0)
            {
                length++;
            }

            return Encoding.UTF8.GetString(value, offset, length);
        }

        public static T ChooseRandom<T>(this IEnumerable<T> source, Random rand)
        {
            T[] arr = source.ToArray();
            return arr[rand.Next(arr.Length)];
        }

        public static T ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<int> probabilities)
        {
            T[] arr = source.ToArray();
            int[] probs = probabilities as int[] ?? probabilities.ToArray();

            var randVal = rand.NextDouble() * probs.Sum();
            float sum = 0;

            for (int i = 0; i < probs.Length; i++)
            {
                sum += probs[i];
                if (sum >= randVal)
                {
                    return arr[i];
                }
            }

            return default(T);
        }

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<byte> probabilities, int count) =>
            source.ChooseRandom(rand, probabilities.Select(x => (int)x), count);

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, IEnumerable<int> probabilities, int count)
        {
            T[] arr = source as T[] ?? source.ToArray();
            int[] probs = probabilities as int[] ?? probabilities.ToArray();

            if (arr.Length < count)
                throw new ArgumentOutOfRangeException(nameof(count),
                    $"There are fewer than {count} elements in {nameof(source)}");

            var chosen = new HashSet<T>();
            while (chosen.Count < count)
            {
                chosen.Add(arr.ChooseRandom(rand, probs));
            }

            return chosen.ToArray();
        }

        public static T[] ChooseRandom<T>(this IEnumerable<T> source, Random rand, int count)
        {
            T[] arr = source.ToArray();
            if (arr.Length < count)
                throw new ArgumentOutOfRangeException(nameof(count),
                    $"There are fewer than {count} elements in {nameof(source)}");

            var chosen = new HashSet<T>();
            while (chosen.Count < count)
            {
                chosen.Add(arr[rand.Next(arr.Length)]);
            }

            return chosen.ToArray();
        }
    }
}
