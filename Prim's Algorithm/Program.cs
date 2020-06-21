using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

namespace Prim_s_Algorithm
{
    public class TwoChar
    {
        public char From { get; set; }
        public char To { get; set; }
        public TwoChar(char from, char to)
        {
            From = from;
            To = to;
        }
    }
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
        public Dictionary<char, VectorXY> Nodes = new Dictionary<char, VectorXY>();
    }
    public class VectorInfo
    {
        public Values V = new Values();
        public List<VectorXY> VistedXY = new List<VectorXY>();
        public VectorInfo()
        {

            List<int> UsedLengthsX = new List<int>();
            List<int> UsedLengthsY = new List<int>();
            var rand = new Random();

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
                V.Nodes.Add(V.alpha[V.CurrNum], new VectorXY(RandNX, RandNY));
                V.CurrNum++;
            }
        }
        public override string ToString()
        {
            for (int i = 0; i < V.Nodes.Count; i++)
            {
                var S1 = V.Nodes.ElementAt(i);
                Console.WriteLine($"{S1}");

            }
            return "";
        }

    }
    public class Program
    {

        public static void Print(VectorInfo VI, VectorXY Start)
        {
            VectorXY[] VXYarr = new VectorXY[VI.V.Nodes.Values.Count];
            VI.V.Nodes.Values.CopyTo(VXYarr, 0);
            var VXYL = VXYarr.AsEnumerable<VectorXY>().ToList();
            for (int i = 1; i <= VXYL.Count; i++)
            {
                for (int i1 = 1; i1 <= VXYL.Count; i1++)
                {
                    var compVXY = new VectorXY(i1, i);
                    if (VXYL.Contains(compVXY))
                    {
                        if (compVXY.x == Start.x && compVXY.y == Start.y)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("S");
                            Console.ResetColor();
                        }
                        else if (VI.VistedXY.Contains(compVXY))
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Y");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write("Y");
                        }
                    }
                    else
                    {
                        Console.Write("0");
                    }
                    Console.Write("  ");

                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }
        static void Main(string[] args)
        {
            VectorInfo VI = new VectorInfo();
            Random rand = new Random();
            //VI.ToString();
            Console.Write("Press enter to begin sorting...");
            Console.ReadLine();
            //List<VectorXY> LVXY = new List<VectorXY>();
            VectorXY[] VXYarr = new VectorXY[VI.V.Nodes.Values.Count];
            VI.V.Nodes.Values.CopyTo(VXYarr, 0);
            var VXYL = VXYarr.AsEnumerable<VectorXY>().ToList();
            char start = VI.V.alpha[rand.Next(0, VI.V.Nodes.Count)];
            VectorXY StartXY = VI.V.Nodes[start];
            VI.VistedXY.Add(StartXY);
            Print(VI, StartXY);
            int RunNumber = 0;
            while (VI.VistedXY.Count != VI.V.Nodes.Count)
            {
                Dictionary<TwoChar, float> Distances = new Dictionary<TwoChar, float>();
                int IcurrLetter = 0;
                for (int i = 0; i <= VI.V.Nodes.Count - 1; i++)
                {
                    VectorXY TestXY = VI.V.Nodes[VI.V.alpha[IcurrLetter]];
                    if (!VI.VistedXY.Contains(TestXY))
                    {
                        foreach (VectorXY VXY in VI.VistedXY)
                        {
                            float Dis = MathF.Sqrt((VXY.x - TestXY.x) * (VXY.x - TestXY.x) + (VXY.y - TestXY.y) * (VXY.y - TestXY.y));
                            if (!(Dis == 0))
                            {
                                Distances.Add(new TwoChar(VI.V.Nodes.FirstOrDefault(x => x.Value.x == VXY.x && x.Value.y == VXY.y).Key, VI.V.Nodes.FirstOrDefault(x => x.Value.x == TestXY.x && x.Value.y == TestXY.y).Key), Dis);
                            }
                            else
                            {   
                            }
                        }
                    }
                    IcurrLetter++;
                }
                float[] DistancesF = new float[Distances.Count];
                Distances.Values.CopyTo(DistancesF, 0);
                System.Array.Sort(DistancesF);
                char ToTravel = Distances.FirstOrDefault(x => x.Value == DistancesF[0]).Key.To;
                VI.VistedXY.Add(VI.V.Nodes[ToTravel]);
                Console.WriteLine($"{ToTravel} was visited. Press enter to continue...");
                Console.ReadLine();
                Print(VI, StartXY);
                RunNumber++;
            }
        }
    }

}