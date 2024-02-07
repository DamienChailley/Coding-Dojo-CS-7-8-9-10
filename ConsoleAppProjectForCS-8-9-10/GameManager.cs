namespace ConsoleAppProjectForCS_8_9_10
{
    public class GameManager
    {
        private readonly List<Character> _charactersList = new();

        public GameManager()
        {
            // Faire le moins de traitement dans un constructeur.
            _charactersList = new(); // <= C# 9.
        }


        public void InitWorld()
        {
            // Attention, les records sont immutables => c'est-à-dire, on ne pas changer 
            // la valeur une fois qu'elle est donnée à un record..
            Hero SpiderMan = null;
            Hero IronMan = new("IronMan", 53, 10, 1200000, SpiderMan, CharacterClassEnum.Soldier); // <= C# 9.
            SpiderMan = new("SpiderMan", 23, 4, 20000, IronMan, CharacterClassEnum.Wizzard);

            _charactersList.Add(IronMan);
            _charactersList.Add(SpiderMan);

            _charactersList.Add(new Hero("Black Widow", 39, 4, 30000, null, CharacterClassEnum.Soldier));
            _charactersList.Add(new Villain("Bouffon vert", 50, 4, 100000, null, CharacterClassEnum.Soldier));
            _charactersList.Add(new Villain("Thanos", 1000, 5, 400000, null, CharacterClassEnum.Wizzard));
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
                Console.WriteLine(character.ToString());
                Console.WriteLine(string.Concat("Social status : ", ConvertScoreToStatus(character.Score)));
                Console.WriteLine(string.Concat("Incomes : ", ConvertOutcomeToIncomestatus(character.Incomes)));
                Console.WriteLine(GetCharacterInfo(character.CharacterClass));

                if (character.friend is Hero { Incomes: >= 1000000 } hero)  // <= C# 10 : pattern matching
                {
                    Console.WriteLine(string.Concat(character.Name, " is friend with ", hero.Name, " by interest?"));
                }
                else if (character.friend is Hero hero2)  // <= C# 8?
                {
                    Console.WriteLine(string.Concat(character.Name, " is friend with ", hero2.Name));
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
            return superHeroScore switch
            {
                > 0 and < 5 => "Not that famous",
                >= 5 and <= 9 => "Quiet famous",
                >= 10 => "Super famous",
                _ => "Unknown hero",
            };
        }

        private string ConvertOutcomeToIncomestatus(int outcome)
        {
            return outcome switch
            {
                > 0 and < 50000 => "Not rich",
                >= 50000 and <= 99999 => "Quiet rich",
                >= 100000 => "Super rich",
                _ => "No outcome info",
            };
        }

        // We could use a dictionary.. (best solution for C# 6).
        private string GetCharacterInfo(CharacterClassEnum characterClass)
        {
            return characterClass switch
            {
                CharacterClassEnum.Soldier => "Soldat",
                CharacterClassEnum.Warlock => "Enchanteur",
                CharacterClassEnum.Wizzard => "Magicien",
                CharacterClassEnum.None => "Aucune classe",
                _ => "Pas d'information sur la class de ce super héro.",
            };
        }
    }
}
