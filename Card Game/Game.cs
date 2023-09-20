using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card_Game
{
    static class Deck
    {
        static List<Card> MainDeck = new List<Card>()
        {
            // Heart cards
            new Card("hearts","six"),
            new Card("hearts","seven"),
            new Card("hearts","eight"),
            new Card("hearts","nine"),
            new Card("hearts","ten"),
            new Card("hearts","jack"),
            new Card("hearts","queen"),
            new Card("hearts","king"),

            // Spades cards
            new Card("spades","six"),
            new Card("spades","seven"),
            new Card("spades","eight"),
            new Card("spades","nine"),
            new Card("spades","ten"),
            new Card("spades","jack"),
            new Card("spades","queen"),
            new Card("spades","king"),

            // Diamonds cards
            new Card("diamonds","six"),
            new Card("diamonds","seven"),
            new Card("diamonds","eight"),
            new Card("diamonds","nine"),
            new Card("diamonds","ten"),
            new Card("diamonds","jack"),
            new Card("diamonds","queen"),
            new Card("diamonds","king"),

            // Diamonds cards
            new Card("clubs","six"),
            new Card("clubs","seven"),
            new Card("clubs","eight"),
            new Card("clubs","nine"),
            new Card("clubs","ten"),
            new Card("clubs","jack"),
            new Card("clubs","queen"),
            new Card("clubs","king")
        };

        public static List<Card> GetMainDeck()
        {
            return MainDeck;
        }
    }

    internal static class GameDisplay
    {
        static void ShowCards(List<Card> cards)
        {
            Console.WriteLine("All your own cards:\n");
            for (int i = 0; i < cards.Count; i++)
                Console.WriteLine($"{i} - {cards[i]}");
        }

        public static void DisplayPlayerMoveMenu(List<Card> cards, Player player)
        {
            Console.Clear();
            Console.WriteLine($"Player {player.Name} has a move!\n");
            Console.WriteLine("Choose your card:");
            ShowCards(cards);
        }

        public static void DisplayPlayerWinMenu(Player player, Card cardOne, Card cardTwo)
        {
            Console.Clear();
            Console.WriteLine($"Player {player.Name} has won in this lap!");
            Console.WriteLine($"He takes cards:\n{cardOne}\n{cardTwo}");
            Console.ReadKey();
        }
    }


    internal delegate bool EndDelegate(Player player);

    internal class Game
    {
        List<Player> _players;

        public Game(List<Player> players)
        {
            _players = players;
        }

        private Card[] CreateDeckForPlayer(ref List<Card> deck, int cardPerPlayer)
        {
            Random random = new Random();
            int randomIndex = 0;
            Card[] deckOfPlayer = new Card[cardPerPlayer];

            for (int i = 0; i < cardPerPlayer; i++)
            {
                randomIndex = random.Next(deck.Count());
                deckOfPlayer[i] = deck[randomIndex];
                deck.RemoveAt(randomIndex);
            }

            return deckOfPlayer;
        }
        private void GiveawayCards()
        {
            List<Card> deck = Deck.GetMainDeck();
            int cardsPerPlayer = deck.Count()/_players.Count();

            foreach(Player player in _players)
                player.TakingDeckOfCards(CreateDeckForPlayer(ref deck, cardsPerPlayer));
        }


        private Card ComparePlayersCards(Card player1Card, Card player2Card)
        {
            if (player1Card > player2Card)
                return player1Card;

            else if (player1Card < player2Card)
                return player2Card;

            throw new Exception();
        }
        private int PlayerCardChoice(Player player)
        {
            List<Card> playerDeck = player.Deck;

            GameDisplay.DisplayPlayerMoveMenu(playerDeck,player);
            int indexOfCard = Convert.ToInt32(Console.ReadLine());
            return indexOfCard;
        }
        private void PlayersMoves(Player player1, Player player2) 
        {
            int cardIndex1 = PlayerCardChoice(player1);
            int cardIndex2 = PlayerCardChoice(player2);

            Card player1Card = player1.GiveCardOfIndex(cardIndex1);
            Card player2Card = player2.GiveCardOfIndex(cardIndex2);

            if (ComparePlayersCards(player1Card, player2Card) == player1Card)
            {
                GameDisplay.DisplayPlayerWinMenu(player1, player2Card, player1Card);

                player1.TakeOneCard(player1Card);
                player1.TakeOneCard(player2Card);
            }
            else
            {
                GameDisplay.DisplayPlayerWinMenu(player2, player2Card, player1Card);

                player2.TakeOneCard(player1Card);
                player2.TakeOneCard(player2Card);
            }

        }
        private bool CheckCountCards(Player player)
        {
            if(player.Deck.Count == 0)
                return true;
            return false;
        }
        private int ChangeTurnIndex(int turnIndex)
        {
            if (turnIndex + 2 == _players.Count())
                turnIndex = 0;
            else
                turnIndex++;

            return turnIndex;
        }
        private void Playing()
        {
            int turnIndex = 0;
            
            while (!CheckCountCards(_players[turnIndex]))
            {
                PlayersMoves(_players[turnIndex], _players[turnIndex + 1]);
                turnIndex = ChangeTurnIndex(turnIndex);
            }
        }


        public void Main()
        {
            GiveawayCards();
            Playing();
        }
    }
}
