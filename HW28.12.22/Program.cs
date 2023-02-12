using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HW28._12._22
{
    delegate void Started();
    delegate void Finished();
    internal class Program
    {
        static void Main(string[] args)
        {
            // task 1
            //Race race = new Race(100);
            //race.OnStart(new List<Car> { new LightCar(), new HavyCar(), new Bus(), new RaceCar()});
            //race.Go();

            // task 2
            Player p1 = new Player("Ivan");
            Player p2 = new Player("Alex");
            Player p3 = new Player("Dasha");
            Game game = new Game(new List<Player> { p1, p2, p3 });
            game.StartGame();
        }
    }
    // task 1
    class Race
    {
        static event Started started;
        List<Car> cars;
        public static float _distance;
        public Race(int distance)
        {
            _distance = distance;
        }
        public void OnStart(List<Car> newCar)
        {
            cars = newCar;
            foreach (var e in cars)
            {
                started += e.Start;
            }
            started?.Invoke();
            Console.WriteLine();
        }
        public void Go()
        {
            bool flag = true;
            while (flag)
            {
                foreach (var e in cars)
                {
                    if (e.Move())
                    {
                        flag = false;
                        break;
                    }    
                        
                }
            }
            Car.OnFinish();
        }
    }
    abstract class Car
    {
        static public event Finished finished;
        protected float speed;
        public float currentDistance;
        public abstract void Start();
        public bool Move()
        {
            speed = new Random().Next(10, 200);
            currentDistance += speed / new Random().Next(30, 90);
            if (currentDistance >= Race._distance)
            {
                if (finished == null)
                    finished = Finish;
                return true;
            }
            return false;
        }
        public abstract void Finish();
        static public void OnFinish()
        {
            finished?.Invoke();
        }
    }
    class RaceCar : Car
    {
        public override void Finish()
        {
            Console.WriteLine("Гоночный автомобиль победил!");
        }

        public override void Start()
        {
            Console.WriteLine("Гоночный автомобиль на старте");
        }
    }
    class LightCar : Car
    {
        public override void Finish()
        {
            Console.WriteLine("Легковой автомобиль победил!");
        }

        public override void Start()
        {
            Console.WriteLine("Легковой автомобиль на старте");
        }
    }
    class HavyCar : Car
    {
        public override void Finish()
        {
            Console.WriteLine("Грузовой автомобиль победил!");
        }

        public override void Start()
        {
            Console.WriteLine("Грузовой автомобиль на старте");
        }
    }
    class Bus : Car
    {
        public override void Finish()
        {
            Console.WriteLine("Автобус победил!");
        }

        public override void Start()
        {
            Console.WriteLine("Автобус на старте");
        }
    }



    // task 2
    public enum DeckSuit
    {
        Hearts,
        Spades,
        Diamonds,
        Clubs
    }
    public enum DeckValue
    {
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }
    class Game
    {
        
        List <Player> players;
        List <Card> deck = new List<Card>();
        public Game(List<Player> players)
        {
            this.players = players;
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Six));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Seven));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Eight));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Nine));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Ten));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Jack));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Queen));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.King));
            deck.Add(new Card(DeckSuit.Hearts, DeckValue.Ace));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Six));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Seven));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Eight));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Nine));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Ten));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Jack));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Queen));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.King));
            deck.Add(new Card(DeckSuit.Spades, DeckValue.Ace));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Six));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Seven));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Eight));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Nine));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Ten));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Jack));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Queen));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.King));
            deck.Add(new Card(DeckSuit.Diamonds, DeckValue.Ace));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Six));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Seven));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Eight));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Nine));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Ten));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Jack));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Queen));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.King));
            deck.Add(new Card(DeckSuit.Clubs, DeckValue.Ace));
        }
        public void StartGame()
        {
            for (int i = 0; i < 3; i++)
                Shuffle();
            Distribution();
            while(players.Count > 1)
            {
                foreach (var player in players)
                    player.ShowDeck();
                Step();
                CheckFaled();
                ShufflePlayer();
                Console.WriteLine("------------------------------------");
            }
            Console.WriteLine($"победил игрок {players[0].name}");
            Console.ReadLine();
        }
        void Shuffle()
        {
            for (int i = 0; i < 36; i++)
            {
                int j = new Random().Next(36-i);
                var tmp = deck[i];
                deck[i] = deck[j];
                deck[j] = tmp;
            }
        }
        void Distribution()
        {
            for (int i = 0; i < deck.Count;)
            {
                for (int j = 0; j < players.Count; j++)
                {
                    if (i < deck.Count)
                        players[j].playerDeck.Add(deck[i++]);
                }
            }
        }
        Player Comparison(List<Card> tmp)
        {
            int max = 0;
            int index = 0;
            for (int i = 0; i < players.Count; i++)
            {
                if (tmp[i].value.GetHashCode() > max)
                {
                    max = tmp[i].value.GetHashCode();
                    index = i;
                }
            }
            return players[index];
        }
        void Step()
        {
            List<Card> tmp = new List<Card>();
            for (int j = 0; j < players.Count; j++)
            {
                tmp.Add(players[j].playerDeck[0]);
                players[j].playerDeck.Remove(players[j].playerDeck[0]);
            }
            Comparison(tmp).playerDeck.AddRange(tmp);

        }
        void CheckFaled()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].playerDeck.Count == 0)
                {
                    players.Remove(players[i]);
                    i--;
                }
            }
        }
        void ShufflePlayer()
        {
            List<Player> buf = new List<Player>();
            for (int i = 1; i < players.Count; i++)
            {
                buf.Add(players[i]);
            }
            buf.Add(players[0]);
            players = buf;
        }
    }
    class Player
    {
        public string name;
        public List<Card> playerDeck = new List<Card>();
        public Player(string name)
        {
            this.name = name;
        }
        public void ShowDeck()
        {
            Console.WriteLine(name);
            foreach (var e in playerDeck)
                Console.WriteLine(e.ToString());
            Console.WriteLine();
        }
    }
    class Card
    {
        public DeckSuit suit { get; }
        public DeckValue value { get; }
        public Card(DeckSuit suit, DeckValue value)
        {
            this.suit = suit;
            this.value = value;
        }
        public override string ToString()
        {
            return $"{suit} {value}";
        }
    }
}
