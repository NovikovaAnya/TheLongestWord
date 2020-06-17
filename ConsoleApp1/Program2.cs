using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 
namespace ConsoleApplication14
{
    class Program2
    {
        static void Main(string[] args)
        {
            Console.Write("Это приложение читает текст из файла и выводит самое длинное слово\n");
            string text = "";

            try
            {
               StreamReader read = new StreamReader(@"text.txt");
                text = read.ReadToEnd();
            read.Close();
            read.Dispose();
            }
            catch (Exception) {
                Console.Write("Такого файла не существует");
                return;
            }
            
            string[] str = text.Split(new Char[] { ' ', ',', '.', ':', '!', '?', ';', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            int maxlen = 0;
            string [] longest = new string [str.Length];
            int index = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].Length == maxlen) {
                    longest[index] = str[i];
                    ++index;
                }
                else if (str[i].Length > maxlen)
                {
                    index = 1;
                    longest[0] = str[i];
                    maxlen = longest[0].Length;
                }
            }

            Array.Resize(ref longest, index);

            if (maxlen == 0)
            {
                Console.Write("В этом тексте нет слов");
            }
            else {
                Console.Write("Самое длинное слово: {0}", string.Join(", ", longest));
            }

            Console.ReadLine();
        }
    }
}
 