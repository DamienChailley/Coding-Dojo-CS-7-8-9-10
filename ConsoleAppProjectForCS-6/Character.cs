using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppProjectForCS_7
{
    public class Character
    {
        public enum CharacterClassEnum
        {
            None,
            Wizzard,
            Soldier,
            Warlock,
        };

        public string Name { get; private set; }
        public int Age { get; set; }
        public int Incomes { get; set; }
        public int Score { get; set; }

        public CharacterClassEnum CharacterClass { get; set; }

        // yes,yes only one friend. Oh and yes an object, can be like a VR headset for example. (for the purpose of the dojo).
        // to show (if is.. statement)...
        public object friend { get; set; }

        public Character(string name, int age, int score, int incomes, CharacterClassEnum characterClass)
        {
            Name = name;
            Age = age;
            Incomes = incomes;
            Score = score;
            CharacterClass = characterClass;
        }

        public override string ToString()
        {
            return string.Concat(Name, ", ", Age, "yo, ", Incomes, "$, ", Score, ". ");
        }
    }
}
