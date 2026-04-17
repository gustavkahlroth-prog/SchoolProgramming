/*
mrrp meow

  /\ /\
 (() ())
  /W W\
 /     \S
*/

using System;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq.Expressions;
using System.Numerics;

//++GLOBAL VARIBLES++
Random rand = new Random();
int[,] grid = new int[7, 7];
int playerTurn = 1;
int cursorPosX = 0;
int cursorPosY = 0;

//Fill the board
for (int i = 0; i < grid.GetLength(0); i++)
{
    for (int j = 0; j < grid.GetLength(1); j++)
    {
        grid[i, j] = 0;
    }
}

//Prints the board on screen
static void RenderGrid(int[,] grid, int posX, int posY)
{
    Console.Clear();

    for (int i = 0; i < grid.GetLength(0); i++)
    {
        for (int j = 0; j < grid.GetLength(1); j++)
        {
           if (posX == i && posY == j)
           {   
               Console.Write(">");
           }
           Console.Write(grid[i, j] + "\t");
        }
        Console.Write("\n");
    }
}

int gridPosY = grid.GetLength(1) - 1;
static void ChangeValue(int[,] grid, int posX, int posY, int playerTurn)
{
    //Uses some black magic to detect the lowest number on the selected column that is zero
    //And then replaces it with whatever player number
    if (grid[posX, posY] != 0)
    {
        posX--;
        ChangeValue(grid, posX, posY, playerTurn);
    }
    else
    {
        grid[posX, posY] = playerTurn;
    }
}

//Simple method to change which player's turn it is
static int ChangePlayer(int playerTurn)
{
    if (playerTurn == 1)
    {
        return 2;
    }
    else if (playerTurn == 2)
    {
        return 1;
    }
    else { return 0; }
}

RenderGrid(grid, cursorPosX, cursorPosY);

//Check user input To chose a column
while (true)
{
    var keyDetected = Console.ReadKey().KeyChar;
    switch (keyDetected)
    {
        case 'a':
            cursorPosY--;
            break;
        case 'd':
            cursorPosY++;
            break;
        case 'x':
            ChangeValue(grid, gridPosY, cursorPosY, playerTurn);
            playerTurn = ChangePlayer(playerTurn);
            break;
        default:
            break;
    }

    cursorPosY = (cursorPosY == -1) ? grid.GetLength(0)-1 : (cursorPosY % grid.GetLength(0));
    RenderGrid(grid, cursorPosX, cursorPosY);
    Console.WriteLine(cursorPosY);
}


//put user in turn´s number in the place over the first occupied one place
//Check winning condition
//Loop back