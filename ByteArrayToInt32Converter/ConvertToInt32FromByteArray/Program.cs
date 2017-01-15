using System;
using System.Diagnostics;
using System.Linq;

namespace ConvertToInt32FromByteArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = new byte[] { 24, 12, 255, 1 };

            var a1 = 0;
            var a2 = 0;
            var a3 = 0;
            var n = 1000000;
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                a1 = BitConverter.ToInt32(bytes, 0);
            }
            Console.WriteLine($"BitConverter from System.Diagnostics used {sw1.ElapsedMilliseconds} msc for {n} iterations\n");

            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                a2 = ConvertByteArrayToInt32(bytes);
            }
            Console.WriteLine($"My ConvertByteArrayToInt32 converter used {sw1.ElapsedMilliseconds} msc for {n} iterations\n");

            var sw3 = Stopwatch.StartNew();
            for (int i = 0; i < n; i++)
            {
                a3 = FromByteToInt1(24, 12, 255, 1);
            }
            Console.WriteLine($"Tigran's FromByteToInt1 converter used {sw1.ElapsedMilliseconds} msc for {n} iterations\n");


            Console.ReadKey();
        }

        public static int ConvertByteArrayToInt32(byte[] bytes)
        {
            var binary = bytes.Reverse().Select(x => Convert.ToString(x, 2).PadLeft(8, '0')).SelectMany(x => x).ToArray();

            var result = 0;
            for (int i = 0; i < binary.Length; i++)
                if (binary[binary.Length - i - 1] == '1') result += (int)Math.Pow(2, i);

            return result;
        }
        public static int FromByteToInt1(byte a, byte b, byte c, byte d)
        {
            string s = Convert.ToString(d, 2).PadLeft(8, '0') + Convert.ToString(c, 2).PadLeft(8, '0') + Convert.ToString(b, 2).PadLeft(8, '0') + Convert.ToString(a, 2).PadLeft(8, '0');
            var decim = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[s.Length - i - 1] == '0') continue;
                decim += (int)Math.Pow(2, i);
            }
            return decim;
        }
    }
}
