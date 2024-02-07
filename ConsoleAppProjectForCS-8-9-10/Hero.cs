namespace ConsoleAppProjectForCS_8_9_10
{
    public record Hero : Character
    {
        public Hero(string Name, int Age, int Score, int Incomes, object? Friend, CharacterClassEnum CharacterClass)
            : base(Name, Age, Score, Incomes, Friend, CharacterClass)
        { }
    }
}
