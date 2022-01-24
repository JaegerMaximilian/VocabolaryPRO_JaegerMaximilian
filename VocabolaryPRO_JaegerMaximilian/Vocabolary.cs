using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocabolaryPRO_JaegerMaximilian
{
    class Vocabolary
    {
        //public int TimesCorrect { get; set; }
        //public int TimesFalse { get; set; }
        public int Index { get; private set; }
        public string English { get; private set; }
        public string German { get; private set;}

        public Vocabolary(int index, string english, string german)
        {
            Index = index;
            English = english;
            German = german;
        }
        public override string ToString()
        {
            return $"{English} | {German}";
        }
    }
}
