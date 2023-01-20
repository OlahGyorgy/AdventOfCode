using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayThree
{


    class DataHandler
    {
        String pathToResources = "../../../Resources/Input.txt";
        public List<Stack<String>> cartes;



        public DataHandler(){

            StreamReader sr = new StreamReader(pathToResources);
            String line = sr.ReadLine();
            createStacks(line);
            Stack<String> lines = new Stack<string>();


            do
            {
                line = sr.ReadLine();
                lines.Push(" " + line + " ");

            } while (!String.IsNullOrWhiteSpace(line));

            fillCreates(lines);

           /* do
            {
                line = sr.ReadLine();


            } while (!sr.EndOfStream);*/

            sr.Close();

        }

        public string getTops()
        {
            String result = "";

            foreach (Stack<String> item in cartes)
            {
                result = result + item.Peek();
            }

            return result;
        }

         void moveCarte(int quantity, int from, int to)
        {    
            for (int i = 0; i < quantity; i++)
            {
                cartes[to-1].Push(cartes[from-1].Pop()) ;
            }
        }

        void createStacks(String firstLine)
        {

            List<Stack<String>> cartes = new List<Stack<string>>();

            int cartesCount = (firstLine.Length + 2) / 4;

            for (int i = 0; i < cartesCount; i++)
            {
                cartes.Add(new Stack<String>());
            }

            this.cartes = cartes;
        }

        void fillCreates(Stack<String> s) {

            foreach (String item in s)
            {
                for (int i = 0,j = 0; i < item.Length; i = +4,j++)
                {
                    String subs = item.Substring(i + 4, 4);
                    if (subs.Contains("[")) { cartes[j].Push(subs[1].ToString()); }
                }
            }
        
        
        } //toDo


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DataHandler a = new DataHandler();

            Console.WriteLine(a.getTops());

            Console.ReadKey();

        }
    }
}
