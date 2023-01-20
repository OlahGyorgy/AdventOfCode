using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DayThree
{

    static public class DataHandler
    {
        static String pathToResources = "../../../Resources/Input.txt";

        public static List<String> dataReader()
        {
            List<String> result = new List<string>();

            StreamReader sr = new StreamReader(pathToResources);

            do
            {
                String line = sr.ReadLine();

                result.Add(line);

            } while (!sr.EndOfStream);

            return result;
        }

    }


    public class DataProcessor
    {
        List<String> data;
        public DataProcessor()
        {
            data = DataHandler.dataReader();
        }

        public int getSumPrio()
        {
            int sum = 0;
            foreach (String item in data)
            {
                int a = getPriority(getCommonChar(item));

                sum += a;
            }

            return sum;
        }

        public int getSumTrioPrio()
        {
            int sum = 0;
            for (int i = 2; i < data.Count;i+=3)
            {
                int a = getPriority(getCommonChar(data[i-2], data[i - 1], data[i]));
                sum += a;
            }

            return sum;
        }

        int getPriority(int c)
        {

            if (c == (int)' ') { return 0; }
            if ( (int)'a'<= c && c <=(int)'z' )
            {
                return c - (int)'a' + 1; 
            }
            else {
                return c - (int)'A' + 27;
            }

           
        }

        int getCommonChar(String data)
        {
            int length = data.Length;
            String data1 = data.Substring(0, length / 2);
            String data2 = data.Substring(length / 2);

            int i = 0;

            char common = ' ';

            while (common == ' ' && i < data1.Length)
            {
                int j = 0;
                while (common == ' ' && j < data2.Length)
                {
                    if (data1[i] == data2[j]) { common = data1[i]; }

                    j++;
                }
                i++;

            }

            return (int)common;
        }

        int getCommonCharOld(String data1, String data2, String data3)
        {


            int i = 0;

            char common = ' ';

            while (common == ' ' && i < data1.Length )
            {
                int j = 0;
                while (common == ' ' && j < data2.Length)
                {

                    if (data1[i] == data2[j]) {

                        int k = 0;
                        while (common == ' ' && k < data3.Length)
                        {
                            if (data1[i] == data3[k]) { common = data1[i]; }
                            k++;
                        }
                        
                    }

                    j++;
                }
                i++;

            }

            return (int)common;
        }

        int getCommonChar(String data1, String data2, String data3)
        {

            HashSet<char> data1set = new HashSet<char>(data1);
            HashSet<char> data2set = new HashSet<char>(data2);
            HashSet<char> data3set = new HashSet<char>(data3);

            return (int) data1set.Intersect(data2set).Intersect(data3set).First();


        }




    }
    internal class Program
    {
        static void Main(string[] args)
        {

            DataProcessor d = new DataProcessor();

            Console.WriteLine(d.getSumTrioPrio());
            Console.WriteLine(d.getSumPrio());
            

            Console.ReadKey();
        }
    }
}
