using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProjectForCS_8_9_10
{
    public record Villain : Character
    {
        public Villain(string Name, int Age, int Score, int Incomes, object? Friend, CharacterClassEnum CharacterClass)
            : base(Name, Age, Score, Incomes, Friend, CharacterClass)
        { }
    }
}
