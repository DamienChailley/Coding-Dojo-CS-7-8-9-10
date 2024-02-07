using ConsoleAppProjectForCS_7;
using System;
using System.Collections.Generic;
using static ConsoleAppProjectForCS_7.Character;

namespace ConsoleAppProjectForCS_6
{
    public class GameManager
    {
        private readonly List<Character> _charactersList = new List<Character>();

        public GameManager()
        {
            // Faire le moins de traitement dans un constructeur.
            _charactersList = new List<Character>();
        }

        public void InitWorld()
        {
            var IronMan = new Hero("IronMan", 53, 10, 1200000, CharacterClassEnum.Soldier);
            Hero SpiderMan = new Hero("SpiderMan", 23, 4, 20000, CharacterClassEnum.Wizzard) { friend = IronMan };
            IronMan.friend = SpiderMan;

            _charactersList.Add(IronMan);
            _charactersList.Add(SpiderMan);

            _charactersList.Add(new Hero("Black Widow", 39, 4, 30000, CharacterClassEnum.Soldier));
            _charactersList.Add(new Villain("Bouffon vert", 50, 4, 100000, CharacterClassEnum.Soldier));
            _charactersList.Add(new Villain("Thanos", 1000, 5, 400000, CharacterClassEnum.Wizzard));
        }


        public void DisplayWorld()
        {
            //Display Character.
            PresentCharacters();
        }

        private void PresentCharacters()
        {
            _charactersList.ForEach(character =>
            {
                Console.Write(character.ToString());
                Console.WriteLine(string.Concat("Social status : ", ConvertScoreToStatus(character.Score)));
                Console.WriteLine(string.Concat("Incomes : ", ConvertOutcomeToOutcomeStatus(character.Incomes)));
                Console.WriteLine(GetCharacterInfo(character.CharacterClass));
                
                if (character.friend != null && (character.friend as Character) != null && (character.friend as Character).Incomes >= 1000000)
                {
                    Character friend = character.friend as Hero;
                    Console.WriteLine(string.Concat(character.Name, " is friend with ", friend.Name, " by interest?"));
                }
                else if (character.friend is Hero friend)
                {
                    Console.WriteLine(string.Concat(character.Name, " is friend with ", friend.Name));
                }
                else
                {
                    Console.WriteLine(string.Concat(character.Name, " doesn't have friend but it's okay. :)"));
                }
                Console.WriteLine("\n");
            });
        }

        private string ConvertScoreToStatus(int superHeroScore)
        {
            if (superHeroScore > 0 && superHeroScore < 5)
            {
                return "Not that famous";
            }
            else if (superHeroScore >= 5 && superHeroScore <= 9)
            {
                return "Quiet famous";
            }
            else if (superHeroScore >= 10)
            {
                return "Super famous";
            }
            else
            {
                return "Unknown hero";
            }
        }

        private string ConvertOutcomeToOutcomeStatus(int incomes)
        {
            if (incomes > 0 && incomes < 50000)
            {
                return "Not rich";
            }
            else if (incomes >= 50000 && incomes <= 99999)
            {
                return "Quiet rich";
            }
            else if (incomes >= 100000)
            {
                return "Super rich";
            }
            else
            {
                return "No outcome info";
            }
        }

        // We could use a dictionary.. (best solution for C# 6).
        private string GetCharacterInfo(CharacterClassEnum characterClass)
        {
            switch (characterClass)
            {
                case CharacterClassEnum.Soldier:
                    {
                        return "Soldat";
                    }
                case CharacterClassEnum.Warlock:
                    {
                        return "Enchanteur";
                    }
                case CharacterClassEnum.Wizzard:
                    {
                        return "Magicien";
                    }
                case CharacterClassEnum.None:
                    {
                        return "Aucune classe";
                    }
                default:
                    {
                        return "Pas d'information sur la class de ce super héro.";
                    }
            }
        }
    }
}
