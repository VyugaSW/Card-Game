using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    internal class Card
    {
        string _suit;
        string _type;

        public Card(string suit, string type) 
        { 
            Suit = suit;
            Type = type;
        }

        public string Suit 
        { 
            get => _suit ; 
            set => ExceptionCatcher(ref _suit, value); 
        }
        public string Type 
        { 
            get => _type; 
            set => ExceptionCatcher(ref _type, value); 
        }

        public static bool operator >(Card cardOne, Card cardTwo)
        {
            return RateCardType(cardOne.Type) > RateCardType(cardTwo.Type);
        }
        public static bool operator <(Card cardOne, Card cardTwo)
        {
            return RateCardType(cardOne.Type) < RateCardType(cardTwo.Type);
        }
        public static bool operator ==(Card cardOne, Card cardTwo)
        {
            return RateCardType(cardOne.Type) == RateCardType(cardTwo.Type);
        }
        public static bool operator !=(Card cardOne, Card cardTwo)
        {
            return RateCardType(cardOne.Type) != RateCardType(cardTwo.Type);
        }

        public override string ToString()
        {
            return $"{_suit} {_type}";
        }
        public static int RateCardType(string type)
        {
            switch (type)
            {
                case "six":
                    return 1;
                case "seven":
                    return 2;
                case "eight":
                    return 3;
                case "nine":
                    return 4;
                case "ten":
                    return 5;
                case "jack":
                    return 6;
                case "queen":
                    return 7;
                case "king":
                    return 8;
                case "ace":
                    return 9;
               default: 
                    return 0;
            }
            throw new Exception();
        }
        private void ExceptionCatcher<T>(ref string field, T value)
        {
            try { field = Convert.ToString(value); }
            catch (FormatException) { throw new FormatException(); }
            catch (NullReferenceException) { throw new NullReferenceException(); }
            catch (Exception) { throw new Exception(); }
        }
    }
}
