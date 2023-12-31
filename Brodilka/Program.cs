﻿using System;

namespace Brodilka
{
    internal abstract class Program
    {
        private static void Main(string[] args)
        {
            Console.CursorVisible = false; 
            char[,] map =
            {
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'},
                { '#', ' ', '#', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'X', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', '#', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', '#', ' ', '#', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', '#', '#', '#', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', ' ', ' ', ' ', ' ', '#', ' ', ' ', 'X', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', 'X', ' ', ' ', ' ', '#', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '#'},
                { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#'}
            };

            int userX = 6, userY = 6;
            var bag = new char[1];

            while (true)
            {
                Console.SetCursorPosition(0, 20);
                Console.Write("Сумка: ");
                foreach (var t in bag)
                    Console.Write(t + " ");

                Console.SetCursorPosition(0, 0);
                for (var i = 0;  i < map.GetLength(0); i++)
                {
                    for (var j = 0; j < map.GetLength(1); j++)
                        Console.Write(map[i, j]);
                    Console.WriteLine();
                }

                Console.SetCursorPosition(userY, userX);
                Console.Write('@');
                var charKey = Console.ReadKey();
                switch (charKey.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (map[userX - 1, userY] != 'f')
                            userX--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (map[userX + 1, userY] != 'f')
                            userX++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (map[userX, userY - 1] != 'f')
                            userY--;
                        break;
                    case ConsoleKey.RightArrow:
                        if (map[userX, userY + 1] != 'f')
                            userY++;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (map[userX, userY] == 'X')
                {
                    map[userX, userY] = 'o';
                    var tempBag = new char[bag.Length + 1];
                    for (var i = 0; i < bag.Length; i++)
                        tempBag[i] = bag[i];
                    tempBag[tempBag.Length - 1] = 'X';
                    bag = tempBag;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
