﻿using System;

namespace Maze.Logic
{
    public class MyMaze
    {
        private char[,] _maze;

        public MyMaze(int n, int obstacles)
        {
            N = n;
            Obstacles = obstacles;
            _maze = new char[N, N];
            FillMaze();
            Solution();
        }

        public int N { get; }

        public int Obstacles { get; }

        public override string ToString()
        {
            var output = string.Empty;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    output += $"{_maze[i, j]}";
                }
                output += "\n";
            }
            return output;
        }

        private void FillMaze()
        {
            FillBorders();
            FillObstacles();
        }

        private void FillObstacles()
        {
            var random = new Random();
            int obstaclesCount = 0;
            do
            {
                var i = random.Next(1, N - 1);
                var j = random.Next(1, N - 1);
                if (!(i == 1 && j == 1 || i == N - 2 && j == N - 2))
                {
                    if (_maze[i , j] == ' ')
                    {
                        _maze[i, j] = '█';
                        obstaclesCount++;
                    }
                }
            } while (obstaclesCount < Obstacles);
        }

        private void FillBorders()
        {
            for (int i = 0; i < N; i++)
            {
                _maze[0, i] = '█';
            }
            for (int i = 0; i < N - 1; i++)
            {
                _maze[1, i] = ' ';
            }

            _maze[1, N - 1] = '█';
            for (int i = 2; i < N - 2; i++)
            {
                _maze[i, 0] = '█';
                for (int j = 1; j < N - 1; j++)
                {
                    _maze[i, j] = ' ';
                }
                _maze[i, N - 1] = '█';
            }
            _maze[N - 2, 0] = '█';
            for (int i = 1; i < N; i++)
            {
                _maze[N - 2, i] = ' ';
            }

            for (int i = 0; i < N; i++)
            {
                _maze[N - 1, i] = '█';
            }
        }

        public void Solution()
        {
            var i = 1;
            var j = 0;
            _maze[i, j] = '→';
            do
            {

                if (_maze[i, j + 1] == ' ' && _maze[i, j] != '←')
                {
                    _maze[i, j] = '→';
                    j++;
                }
                else if (_maze[i + 1, j] == ' ')
                {
                    _maze[i, j ] = '↓';
                    i++;
                }
                else if (_maze[i, j - 1] != '█')
                {
                    _maze[i, j] = '←';
                    j--;
                }
                else if (_maze[i, j] == '←')
                {
                    if (_maze[i + 1, j] == ' ')
                    {
                        _maze[i, j] = '↓';
                        i++;
                    }
                    else if (_maze[i, j] == '←' && _maze[i - 1, j] != '█')
                    {
                        _maze[i, j] = '←';
                        j--;
                    }
                }
                
                    else break;
            } while (j != N - 1 && i != N - 1);

            //do
            //{
            //    // Mueve el marcador hacia la derecha si la siguiente celda a la derecha está vacía y no es la celda de regreso
            //    if (_maze[i, j + 1] == ' ' && _maze[i, j] != '←')
            //    {
            //        j++;
            //        _maze[i, j] = '→';

            //    }
            //    // Mueve el marcador hacia abajo si la siguiente celda debajo está vacía
            //    else if (_maze[i + 1, j] == ' ')
            //    {
            //        i++;
            //        _maze[i, j] = '↓';

            //    }
            //    // Mueve el marcador hacia la izquierda si la siguiente celda a la izquierda está vacía y no es la celda de regreso
            //    else if (_maze[i, j - 1] == ' ')
            //    {
            //        _maze[i, j] = '←';
            //        j--;
            //    }
            //    // Si la celda de regreso es '←', mueve el marcador hacia abajo si la siguiente celda debajo está vacía
            //    else if (_maze[i, j] == '←')
            //    {
            //        if (_maze[i + 1, j] == ' ')
            //        {
            //            i++;
            //            _maze[i, j] = '↓';

            //        }
            //        // Si la celda de regreso es '←' y la siguiente celda a la izquierda está vacía, mueve el marcador hacia la izquierda
            //        else if (_maze[i, j] == '←' && _maze[i, j - 1] == ' ')
            //        {
            //            j--;
            //            _maze[i, j] = '←';

            //        }
            //    }
            //    // Si no se puede mover en ninguna dirección, sale del bucle
            //    else
            //    {
            //        break;
            //    }
            //} while (j != N && i != N - 1);
        }
    }
}