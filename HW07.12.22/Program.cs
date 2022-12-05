using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HW07._12._22
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Game.TicTacToe game = new Game.TicTacToe();
            // true - игра с ии
            // false - 2 игрока
            //game.Play(false);

            Translater.MorzeTranslater mt = new Translater.MorzeTranslater();
            Console.WriteLine(mt.ToString(".--. .-. .. .-- . -   -- .. .-. --..--"));
            Console.WriteLine(mt.ToMorze("Привет мир!"));
        }
    }
}

namespace Game
{
    class TicTacToe
    {
        Player currentPlayer;
        char[,] backgroundField = new char[5, 5] { { ' ', '|', ' ', '|', ' ' }, { '-', '|', '-', '|', '-' }, { ' ', '|', ' ', '|', ' ' }, { '-', '|', '-', '|', '-' }, { ' ', '|', ' ', '|', ' ' } };
        char[,] gameField = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
        string[] combinations = new string[5];

        public void Play(bool mode)
        {
            Player p1;
            Player p2;
            if (mode)
            {
                bool turn = QueueDefinition();
                if (turn)
                {
                    p1 = new Player('X', "Player");
                    p2 = new Player('O', "AI");
                }
                else
                {
                    p1 = new Player('X', "AI");
                    p2 = new Player('O', "Player");
                }
            }
            else
            {
                p1 = new Player('X', "Player 1");
                p2 = new Player('O', "Player 2");
            }

            currentPlayer = p1;

            Draw();

            int result;

            while ((result = CheckEnd())==0)
            {
                Move(currentPlayer);
                Console.Clear();
                Draw();
                SwithPlayer(p1, p2);
            }

            SwithPlayer(p1, p2);

            if (result==1)
                Console.WriteLine($"{currentPlayer.name} win!");
            else
                Console.WriteLine($"draw!");
            Console.ReadLine();
        }

        bool QueueDefinition()
        {
            int rand = new Random().Next(2);
            bool turn = true;
            if (rand == 0)
                turn = false;
            return turn;
        }

        void Draw()
        {
            Console.WriteLine();
            for (int i=0, m=0; i< backgroundField.GetLength(0);i++)
            {
                Console.Write(' ');
                for (int j=0, n=0;j< backgroundField.GetLength(1);j++)
                {
                    if (i % 2 == 0 && j % 2 == 0)
                    {
                        Console.Write(gameField[m, n++]);
                        continue;
                    }
                    Console.Write(backgroundField[i,j]);
                }
                if (i % 2 == 0) m++;
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        int CheckEnd()
        {
            for (int i=0;i<combinations.Length;i++)
            {
                combinations[i] = "";
            }
            string buf;
            string standoff = "";

            for (int i = 0; i < gameField.GetLength(0); i++)
            {
                buf = "";
                combinations[0] += gameField[i, 0];
                combinations[1] += gameField[i, 1];
                combinations[2] += gameField[i, 2];
                for (int j = 0; j < gameField.GetLength(1); j++)
                {
                    buf += gameField[i, j];
                    standoff += gameField[i, j];
                    if (i == j)
                        combinations[3] += gameField[i, j];
                    if ((i == 0 && j == 2) || (i == 1 && j == 1) || (i == 2 && j == 0))
                        combinations[4] += gameField[i, j];
                }
                if (buf == "XXX" || buf == "OOO")
                    return 1;
            }

            if (!(standoff.Contains(" ")))
                return 2;

            for (int i = 0; i < combinations.Length; i++)
            {
                if (combinations[i] == "OOO" || combinations[i] == "XXX") return 1;
            }

            return 0;
        }

        void Move(Player p)
        {
            int i;
            int j;
            if (p.name == "AI")
            {
                while (true)
                {
                    Randomize(out i, out j);
                    if (gameField[i, j] == ' ')
                    {
                        gameField[i, j] = p.symbol;
                        break;
                    }
                    Console.Clear();
                    Draw();
                }
            }
            else
            {
                while (true)
                {
                    i = int.Parse(Console.ReadLine());
                    j = int.Parse(Console.ReadLine());
                    if (gameField[i, j] == ' ')
                    {
                        gameField[i, j] = p.symbol;
                        break;
                    }
                    Console.Clear();
                    Draw();
                }
            }
        }

        void SwithPlayer(Player p1, Player p2)
        {
            if (currentPlayer == p2)
                currentPlayer = p1;
            else currentPlayer = p2;
        }

        void Randomize(out int i, out int j)
        {
            Random random= new Random();

            i = random.Next(3);
            j = random.Next(3);
        }
    }

    class Player
    {
        public string name;
        public char symbol;
        public Player(char symbol, string name)
        {
            this.symbol = symbol;
            this.name = name;
        }
    }
}

namespace Translater
{
    class MorzeTranslater
    {
        string [] morze = new string[] { ".-", "-...", ".--", "--.", "-..", ".", "...-", "--..", "..", ".---", "-.-", ".-..", "--", "-.", "---", ".--.", ".-.", "...", "-", "..-", "..-.",
                                        "....", "-.-.", "---.", "----", "--.-", "--.--", "-.--", "-..-", "..-..", "..--", ".-.-", ".----", "..---", "...--", "....-", ".....", "-....",
                                        "--...", "---..", "----.", "-----", "......", ".-.-.-", "--..--", "..--..", " "};
        char[] symbols = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь',
                                    'э', 'ю', 'я', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', ',', '!', '?', ' '};

        public string ToMorze(string text)
        {
            text = text.ToLower();
            string result = "";
            for (int i=0; i<text.Length; i++)
            {
                for (int j = 0; j < symbols.Length; j++)
                {
                    if (symbols[j] == text[i])
                    {
                        result += morze[j];
                        result += ' ';
                        break;
                    }
                }
            }
            return result;
        }
        public string ToString(string morze)
        {
            string result = "";
            string tmp = "";
            bool space = false;
            for (int i = 0; i < morze.Length; i++)
            {
                if (morze[i] != ' ')
                    tmp += morze[i];
                else
                {
                    for (int j = 0; j < this.morze.Length; j++)
                    {
                        if (tmp == this.morze[j])
                        {
                            result += symbols[j];
                            if (morze[i + 1] == ' ' && morze[i + 2] == ' ')
                                result += ' ';
                            break;
                        }
                    }
                    tmp = "";
                }
            }
            for (int j = 0; j < this.morze.Length; j++)
            {
                if (tmp == this.morze[j])
                {
                    result += symbols[j];
                    break;
                }
            }
            return result;
        }
    }
}