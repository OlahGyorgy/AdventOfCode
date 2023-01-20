using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree
{
    class DataPiece
    {
        int[] d;

       public  DataPiece(String a, String b)
        {
            d = new int[2];
            d[0] = int.Parse(a);
            d[1] = int.Parse(b);
        }

        public bool contains(DataPiece b)
        {
            if (this.d[0] <= b.d[0] && b.d[1] <= this.d[1]) { return true; }

            if (b.d[0] <= this.d[0] && this.d[1] <= b.d[1]) { return true; }

            return false;
        }

        public bool overlap(DataPiece b)
        {
            if ((this.d[0] <= b.d[1] && b.d[0] <= this.d[0] ) || (this.d[1] <= b.d[1] && b.d[0] <= this.d[1])) { return true; }


            if ((b.d[0] <= this.d[1] && this.d[0] <= b.d[0] ) || (b.d[1] <= this.d[1] && this.d[0] <= b.d[1])) { return true; }

            



            return false;
        }
    }

    static public class DataProcessor
    {
        static String pathToResources = "../../../Resources/Input.txt";

        public static int containsSum()
        {
            int result = 0;
            StreamReader sr = new StreamReader(pathToResources);

            do
            {
                String line = sr.ReadLine();

                String elfOne = line.Split(',')[0];
                String elfTwo = line.Split(',')[1];


                DataPiece a = new DataPiece(elfOne.Split('-')[0], elfOne.Split('-')[1]);
                DataPiece b = new DataPiece(elfTwo.Split('-')[0], elfTwo.Split('-')[1]);
                if (a.contains(b)) { result++; }


            } while (!sr.EndOfStream);

            return result;
        }

        public static int overlapSum()
        {
            int result = 0;
            StreamReader sr = new StreamReader(pathToResources);

            do
            {
                String line = sr.ReadLine();

                String elfOne = line.Split(',')[0];
                String elfTwo = line.Split(',')[1];


                DataPiece a = new DataPiece(elfOne.Split('-')[0], elfOne.Split('-')[1]);
                DataPiece b = new DataPiece(elfTwo.Split('-')[0], elfTwo.Split('-')[1]);
                if (a.overlap(b)) { result++; }


            } while (!sr.EndOfStream);

            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DataProcessor.overlapSum());
            Console.ReadKey();

        }
    }
}
