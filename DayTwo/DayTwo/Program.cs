using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DayTwo
{
    class DataProcessor
    {
        List<String> Games;
        String pathToResources = "../../../Resources/";

        // 0 = lose , 3 = draw , 6 = win
        //1 = rock, 2 = paper, 3 = sciccors

        //A,X = rock; B,Y = paper; Z,C = sciccors

        enum rps
        {
            r = 1,
            p = 2,
            s = 3
        }

        public DataProcessor()
        {
            StreamReader sr = new StreamReader(pathToResources + "Input.txt");
            Games = new List<String>();

            do
            {
                String line = sr.ReadLine();
                Games.Add(line);


            } while (!sr.EndOfStream);


            sr.Close();
        }

        int  calc(String s)
        {
            if (s == "A" || s == "X") return 1; //rock
            if (s == "B" || s == "Y") return 2; // paper
            if (s == "C" || s == "Z") return 3; // sciccor
            throw new Exception("invalid param for enum: "+ s);
        }

        int calc(String s, int their)
        {
            if (s == "Y") return their;
            else if (s == "X") return (their ==1?3:their-1); //X = lose
            else if (s == "Z") return (their == 3?1:their+1);  // win
            throw new Exception("invalid param for enum: " + s);

        }


        public void solvePartOne()
        {
            int sum = 0;

            foreach (String i in Games)
            {               
                int their = calc(i.Split(' ')[0]);
                int mine = calc(i.Split(' ')[1]);
                sum += mine;
                if (their == mine) { sum+= 3; }
                 else if (their +1 == mine || their/mine ==3 ) { sum+= 6; }
               
            }

            Console.WriteLine(sum.ToString());

        }
        public void solvePartTwo()
        {
            int sum = 0;

            foreach (String i in Games)
            {
                int their = calc(i.Split(' ')[0]);
                int mine = calc(i.Split(' ')[1],their);

                sum += mine;
                if (their == mine) { sum += 3; }
                else if (their + 1 == mine || their / mine == 3) { sum += 6; }
            }

            Console.WriteLine(sum.ToString());

        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataProcessor d = new DataProcessor();


            d.solvePartOne();
            d.solvePartTwo();

            Console.ReadKey();
        }
    }
}
