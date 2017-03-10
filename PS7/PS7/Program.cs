using System;
using System.Numerics;

namespace NumberTheory
{
    class Program
    {
        static void Main(string[] args)
        {
            // Hello?
            // Read the first line
            string i = Console.ReadLine();
            string[] input;

            // Continue to read input until there isn't any.
            while (!string.IsNullOrEmpty(i))
            {
                input = i.Split();
                switch (input[0])
                {
                    case "gcd":
                        BigInteger a = BigInteger.Parse(input[1]);
                        BigInteger b = BigInteger.Parse(input[2]);
                        Console.WriteLine(gcd(a, b));
                        break;

                    case "exp":
                        BigInteger x = BigInteger.Parse(input[1]);
                        BigInteger y = BigInteger.Parse(input[2]);
                        BigInteger n = BigInteger.Parse(input[3]);
                        Console.WriteLine(exp(x, y, n));
                        break;

                    case "inverse":
                        BigInteger A = BigInteger.Parse(input[1]);
                        BigInteger N = BigInteger.Parse(input[2]);
                        Console.WriteLine(inverse(A, N));
                        break;

                    case "isprime":
                        isPrime(input[1]);
                        break;

                    case "key":
                        key(input[1], input[2]);
                        break;
                }

                i = Console.ReadLine();
            }
        }

        private static void key(string v1, string v2)
        {

        }

        private static string isPrime(string v)
        {
            return "";
        }

        private static string inverse(BigInteger a, BigInteger n)
        {
            BigInteger[] parts = ee(a, n);
            if (parts[2].Equals(1))
                return (parts[0] % n).ToString();
            else
                return "none";
        }

        private static BigInteger[] ee(BigInteger a, BigInteger b)
        {
            if (b.Equals(0))
                return new BigInteger[3] { 1, 0, a };
            else
            {
                BigInteger[] parts = ee(b, a % b);
                return new BigInteger[3] { parts[1], parts[0] - ((a / b) * parts[1]), parts[2] };
            }
        }

        private static BigInteger exp(BigInteger x, BigInteger y, BigInteger n)
        {
            if (y.Equals(0))
                return 1;
            else
            {
                BigInteger z = exp(x, y / 2, n);
                if (y % 2 == 0)
                    return (z * z) % n;
                else
                    return (x * z * z) % n;
            }

        }

        private static BigInteger gcd(BigInteger a, BigInteger b)
        {
            if (b.Equals(0))
                return a;
            else
                return gcd(b, a % b);
        }
    }
}
