using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree
{

    static public class DataProcessor
    {
       static String pathToResources = "../../../Resources/Input.txt";

        static String[] dataReader()
        {
            String[] result = {};
            StreamReader sr = new StreamReader(pathToResources);

            do
            {
                String line = sr.ReadLine();
                if (String.IsNullOrWhiteSpace(line))
                {
                    
                }

                else
                {
                   
                }

            } while (!sr.EndOfStream);

            return result;
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
