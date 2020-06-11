using System;
using System.Linq;
using System.Collections.Generic;

namespace Prim_s_Algorithm
{
    public struct VectorXY
    {
        public VectorXY(int Assx, int Assy)
        {
            x = Assx;
            y = Assy;
        }
        public int x;
        public int y;
        public override string ToString() => $"({x}, {y})";
    }
    public class Values
    {
        public char[] alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        public int CurrNum = 0;
        public Dictionary<VectorXY, char> Nodes = new Dictionary<VectorXY, char>();
    }
    public class Program
    {
        static void Main(string[] args)
        {
            List<int> UsedLengthsX = new List<int>();
            List<int> UsedLengthsY = new List<int>();
            var rand = new Random();
            Values V = new Values();
            for (int i = 0; i <= 8; i++)
            {
                var RandNX = rand.Next(1, 10);
                while (UsedLengthsX.Contains(RandNX))
                {
                    RandNX = rand.Next(1, 10);
                }
                var RandNY = rand.Next(1, 10);
                while (UsedLengthsY.Contains(RandNY))
                {
                    RandNY = rand.Next(1, 10);
                }
                UsedLengthsX.Add(RandNX);
                UsedLengthsY.Add(RandNY);
                V.Nodes.Add(new VectorXY(RandNX, RandNY), V.alpha[V.CurrNum]);
                V.CurrNum++;
            }
            
            for (int i = 0; i < V.Nodes.Count; i++)
            {
                var S1 = V.Nodes.ElementAt(i);
                Console.WriteLine($"{S1}");
            }
        }
    }
}
