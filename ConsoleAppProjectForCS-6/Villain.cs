using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProjectForCS_7
{
    public class Villain : Character
    {
        public Villain(string name, int age, int score, int incomes, CharacterClassEnum characterClass)
            : base(name, age, score, incomes, characterClass) { }
    }
}
