using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VocabolaryPRO_JaegerMaximilian
{
    class Interface
    {
        public User User { get; private set; }
        public string UserFilePath { get; private set; }
        

        public Interface (string userfilepath)
        {
            UserFilePath = userfilepath;
        }
        public void Login()
        {
            bool LoggedIn = false;
            while (LoggedIn == false)
            {
                switch (InputToInt("----------------\n   Login-Page \n---------------- \n[1] Login \n[2] Register ", 2))
                {
                    case 1: //log in with existing data
                        using (StreamReader sr = new StreamReader(UserFilePath))
                        {
                            string Username = InputToString("Username:");
                            string Password = InputToString("Password");
                            int i = 0;
                            while (sr.EndOfStream == false)
                            {
                                string Line = sr.ReadLine();
                                string[] LineData = Line.Split(';');

                                if (LineData[0] == Username && LineData[1] == Password)
                                {
                                    LoggedIn = true;
                                    int WordsRight;
                                    int WordsFalse;
                                    int Index;
                                    int.TryParse(LineData[2], out WordsRight);
                                    int.TryParse(LineData[3], out WordsFalse);
                                    int.TryParse(LineData[4], out Index);
                                    User = new User(LineData[0], LineData[1], WordsRight, WordsFalse, Index, i) ;
                                }
                                i++;

                            }
                        }
                        break;
                    case 2: //generate new data
                        int LineIndex = File.ReadAllLines(UserFilePath).Length; //z.B. bei 10 Zeilen mit Kopfzeile ist 11. Zeile neuer User
                        Console.WriteLine(LineIndex);
                        User = new User(InputToString("Username:"), InputToString("Passwort:"),0,0,0,LineIndex);
                        using (StreamWriter sw = new StreamWriter(UserFilePath, true))
                        {
                            sw.WriteLine($"{User.Username};{User.Password};0;0;0");
                        }
                        LoggedIn = true;
                        break;
                }
            }


        }

        public void Run(VocabolaryList vocabs)
        {
            bool Exit = false;
            while (Exit == false)
            {
                switch (InputToChoice("\n[1]Bereits gelernte Vokabeln prüfen\n[2]Neue Vocabeln lernen\n[3]Statistiken\n[4]Exit", 4))
                {
                    case 1: // test
                        if (User.Index != 0) vocabs.Test(User);
                        else Console.WriteLine("\nSie müssen zuerst Wörter lernen\n");
                        break;
                    case 2: //learn
                        vocabs.Learn(User);
                        break;
                    case 3: //statistics
                        User.PrintUser();
                        break;
                    case 4:
                        Exit = true;
                        break;
                }
                string[] lines = File.ReadAllLines(UserFilePath);
                lines[User.UserLine] = $"{User.Username};{User.Password};{User.WordsRight};{User.WordsFalse};{User.Index}";/* replace with whatever you need */
                File.WriteAllLines(UserFilePath, lines);
            }
        }
        static int InputToChoice(string message, int Choices)
        {
            int ReturnValue;
            do
            {
                Console.WriteLine(message);
            } while (!int.TryParse(Console.ReadLine(), out ReturnValue) && ReturnValue > Choices);
            return ReturnValue;
        }
        static int InputToInt(string Message, int MaximumInt)
        {
            int OutputInt = 0;

            do
            {
                Console.WriteLine(Message);
            } while (!int.TryParse(Console.ReadLine(), out OutputInt) || OutputInt < 1 || OutputInt > MaximumInt);
            return OutputInt;
        }
        static string InputToString(string Message)
        {
            Console.WriteLine(Message);
            return Console.ReadLine();
        }
    }
}
