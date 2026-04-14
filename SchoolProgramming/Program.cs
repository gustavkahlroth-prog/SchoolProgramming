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
bool playerTurn = false;
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
           if (posY == i && posX == j)
           {   
               Console.Write(">");
           }
           Console.Write(grid[i, j] + "\t");
        }
        Console.Write("\n");
    }
}

//Changes value of the selected number
static void ChangeValue(int[,] grid, int posX, int posY)
{
    grid[grid.GetLength(0)-1, posX] = 1;
}


RenderGrid(grid, cursorPosX, cursorPosY);

//Check user input To chose a column
while (true)
{
    var keyDetected = Console.ReadKey().KeyChar;
    switch (keyDetected)
    {
        case 'a':
            cursorPosX--;
            break;
        case 'd':
            cursorPosX++;
            break;
        case 'x':
            ChangeValue(grid, cursorPosX, cursorPosY);
            break;
        default:
            break;
    }

    cursorPosX = (cursorPosX == -1) ? grid.GetLength(0)-1 : (cursorPosX % grid.GetLength(0));
    cursorPosY = (cursorPosY == -1) ? grid.GetLength(1)-1 : (cursorPosY % grid.GetLength(1));
    RenderGrid(grid, cursorPosX, cursorPosY);
    Console.WriteLine(cursorPosX);
    Console.WriteLine(cursorPosY);
}
//helo guys
//Find the deppest slot in the column that does NOT contain a 0 (or is last),
//put user in turn´s number in the place over the first occupied one place
//Check winning condition
//Loop back