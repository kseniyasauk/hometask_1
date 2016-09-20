using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {

            Program pr = new Program();

            if (ConfigurationManager.AppSettings["config"].Equals("console")) {
                
                string console = Console.ReadLine();

                Console.Write(DateTime.Now.ToString() + " ");

                console = pr.ToLowwerCase(console);
                console = pr.DeletePointMark(console);
                console = pr.DeleteQuestionMark(console);
                console = pr.DeleteExclamationMark(console);

                Console.WriteLine(console);
                

            }
            if (ConfigurationManager.AppSettings["config"].Equals("file")) {
                string path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.WriteLine("No such file or path is uncorrect!");
                }
                else {
                    string text = File.ReadAllText(path);

                    Console.WriteLine(DateTime.Now.ToString() + " ");

                    text = pr.ToLowwerCase(text);
                    text = pr.DeletePointMark(text);
                    text = pr.DeleteQuestionMark(text);
                    text = pr.DeleteExclamationMark(text);

                    Console.WriteLine(text);

                }
            }
        }

        public string ToLowwerCase(string text)
        {
            return text.ToLower();
        }

        public string DeletePointMark(string text)
        {
            return text.Replace(".", ".\r\n" + DateTime.Now.ToString());
        }

        public string DeleteQuestionMark(string text)
        {
            return text.Replace("?", "?\r\n" + DateTime.Now.ToString());
        }

        public string DeleteExclamationMark(string text)
        {
            return text.Replace("!", "!\r\n" + DateTime.Now.ToString());
        }

        public string TimeStamp()
        {
            return DateTime.Now.ToString();
        }
    }

}
