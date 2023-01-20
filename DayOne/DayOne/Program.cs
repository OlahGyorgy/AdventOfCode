using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOne
{
    public class DataProcessor
    {
        String pathToResources = "../../../Resources/";
        List<uint> Calories;

        public DataProcessor()
        {
            StreamReader sr = new StreamReader(pathToResources + "Input.txt");
            uint sum = 0;
            Calories = new List<uint>();

            do
            {
                String line = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(line))
                {
                    Calories.Add(sum);
                    sum = 0;
                }

                else
                {
                    sum = sum + uint.Parse(line);
                }

            } while (!sr.EndOfStream);


            sr.Close();
        }

        public void solvePartOne()
        {
            Console.WriteLine("Legnagyobb elem = " + Calories.Max().ToString());
        }

        public void solvePartTwo()
        {
            uint sumTopThree = 0;
            Calories.Sort();
            for (int k = Calories.Count-1; Calories.Count-3 <= k; k--)
            {
                sumTopThree = sumTopThree + Calories[k];
            }

            Console.WriteLine("A 3 legnayobb összege: "+sumTopThree.ToString());

        }

        public override string ToString()
        {
            if (Calories.Count < 1) { return "elbasztad"; }
            return "Legnagyobb elem = "+Calories.Max().ToString();
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
