using System;
using System.Runtime.CompilerServices;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Linq.Expressions;
using System.Numerics;

//++GLOBAL VARIBLES++
Random rand = new Random();
int[,] grid = new int[7,4];
int gridPosX = grid.GetLength(0) - 1;
int playerTurn = 1;
int cursorPosX = 0;
int cursorPosY = 0;

//Creates the grid
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

//Check user input to chose a column
while (true)
{
    var keyDetected = Console.ReadKey().KeyChar;
    switch (keyDetected)
    {
        //move left
        case 'a':
            cursorPosY--;
            break;
        //move right
        case 'd':
            cursorPosY++;
            break;
        //insert value
        case 'x':
            ChangeValue(grid, gridPosX, cursorPosY, playerTurn);
            playerTurn = ChangePlayer(playerTurn);
            break;
        default:
            break;
    }

    cursorPosY = (cursorPosY == -1) ? grid.GetLength(1)-1 : (cursorPosY % grid.GetLength(1));
    RenderGrid(grid, cursorPosX, cursorPosY);
    Console.WriteLine(playerTurn);
}

//aoi TODO list
//Fix the grid only functioning as intended when it's a square like 3x3 or 7x7
//but not when it's 3x7 or 7x3

//STOP MIXING UP X AND Y AXIS PUH-LEAAAASE

//Write an algorithm to detect the winning condition

/*
mrrp meow

  /\ /\
 (() ())
  /W W\
 /     \S
*/