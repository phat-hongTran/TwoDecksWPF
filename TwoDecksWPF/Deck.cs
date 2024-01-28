using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDecksWPF
{
    class Deck : ObservableCollection<Card>
    {
        private static Random random = new Random();
        public Deck()
        {
            Reset();
        }
        public void Reset()
        {
            /* Call Clear() to remove all cards from the deck, then use two for loops to add
            * all combinations of suit and value, calling Add(new Card(...)) to add each card */
            Clear();
            for (int suit = 0; suit <= 3; suit++)
                for (int value = 1; value <= 13; value++)
                    Add(new Card((Values)value, (Suits)suit));
        }
        public Card Deal(int index)
        {
            // Use base[index] to pull out the specific card and RemoveAt(index) to remove it
            Card card = base[index] as Card;
            base.RemoveAt(index);
            return card;
        }
        public void Shuffle()
        {
            /* Use new List<Card>(this) to create a copy of the deck, then pick a random card
            * from copy, call copy.RemoveAt to remove it, and Add(card) to add it */
            List<Card> cards = new List<Card>(this);
            Clear();
            while (cards.Any())
            {
                int index = random.Next(cards.Count);
                Card card = cards[index] as Card;
                cards.RemoveAt(index);
                Add(card);
            }
        }
        public void Sort()
        {
            List<Card> sortedCards = new List<Card>(this);
            sortedCards.Sort(new CardComparerByValue());
            Clear();
            foreach (var item in sortedCards)
            {
                Add(item);
            }
        }
    }
}
