using System.Threading;

char[] spaces = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
int player = 1;
int choice;
int flag;


/// <summary>
///  Draws the game board
/// </summary>

void DrawBoard()
{
    Console.WriteLine("\t     |     |     ");
    Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", spaces[0], spaces[1], spaces[2]);
    Console.WriteLine("\t_____|_____|_____");
    Console.WriteLine("\t     |     |     ");
    Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", spaces[3], spaces[4], spaces[5]);
    Console.WriteLine("\t_____|_____|_____");
    Console.WriteLine("\t     |     |     ");
    Console.WriteLine("\t  {0}  |  {1}  |  {2}  ", spaces[6], spaces[7], spaces[8]);
    Console.WriteLine("\t     |     |     ");
}

/// <summary>
/// Checks if the game was won, tied, or should continue
/// </summary>

int CheckWin()
{
    if (spaces[0] == spaces[1] &&
        spaces[1] == spaces[2] || //row 1
        spaces[3] == spaces[4] &&
        spaces[4] == spaces[5] || //row 2
        spaces[6] == spaces[7] &&
        spaces[7] == spaces[8] || //row 3

        spaces[0] == spaces[3] &&
        spaces[3] == spaces[6] || //column 1
        spaces[1] == spaces[4] &&
        spaces[4] == spaces[7] || //column 2
        spaces[2] == spaces[5] &&
        spaces[5] == spaces[8] || //column 3

        spaces[0] == spaces[4] &&
        spaces[4] == spaces[8] || //diagonal 1
        spaces[2] == spaces[4] &&
        spaces[4] == spaces[6]  ) return 1; //diagonal 2

    else if (spaces[0] != '1' &&
             spaces[1] != '2' &&
             spaces[2] != '3' &&
             spaces[3] != '4' &&
             spaces[4] != '5' &&
             spaces[5] != '6' &&
             spaces[6] != '7' &&
             spaces[7] != '8' &&
             spaces[8] != '9'  ) return -1;

    else return 0;
}


/// <summary>
/// Draws an X on the game board
/// </summary>

void DrawX(int pos) => spaces[pos] = 'X';


/// <summary>
/// Draws an O on the game board
/// </summary>

void DrawO(int pos) => spaces[pos] = 'O';


/// <summary>
/// The main game loop
/// </summary>

do
{
    Console.Clear();
    Console.WriteLine("Player 1: X and Player 2: O\n");
    
    if (player % 2 == 0) Console.WriteLine("Player 2's turn");
    else Console.WriteLine("Player 1's turn");

    Console.WriteLine("\n\n\n");
    DrawBoard();
    Console.WriteLine("\n\n\n\t\t\t");
    
    choice = int.Parse(Console.ReadLine()) - 1;

    if (spaces[choice] != 'X' && spaces[choice] != 'O')
    {
        if (player % 2 == 0) DrawO(choice);
        
        else DrawX(choice);
        
        player++;
    }
    else
    {
        Console.WriteLine("The space is already marked with a symbol. Now wait 10 seconds so you can think about your actions.");
        Thread.Sleep(10000);
    }

    flag = CheckWin();

} while (flag != 1 && flag != -1);

Console.Clear();
DrawBoard();

if (flag == 1) Console.WriteLine("\n\n\nPlayer {0} has won! (absolutely nothing)", (player % 2) + 1);

else Console.WriteLine("\n\n\nTIE GAME!!!");