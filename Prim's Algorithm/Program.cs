using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Numerics;

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
        public Dictionary<char, VectorXY> Nodes = new Dictionary<char, VectorXY>();
    }
    public class VectorInfo
    {
        public Values V = new Values();
        
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
       //Grab x value
       //Grab y value
       //Grab 2nd of each
       //Log
       //Compare
        
    }
    public class Program
    {
        static void Main(string[] args)
        {
            VectorInfo VI = new VectorInfo();
            VI.ToString();
            Console.Write("Press enter to begin sorting...");
            Console.ReadLine();
            //List<VectorXY> LVXY = new List<VectorXY>();
            VectorXY[] VXYarr = new VectorXY[VI.V.Nodes.Values.Count];
            VI.V.Nodes.Values.CopyTo(VXYarr, 0);
            var VXYL = VXYarr.AsEnumerable<VectorXY>().ToList();
            for (int i = 1; i <= VXYL.Count; i++)
            {
                for (int i1 = 1; i1 <= VXYL.Count; i1++)
                {
                    var compVXY = new VectorXY(i, i1);
                    if (VXYL.Contains(compVXY))
                    {
                        Console.Write("Y");
                    } else
                    {
                        Console.Write("0");
                    }
                    Console.Write("  ");
                    
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Random rand = new Random();
            char start = VI.V.alpha[rand.Next(0, VI.V.Nodes.Count)];
            VectorXY StartXY = VI.V.Nodes[start];
            Dictionary<char, float> Distances = new Dictionary<char, float>();
            int IcurrLetter = 0;
            for (int i = 0; i < VI.V.Nodes.Count - 1; i++)
            {

                VectorXY TestXY = VI.V.Nodes[VI.V.alpha[IcurrLetter]];
                float Dis = MathF.Sqrt((StartXY.x - TestXY.x) * (StartXY.x - TestXY.x) + (StartXY.y - TestXY.y) * (StartXY.y - TestXY.y));
                if (!(Dis == 0))
                {
                    Distances.Add(VI.V.alpha[IcurrLetter], Dis);
                } else
                {
                    Distances.Add(VI.V.alpha[IcurrLetter], (float)10000);
                }
                IcurrLetter++;
            }
            Console.WriteLine(Distances);
            float[] DistancesF = new float[Distances.Count];
            Distances.Values.CopyTo(DistancesF, 0);
            System.Array.Sort(DistancesF);
            
            //Todo: Create a while function that checks to see if there is anything not visited. If not, do the math to make the next visit, add it to a list, display this on a pretty print, and repeat.
            //List<int> LX = VI.V.Nodes.Values.Select((x) => x.x).ToList();
            //List<int> LY = VI.V.Nodes.Values.Select((x) => x.y).ToList();
            //Dictionary<int, int> NODEXY = new Dictionary<int, int>();

            Console.WriteLine("Finish");
            
        }
    }
}
