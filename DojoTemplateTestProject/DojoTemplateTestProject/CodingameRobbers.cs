using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GradeBook.Tests
{
    public class CodingameRobbers
    {
        public void Start(string[] args)
        {
            int R = int.Parse(Console.ReadLine());
            Console.Error.WriteLine($"R is {R}");
            int V = int.Parse(Console.ReadLine());
            Console.Error.WriteLine($"V is {V}");

            var vaults = new List<Vault>();
            for (int i = 0; i < V; i++)
            {
                string[] inputs = Console.ReadLine().Split(' ');
                int C = int.Parse(inputs[0]);
                Console.Error.WriteLine($"C is {C}");
                int N = int.Parse(inputs[1]);
                Console.Error.WriteLine($"N is {N}");
                var vowels = C - N;
                var combinations = (int)(Math.Pow(10.0, N) * Math.Pow(5.0, vowels));
                var vault = new Vault
                {
                    TimeToCrack = combinations,
                    IsCracked = false
                };
                vaults.Add(vault);
                Console.Error.WriteLine($"V{i} time to crack {vault.TimeToCrack}");
            }

            var robbers = new List<Robber>();

            for (int i = 0; i < R; i++)
            {
                var robber = new Robber
                {
                    TotalCrackingTime = 0
                };

                robbers.Add(robber);
            }

            var answer = DoTheThing(robbers, vaults).ToString();

            Console.WriteLine(answer);

        }

        public int DoTheThing(List<Robber> robbers, List<Vault> vaults)
        {

            while (vaults.Any(v => !v.IsCracked))
            {
                foreach (var robber in robbers)
                {
                    var minTime = robbers.Min(r => r.TotalCrackingTime);
                    if (robber.TotalCrackingTime == minTime)
                    {
                        var firstFreevault = vaults.FirstOrDefault(v => !v.IsCracked);
                        robber.TotalCrackingTime += firstFreevault.TimeToCrack;
                        Console.Error.WriteLine($"robber total is {robber.TotalCrackingTime}");
                        firstFreevault.IsCracked = true;
                    }
                }
            }

            var result = robbers.Max(r => r.TotalCrackingTime);
            return result;
        }

        public class Vault
        {
            public int TimeToCrack { get; set; }
            public bool IsCracked { get; set; }
        }

        public class Robber
        {
            public int TotalCrackingTime { get; set; }
        }

        public class Tests
        {
            [Fact]
            public void TestRobbers()
            {
                var robbers = new List<Robber> { new Robber(), new Robber(), new Robber(), new Robber() };
                var vault1 = new Vault { TimeToCrack = 100 };
                var vault2 = new Vault { TimeToCrack = 1250 };
                var vault3 = new Vault { TimeToCrack = 300 };
                var vault4 = new Vault { TimeToCrack = 156250 };
                var vaults = new List<Vault> { vault1, vault2, vault3, vault4 };

                var sut = new CodingameRobbers();
                var result = sut.DoTheThing(robbers, vaults);

                Assert.Equal(5000000, result);
            }
        }
    }
}

