using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{

    internal class Player
    {
        List<Card> cards;
        string name;

        public List<Card> Deck { get => cards; }
        public string Name { get => name; set => ExceptionPropertyCatcher(ref name, value); }

        public Player(string name)
        {
            Name = name;
            cards = new List<Card>();
        }

        private void ExceptionPropertyCatcher(ref string name, string value)
        {
            try
            {
                if (value is null)
                    throw new ArgumentNullException();
                name = value;
            }
            catch(ArgumentNullException) { throw new ArgumentException(nameof(value) + " is null"); }
            catch(FormatException) { throw new FormatException(nameof(value) + " has incorrectly format"); }
        }
        public Card GiveRandomCard()
        {
            Random random = new Random();
            int indexCard = random.Next(cards.Count);

            Card tempCard = cards[indexCard];
            cards.RemoveAt(indexCard);

            return tempCard;
        }
        public Card GiveCardOfIndex(int indexCard)
        {
            Card tempCard = cards[indexCard];
            cards.RemoveAt(indexCard);

            return tempCard;
        }
        public void TakingDeckOfCards(Card[] cardArray)
        {
            try
            {
                cards.AddRange(cardArray);
            }
            catch (ArgumentNullException) { throw new ArgumentNullException(); }
            catch (FormatException) { throw new FormatException(); }
        }
        public void TakeOneCard(Card card)
        {
            try
            {
                cards.Add(card);
            }
            catch (ArgumentNullException) { throw new ArgumentNullException(); }
            catch (FormatException) { throw new FormatException(); }
        }
    }
}
