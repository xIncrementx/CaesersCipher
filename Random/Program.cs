using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Randomd
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1) Random
            // Random = new Random(250);

            //for (int i = 0; i < 10; i++)
            //{
            //    Console.WriteLine("{0,3}   ", random.Next(-10, 11));
            //    Console.ReadKey();
            //}
            //Console.ReadKey();

            // 2) RNGCryptoServiceProvider
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();

            //var byteArray = new byte[4];
            //provider.GetBytes(byteArray);

            //// convert 4 bytes to an integer
            //var randomInt = BitConverter.ToUInt32(byteArray, 0);

            //var byteArray2 = new byte[8];
            //provider.GetBytes(byteArray2);

            ////Convert 8 bytes to a double
            //var randomDouble = BitConverter.ToDouble(byteArray2, 0);

            //int cnt = 0;

            //for (int i = 0; i < 10000; i++)
            //{
            //    if (Double.IsNaN(randomDouble))
            //    {
            //        cnt++;
            //    }
            //    Console.WriteLine(randomInt);
            //    Console.WriteLine(randomDouble);

            //    provider.GetBytes(byteArray);
            //    randomInt = BitConverter.ToUInt32(byteArray, 0);
            //    provider.GetBytes(byteArray2);
            //    randomDouble = BitConverter.ToDouble(byteArray2, 0);
            //}
            //Console.WriteLine("==============");
            //Console.WriteLine("END");
            //Console.WriteLine();
            //Console.WriteLine("Cnt of NaN:" + cnt);

            //// 3) Sammenlign random og RNGCryptoServiceProvider
            //Random random = new Random();

            //int randomNum = 0;

            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();

            //// Random
            //for (int i = 0; i < 100000; i++)
            //{
            //    randomNum = random.Next(0, 9);
            //}

            //stopwatch.Stop();


            //TimeSpan time = stopwatch.Elapsed;

            //Console.WriteLine("Time it took to randomly(10k loops) generate using Random: " + randomNum + ": " + time);

            //stopwatch.Reset();

            //// RNGCryptoServiceProvider
            //RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            //var byteArray = new byte[4];
            //provider.GetBytes(byteArray);
            //var randomInt = BitConverter.ToUInt32(byteArray, 0);

            //stopwatch.Start();

            //for (int i = 0; i < 100000; i++)
            //{
            //    randomInt = BitConverter.ToUInt32(byteArray, 0);
            //}
            //stopwatch.Stop();

            //Console.WriteLine("Time it took to randomly(10k loops) generate using RNGCryptoServiceProvider: " + randomInt + ": " + time);

            //Console.ReadKey();

            // Caeser 4) 
            // Receive input
            Console.Write("Input your secret message: ");
            string message = Console.ReadLine();
            Console.Clear();

            // Encrypt
            string encryptedMessage = Encrypt(message.ToUpper());
            Console.WriteLine(encryptedMessage);

            // Decrypt
            //string decryptedMessage = Decrypt(encryptedMessage);
            //Console.WriteLine(decryptedMessage);

            Console.ReadKey();

        }
        static string Encrypt(string input)
        {
            byte cryptRule = 9;
            byte cnt = 0;

            char[] message = new char[input.Length];
            message = input.ToCharArray();

            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZÆØÅ";
            char[] charBase = new char[alphabet.Length];
            charBase = alphabet.ToCharArray();

            for (int i = 0; i < message.Length; i++)
            {
                for (int j = 0; j < charBase.Length; j++)
                {
                    if (message[i] == charBase[j])
                    {
                        cnt++;
                        if ((cryptRule + j) > charBase.Length)
                        {
                            message[i] = charBase[((cryptRule + j) - charBase.Length) - 1];
                        }
                        else
                        {
                            message[i] = charBase[j];
                        }
                    }
                }
            }

            Console.WriteLine(cnt);
            Console.ReadKey();

            return new string(message);
        }
        static string Decrypt(string input)
        {
            return "lol";
        }
    }
}
