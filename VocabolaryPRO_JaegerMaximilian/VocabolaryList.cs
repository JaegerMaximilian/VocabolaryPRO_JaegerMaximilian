using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VocabolaryPRO_JaegerMaximilian
{
    class VocabolaryList
    {
        public List<Vocabolary> Vocabs = new List<Vocabolary>();

        public VocabolaryList(string VocabularyFilePath)
        {
            using (StreamReader sr = new StreamReader(VocabularyFilePath))
            {
                sr.ReadLine(); //to get rid of header
                int i = 1;
                while (sr.EndOfStream == false)
                {
                    string Line = sr.ReadLine();
                    string[] Data = Line.Split(';');
                    Vocabolary Voc = new Vocabolary(i, Data[0], Data[1]);
                    Vocabs.Add(Voc);
                    i++;
                }
            }
        }

        public void Print()
        {
            foreach (var voc in this.Vocabs)
            {
                Console.WriteLine(voc.ToString());
            }
        }

        public void Test(User user)
        {
            Vocabolary[] TestVocabs = Vocabs.Take(user.Index).ToArray();
            for (int i = 0; i < 5; i++)
            {
                Random rd = new Random();
                int randomIndex = rd.Next(0, user.Index);
                Vocabolary Word = TestVocabs[randomIndex];
                Console.WriteLine(Word.German);
                string Input = Console.ReadLine().ToLower();

                if (Word.English.ToLower() == Input)
                {
                    user.WordsRight += 1;
                    Console.WriteLine("Richtig!");
                }
                else
                {
                    user.WordsFalse += 1;
                    Console.WriteLine($"Falsch. Richtig wäre {Word.English}");
                }
                
            }
        }

        public void Learn(User user)
        {
            Vocabolary[] LearnVocabs = Vocabs.Skip(user.Index).Take(5).ToArray();
            foreach (var voc in LearnVocabs) Console.WriteLine(voc.ToString());
            Console.WriteLine("\nUnd jetzt gleich Prüfen...\n");
            for (int i = 0; i < 5; i++)
            {
                Random rd = new Random();
                int randomIndex = rd.Next(0, 4);
                //Console.WriteLine(randomIndex);
                Vocabolary Word = LearnVocabs[randomIndex];
                Console.WriteLine($"\n{Word.German}");
                string Input = Console.ReadLine().ToLower();

                if (Word.English.ToLower() == Input)
                {
                    user.WordsRight += 1;
                    Console.WriteLine("\nRichtig!");
                }
                else
                {
                    user.WordsFalse += 1;
                    Console.WriteLine($"\nFalsch. Richtig wäre '{Word.English}'");
                }

            }
            user.Index += 5;

        }
    }
}
