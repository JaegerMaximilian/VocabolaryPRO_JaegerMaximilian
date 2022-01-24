using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabolaryPRO_JaegerMaximilian
{
    class User
    {
        public string Username { get; set; }
        public string Password { get; private set; }
        public int WordsRight { get; set; }
        public int WordsFalse { get; set; }
        public int Index { get; set; } //at what vocabolary-index the user stands
        public int UserLine { get; private set;} //in which line of the csv the user is

        public User() { }
        
        public User(string username, string password, int wordsright, int wordsfalse, int index, int userline)
        {
            Username = username;
            Password = password;
            WordsRight = wordsright;
            WordsFalse = wordsfalse;
            Index = index;
            UserLine = userline;
        }

        public void PrintUser ()
        {
            Console.WriteLine($" Username: {Username}\n\nRichtige Wörter  Falsche Wörter [%]");
            double WordsSum = WordsRight + WordsFalse;
            double RightInLines = WordsRight / WordsSum * 10;
            double FalseInLines = WordsFalse / WordsSum * 10;
            for (int i = 0; i < 10; i++)
            {
                if (RightInLines > i) Console.Write("    |");
                if (FalseInLines > i) Console.Write("                   |");
                Console.Write("\n");
            }
            Console.Write($"\n Gelernte Wörter bisher: {Index}\n\n");
            
        }

    }
}
