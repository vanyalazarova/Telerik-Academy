﻿using System;
/*
 * Write a program that fills and prints a matrix of size (n, n) as shown below: (examples for n = 4)
 * 
 */
class FillAndPrintMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int N = int.Parse(Console.ReadLine());
        var array = new int[N,N];
        int num = 1;
        Console.WriteLine("Enter a,b,c or d:");
        char switchIt = char.Parse(Console.ReadLine());
        // switch case for problem a,b,c,d
        switch (switchIt)
        { 
            case 'a':
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (j < 1)
                        {
                            array[i, j] = i + 1;
                        }
                        else
                        {
                            array[i, j] = array[i, j - 1] + N;
                        }
                    }
                }
                break;

            case 'b':
                for (int j = 0; j < N; j++)
                {
                    if (j % 2 == 0)
                    {
                        for (int i = 0; i < N; i++)
                        {
                            array[i, j] = num;
                            num++;
                        }
                    }
                    else
                    {
                        //for every odd line switches the output
                        for (int i = N - 1; i >= 0; i--)
                        {
                            array[i, j] = num;
                            num++;
                        }
                    }
                }
                break;

            case 'c':
                int startRow = N - 1;
                int startCol = 0;
                int row = N - 1;
                int col = 0;
                array[startRow, startCol] = 1;
                while (num < N * N)
                {
                    //for the first part which goes to the middle of the matrix
                    //decrease row
                    if (col < N - 1)
                    {
                        startRow--;
                        startCol = 0;
                        row = startRow;
                        col = startCol;
                        num++;
                        array[row, col] = num;
                        //while it reaches to the middle of matrix
                        while (row < N -1)
                        {
                            row++;
                            col++;
                            num++;
                            array[row, col] = num;
                        }
                    }
                    //when it reaches to the middle
                    //increase collumn
                    else
                    {
                        startRow = 0;
                        startCol ++;
                        row = startRow;
                        col = startCol;
                        num++;
                        array[row, col] = num;
                        //while it reaches end of matrix
                        while (col < N - 1)
                        {
                            row++;
                            col++;
                            num++;
                            array[row, col] = num;
                        }
                    }
                }
                break;
        
            case 'd':
                string direction = "down";
                int currentRow = 0;
                int currentCol = 0;

                for (int i = 0; i < N * N; i++)
                {
                    if (direction == "down" && (currentRow >= N || array[currentRow,currentCol] != 0))
                    {
                        currentRow--;
                        currentCol++;
                        direction = "right";
                    }
                    else if (direction == "right" && (currentCol >= N || array[currentRow,currentCol] != 0))
                    {
                        currentRow--;
                        currentCol--;
                        direction = "up";
                    }
                    else if (direction == "up" && (currentRow < 0  || array[currentRow,currentCol] != 0))
                    {
                        currentRow++;
                        currentCol--;
                        direction = "left";
                    }
                    else if (direction == "left" && (currentCol < 0 || array[currentRow,currentCol] != 0))
                    {
                        currentRow++;
                        currentCol++;
                        direction = "down";
                    }

                    array[currentRow, currentCol] = num;
                    num++;
                    if (direction == "down")
                    {
                        currentRow++;
                    }
                    else if (direction == "right")
                    {
                        currentCol++;
                    }
                    else if (direction == "up")
                    {
                        currentRow--;
                    }
                    else if (direction == "left")
                    {
                        currentCol--;
                    }
                }
                break;
        }
        
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(array[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}