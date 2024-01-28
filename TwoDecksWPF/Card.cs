namespace TwoDecksWPF
{
    class Card
    {
        public Values Value { get; private set; }
        public Suits Suit { get; private set; }

        public readonly string Name;

        public override string ToString()
        {
            return Name;
        }

        public Card( Values value, Suits suit)
        {
            this.Value = value;
            this.Suit = suit;

            Name = $"{Value} of {Suit}";
        }
    }
}
