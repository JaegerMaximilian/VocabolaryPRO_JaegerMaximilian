using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabolaryPRO_JaegerMaximilian
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n --- Willkommen bei vocabularyPRO! --- \n");
            Interface INTERFACE = new Interface(@"..\..\files\User.csv");
            INTERFACE.Login();
            VocabolaryList Vocabs = new VocabolaryList(@"..\..\files\Vocabolary.csv");
            INTERFACE.Run(Vocabs);
        }
    }
}
