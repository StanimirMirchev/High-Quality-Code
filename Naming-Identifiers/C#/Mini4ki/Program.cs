namespace Mines
{   
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class Minesweeper
    {
        public class Ranking
        {
            private string name;
            private int points;

            public string Name
            {
                get
                {
                    return name;
                }

                set
                {
                    this.name = value;
                }
            }

            public int Points
            {
                get
                {
                    return points;
                }

                set
                {
                    this.points = value;
                }
            }

            public Ranking()
            {
            }

            public Ranking(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        private static void Main()
        {
            string command = string.Empty;
            char[,] field = create_game_field();
            char[,] bombs = createBombs();
            int counter = 0;
            bool explode = false;
            List<Ranking> champions = new List<Ranking>(6);
            int row = 0;
            int cow = 0;
            bool flag = true;
            const int maximum = 35;
            bool flag2 = false;

            do
            {
                if (flag)
                {
                    Console.WriteLine(
                        "Let's play Mine's game.Try your luck to find fields wothout bombs."
                        + " Command 'top' shows rating, 'restart' starts a new game, 'exit' close the game!");
                    dumpp(field);
                    flag = false;
                }

                Console.Write("Show row and cow : ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) && int.TryParse(command[2].ToString(), out cow)
                        && row <= field.GetLength(0) && cow <= field.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        Rating(champions);
                        break;
                    case "restart":
                        field = create_game_field();
                        bombs = createBombs();
                        dumpp(field);
                        explode = false;
                        flag = false;
                        break;
                    case "exit":
                        Console.WriteLine("See you soon!");
                        break;
                    case "turn":
                        if (bombs[row, cow] != '*')
                        {
                            if (bombs[row, cow] == '-')
                            {
                                OnTurn(field, bombs, row, cow);
                                counter++;
                            }

                            if (maximum == counter)
                            {
                                flag2 = true;
                            }
                            else
                            {
                                dumpp(field);
                            }
                        }
                        else
                        {
                            explode = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError!Invalid command!\n");
                        break;
                }

                if (explode)
                {
                    dumpp(bombs);
                    Console.Write("\nYou died with {0} points. " + "Enter your nickname: ", counter);
                    string nickname = Console.ReadLine();
                    Ranking player = new Ranking(nickname, counter);
                    if (champions.Count < 5)
                    {
                        champions.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < champions.Count; i++)
                        {
                            if (champions[i].Points < player.Points)
                            {
                                champions.Insert(i, player);
                                champions.RemoveAt(champions.Count - 1);
                                break;
                            }
                        }
                    }

                    champions.Sort((Ranking r1, Ranking r2) => r2.Name.CompareTo(r1.Name));
                    champions.Sort((Ranking r1, Ranking r2) => r2.Points.CompareTo(r1.Points));
                    Rating(champions);

                    field = create_game_field();
                    bombs = createBombs();
                    counter = 0;
                    explode = false;
                    flag = true;
                }

                if (flag2)
                {
                    Console.WriteLine("\nYou opened 35 fields without bombs.");
                    dumpp(bombs);
                    Console.WriteLine("Enter your name: ");
                    string name = Console.ReadLine();
                    Ranking points = new Ranking(name, counter);
                    champions.Add(points);
                    Rating(champions);
                    field = create_game_field();
                    bombs = createBombs();
                    counter = 0;
                    flag2 = false;
                    flag = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Good game!");
            Console.WriteLine("Goodbye!");
            Console.Read();
        }

        private static void Rating(List<Ranking> rankings)
        {
            Console.WriteLine("\nRankings:");
            if (rankings.Count > 0)
            {
                for (int i = 0; i < rankings.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} blocks", i + 1, rankings[i].Name, rankings[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranking list!\n");
            }
        }

        private static void OnTurn(char[,] gameField, char[,] bombs, int turn, int column)
        {
            char kolkoBombi = countMines(bombs, turn, column);
            bombs[turn, column] = kolkoBombi;
            gameField[turn, column] = kolkoBombi;
        }

        private static void dumpp(char[,] board)
        {
            int width = board.GetLength(0);
            int height = board.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < width; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < height; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        private static char[,] create_game_field()
        {
            int boardRows = 5;
            int boardColumns = 10;
            char[,] board = new char[boardRows, boardColumns];
            for (int i = 0; i < boardRows; i++)
            {
                for (int j = 0; j < boardColumns; j++)
                {
                    board[i, j] = '?';
                }
            }

            return board;
        }

        private static char[,] createBombs()
        {
            int rows = 5;
            int cows = 10;
            char[,] gameField = new char[rows, cows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cows; j++)
                {
                    gameField[i, j] = '-';
                }
            }

            List<int> mines = new List<int>();
            while (mines.Count < 15)
            {
                Random random = new Random();
                int randomNumber = random.Next(50);
                if (!mines.Contains(randomNumber))
                {
                    mines.Add(randomNumber);
                }
            }

            foreach (int mine in mines)
            {
                int cow = mine / cows;
                int row = mine % cows;
                if (row == 0 && mine != 0)
                {
                    cows--;
                    rows = cows;
                }
                else
                {
                    rows++;
                }

                gameField[cows, rows - 1] = '*';
            }

            return gameField;
        }

        private static void gameCalculations(char[,] field)
        {
            int cow = field.GetLength(0);
            int row = field.GetLength(1);

            for (int i = 0; i < cow; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (field[i, j] != '*')
                    {
                        char count = countMines(field, i, j);
                        field[i, j] = count;
                    }
                }
            }
        }

        private static char countMines(char[,] field, int currentRow, int currentCow)
        {
            int count = 0;
            int rows = field.GetLength(0);
            int cows = field.GetLength(1);

            if (currentRow - 1 >= 0)
            {
                if (field[currentRow - 1, currentCow] == '*')
                {
                    count++;
                }
            }

            if (currentRow + 1 < rows)
            {
                if (field[currentRow + 1, currentCow] == '*')
                {
                    count++;
                }
            }

            if (currentCow - 1 >= 0)
            {
                if (field[currentRow, currentCow - 1] == '*')
                {
                    count++;
                }
            }

            if (currentCow + 1 < cows)
            {
                if (field[currentRow, currentCow + 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCow - 1 >= 0))
            {
                if (field[currentRow - 1, currentCow - 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow - 1 >= 0) && (currentCow + 1 < cows))
            {
                if (field[currentRow - 1, currentCow + 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCow - 1 >= 0))
            {
                if (field[currentRow + 1, currentCow - 1] == '*')
                {
                    count++;
                }
            }

            if ((currentRow + 1 < rows) && (currentCow + 1 < cows))
            {
                if (field[currentRow + 1, currentCow + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}