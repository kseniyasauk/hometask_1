using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Manipulation
{
    class Runner
    {
        static void Main(string[] args)
        {
            string str;
            Runner runner = new Runner();
            List<string> listOfStrings = new List<string>();

            do
            {
                str = Console.ReadLine();
                listOfStrings.Add(str);
            } while (str != "");

            runner.NumManipulations(listOfStrings);
        }

        public int NumManipulations(List<string> list)
        {
            int countIntNumbers = 0;
            int countDoubleNumbers = 0;

            int resultIntNum = 0;
            double resultDoubleNum = 0;

            int intSum = 0;
            double doubleSum = 0;

            List<int> intNums = new List<int>();
            List<double> doubleNums = new List<double>();
            List<string> NewWords = new List<string>();

            Runner runner = new Runner();

            foreach (string str in list)
            {
                string[] words = str.Split(' ');

                foreach (string st in words)
                {

                    if (Int32.TryParse(st, out resultIntNum))
                    {
                        intNums.Add(resultIntNum);
                        countIntNumbers++;
                        intSum += resultIntNum;
                    }
                    else
                    {
                        if (Double.TryParse(st, out resultDoubleNum))
                        {
                            doubleNums.Add(resultDoubleNum);
                            countDoubleNumbers++;
                            doubleSum += resultDoubleNum;
                        }
                        else
                        {
                            NewWords.Add(st);
                        }
                    }

                }
            }

            Console.WriteLine("The number of integers: " + countIntNumbers);
            Console.WriteLine("The number of fractional digits: " + countDoubleNumbers);

            for (int i = 0; i < intNums.Count; i++)
            {
                Console.WriteLine(intNums[i].ToString().PadLeft(33));
            }
            double intAverage = (double)intSum / countIntNumbers;

            Console.WriteLine("The average value of integers: " + intAverage);

            for (int i = 0; i < doubleNums.Count; i++)
            {
                Console.WriteLine(doubleNums[i].ToString().PadLeft(45));
            }

            Console.Write("The average value of fractional digits: ");
            Console.WriteLine("{0:F2}", (doubleSum / countDoubleNumbers));

            NewWords = runner.sortList(NewWords);
            foreach (var item in NewWords)
            {
                Console.WriteLine(item);
            }


            return countIntNumbers;
        }

        List<string> sortList(List<string> parsedText)
        {
            for (int i = 0; i < parsedText.Count; i++)
            {
                int min = parsedText[i].Length;
                int iMin = i;
                for (int j = i + 1; j < parsedText.Count; j++)
                {
                    if (parsedText[j].Length < min)
                    {
                        string temp = parsedText[i];
                        min = parsedText[j].Length;
                        iMin = j;
                        parsedText[i] = temp;
                    }
                }
                if (i != iMin)
                {

                    string temp = parsedText[i];

                    parsedText[i] = parsedText[iMin];

                    parsedText[iMin] = temp;
                }
            }
            return parsedText;
        }
    }
}