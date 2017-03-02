#include<iostream>
using namespace std;


const int SIZE = 3;
const char x = 'X';
const char o = 'O';

//checking if the pc can win instantlly.
bool ifCanWinRow(char board[][SIZE], int row)
{
	int c = 0;
	for (int i = 0; i < 3; i++)
		if (board[row][i] == o)
			c++;
	//if there are 2 circles in this row
	if (c == 2)
	{
		for (int i = 0; i < 3; i++)
		{
			if (board[row][i] == x)
				return false;
			else if (board[row][i] == ' ')
				return true;
		}
	}
	return false;
}
bool ifCanWinCol(char board[][SIZE], int col)
{
	int c = 0;
	for (int i = 0; i < 3; i++)
		if (board[i][col] == o)
			c++;
	//if there are 2 circles in the col
	if (c == 2)
		for (int i = 0; i < 3; i++)
		{
			if (board[i][col] == x)
				return false;
			else if (board[i][col] == ' ')
				return true;
		}
	return false;
}
bool ifCanWinDiag(char board[][SIZE])
{
	//first diagnal.
	if (board[0][0] == o && board[1][1] == o && board[2][2] == ' ')
		return true;
	else if (board[0][0] == o && board[2][2] == o && board[1][1] == ' ')
		return true;
	else if (board[1][1] == o && board[2][2] == o && board[0][0] == ' ')
		return true;
	//second diagnal
	if (board[0][2] == o && board[1][1] == o && board[2][0] == ' ')
		return true;
	else if (board[0][2] == o && board[2][0] == o && board[1][1] == ' ')
		return true;
	else if (board[2][0] == o && board[1][1] == o && board[0][2] == ' ')
		return true;

	return false;
}
void WinRow(char board[][SIZE], int row)
{
	for (int i = 0; i < SIZE; i++)
		if (board[row][i] == ' ')
		{
			board[row][i] = o;
			break;
		}
}
void WinCol(char board[][SIZE], int col)
{
	for (int i = 0; i < SIZE; i++)
		if (board[i][col] == ' ')
		{
			board[i][col] = o;
			break;
		}
}
void WinDiagnal(char board[][SIZE])
{
	//first diagnal.
	if (board[0][0] == o  && board[1][1] == o && board[2][2] == ' ')
		board[2][2] = o;
	else if (board[0][0] == o && board[2][2] == o && board[1][1] == ' ')
		board[1][1] = o;
	else if (board[1][1] == o && board[2][2] == o && board[0][0] == ' ')
		board[0][0] = o;
	//second diagnal.
	if (board[0][2] == o  && board[1][1] == o && board[2][0] == ' ')
		board[2][0] = o;
	else if (board[0][2] == o && board[2][0] == o && board[1][1] == ' ')
		board[1][1] = o;
	else if (board[2][0] == o && board[1][1] == o && board[0][2] == ' ')
		board[0][2] = o;
}
//if the PC placed a circle and won this returns true, else false.
bool ifWon(char board[][SIZE])
{
	for (int i = 0; i < SIZE; i++)
	{
		for (int j = 0; j < SIZE; j++)
		{
			//if can win in a row.
			if (ifCanWinRow(board, i))
			{
				WinRow(board, i);
				return true;
			}
			else if (ifCanWinCol(board, j))
			{
				WinCol(board, j);
				return true;
			}
			else if (ifCanWinDiag(board))
			{
				WinDiagnal(board);
				return true;
			}
		}
	}
	return false;
}
//checking if the PC even need to block this spot. and if he can place in the spot.
bool ifBlockRow(char board[][SIZE], int row)
{
	int c = 0;
	for (int i = 0; i < 3; i++)
		if (board[row][i] == x)
			c++;

	if (c == 2)
	{
		for (int i = 0; i < 3; i++)
		{
			if (board[row][i] == o)
				return false;
			else if (board[row][i] == ' ')
				return true;
		}
	}
	return false;
}
bool ifBlockCol(char board[][SIZE], int col)
{
	int c = 0;
	for (int i = 0; i < 3; i++)
		if (board[i][col] == x)
			c++;

	if (c == 2)
		for (int i = 0; i < 3; i++)
		{
			if (board[i][col] == o)
				return false;
			else if (board[i][col] == ' ')
				return true;
		}
	return false;
}
bool ifBlockDiagnal(char board[][SIZE])
{
	//first diagnal.
	if (board[0][0] == x && board[1][1] == x && board[2][2] == ' ')
		return true;
	else if (board[0][0] == x && board[2][2] == x && board[1][1] == ' ')
		return true;
	else if (board[1][1] == x && board[2][2] == x && board[0][0] == ' ')
		return true;
	//second diagnal
	if (board[0][2] == x && board[1][1] == x && board[2][0] == ' ')
		return true;
	else if (board[0][2] == x && board[2][0] == x && board[1][1] == ' ')
		return true;
	else if (board[2][0] == x && board[1][1] == x && board[0][2] == ' ')
		return true;

	return false;
}
//when we know that there are 2 x in the row the computer blocks it.
void blockRow(char board[][SIZE], int row)
{
	//blocking the row.
	for (int i = 0; i < 3; i++)
		if (board[row][i] != x)
		{
			board[row][i] = o;
			break;
		}
}
void blockCol(char board[][SIZE], int col)
{
	//blocking the row.
	for (int i = 0; i < 3; i++)
		if (board[i][col] != x)
		{
			board[i][col] = o;
			break;
		}
}
void blockDiagnal(char board[][SIZE])
{
	//first diagnal.
	if (board[0][0] == x  && board[1][1] == x && board[2][2] == ' ')
		board[2][2] = o;
	else if (board[0][0] == x && board[2][2] == x && board[1][1] == ' ')
		board[1][1] = o;
	else if (board[1][1] == x && board[2][2] == x && board[0][0] == ' ')
		board[0][0] = o;
	//second diagnal.
	if (board[0][2] == x  && board[1][1] == x && board[2][0] == ' ')
		board[2][0] = o;
	else if (board[0][2] == x && board[2][0] == x && board[1][1] == ' ')
		board[1][1] = o;
	else if (board[2][0] == x && board[1][1] == x && board[0][2] == ' ')
		board[0][2] = o;
}
//the pc places a circle.
void settingCircle(char board[][SIZE])
{
	bool ifBreak = true;
	for (int i = 0; i < SIZE && ifBreak; i++)
	{
		for (int j = 0; j < SIZE; j++)
		{
			if (board[i][j] == o)
				//right
			{
				if (j + 1 < 3)
					if (board[i][j + 1] == ' ')
					{
						board[i][j + 1] = o;
						break;
						ifBreak = false;
					}
				//left
					else if (j - 1 > -1 && board[i + 1][j] == ' ')
					{
						board[i][j - 1] = o;
						break;
						ifBreak = false;
					}
				//up
					else if (i - 1 > -1 && board[i - 1][j] == ' ')
					{
						board[i - 1][j] = o;
						break;
						ifBreak = false;
					}
				//down
					else if (i + 1 < 3 && board[i + 1][j] == ' ')
					{
						board[i + 1][j] = o;
						break;
						ifBreak = false;
					}
			}
		}
	}
}
void signSwap(char &sign)
{
	if (sign == x)
		sign = o;
	else
		sign = x;
}

void printBoard(char board[][SIZE], int row, int col)
{
	int a[3][3] = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

	cout << endl;
	for (int i = 0; i < SIZE; i++)
	{
		cout << "   " << board[i][0];
		for (int j = 1; j < SIZE; j++)
		{
			cout << " | " << board[i][j];
		}
		cout << "     " << "   " << a[i][0];
		for (int k = 1; k < SIZE; k++)
		{
			cout << " | " << a[i][k];
		}
		if (!(i == SIZE - 1))
			cout << endl << "   ---------        ---------" << endl;
	}
	cout << endl << endl;
}
bool checkRow(char board[][SIZE], char sign)
{
	int count = 0;
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			if (board[i][j] == sign)
				for (int k = 0; k < 3; k++)
					if (board[i][k] == sign)
						count++;
			if (count == 3)
				return true;
			else
				count = 0;
		}
	}
	return false;
}
bool checkCol(char board[][SIZE], char sign)
{
	int count = 0;
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			if (board[i][j] == sign)
				for (int k = 0; k < 3; k++)
					if (board[k][j] == sign)
						count++;
			if (count == 3)
				return true;
			else
				count = 0;
		}
	}
	return false;
}
bool checkDiag(char board[][SIZE], char sign)
{
	int count = 0;
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			if (i == j)
			{
				if (board[0][0] == sign && board[1][1] == sign && board[2][2] == sign)
					return true;
			}
			else
				if (i + j == 2)
					if (board[0][2] == sign && board[1][1] == sign && board[2][0] == sign)
						return true;
		}
	}
	return false;
}
bool check(char board[][SIZE], char sign)
{
	if (checkRow(board, sign) || checkCol(board, sign) || checkDiag(board, sign))
		return true;
	return false;
}
void PvP(int count, char CurSign, int sign[], char board[][SIZE])
{
	while (count < 9)
	{
		if (count % 2 == 0)
			CurSign = x;
		else
			CurSign = o;

		cout << "player " << count % 2 + 1 << ": "; // announcing the player's turn
		cin >> sign[count % 2]; // input of the number of the spot.

		while (*(*board + sign[count % 2] - 1) == x || *(*board + sign[count % 2] - 1) == o)//if the spot if taken
		{
			cout << "this place is already taken !" << endl;
			cin >> sign[count % 2];
		}
		while (sign[count % 2] > 9 || sign[count % 2] < 1)
		{
			cout << "its not an available spot ! choose another number :" << endl;
			cin >> sign[count % 2];
		}

		if (count % 2 == 0) // placing the x or o in their spot
			*(*board + sign[count % 2] - 1) = x;
		else
			*(*board + sign[count % 2] - 1) = o;



		printBoard(board, 3, 3); // print board after the placement.

		if (check(board, CurSign)) // checking if someone in winning.
		{
			cout << "player " << count % 2 + 1 << " Won !" << endl;
			break;
		}
		count++;
	}
}
void PvPC(char board[][SIZE], int count)
{
	switch (count)
	{
	case 1:

		if (board[1][1] == x)
		{
			switch (count)
			{
			case 0: board[0][0] = o;
				break;
			case 1: board[0][2] = o;
				break;
			case 2:board[2][0] = o;
				break;
			case 3:board[2][2] = o;
				break;
			}
		}
		else
			board[1][1] = o;

		break;
	case 3:
	case 5:
	case 7:
	case 9:
		//searching if he can win first , if cant he will try to block or place next to circle.
		if (ifWon(board))
			break;

		bool ifPlaced = false;
		//trying to block the x , and if not , placing a circle.
		for (int i = 0; i < SIZE && !ifPlaced; i++)
		{
			for (int j = 0; j < SIZE; j++)
			{
				ifPlaced = false;
				//if there are 2 x in a row , we block them.
				if (ifBlockRow(board, i))
				{
					blockRow(board, i);
					ifPlaced = true;
					break;
				}
				//if there are 2 x in a col we block them.
				else if (ifBlockCol(board, j))
				{
					blockCol(board, j);
					ifPlaced = true;
					break;
				}
				// if there are 2x in the diagnal.
				else if (ifBlockDiagnal(board))
				{
					blockDiagnal(board);
					ifPlaced = true;
					break;
				}
			}//col for
		}//row for
		 //if there is nothing to block , setting up a cricle
		if (!ifPlaced)
			settingCircle(board);
		break;
	}
}




int main()
{
	char CurSign = x;
	bool playerTurn = true;
	bool ifContinue = true;
	int count = 0, sign[2], input;
	int a = NULL;
	char board[3][3] = { { ' ', ' ', ' ' },
	{ ' ', ' ', ' ' },
	{ ' ', ' ', ' ' } };
	bool comTurn = false;
	do {
		ifContinue = false;
		cout << "enter 1 to play against a player \n   or 2 to play against the PC" << endl;
		cin >> input;
		//playing against the PC
		if (input == 2)
		{
			cout << "enter the number you want to place X :" << endl;
			printBoard(board, SIZE, SIZE);
			while (count < 9)
			{
				//player turn
				if (playerTurn)
				{
					//starting turn
					cout << "player turn :" << endl;
					cin >> sign[0];

					//cheking for errors.
					while (*(*board + sign[0] - 1) == x || *(*board + sign[0] - 1) == o)//if the spot if taken
					{
						cout << "this place is already taken !" << endl;
						cin >> sign[0];
					}
					while (sign[0] > 9 || sign[0] < 1)
					{
						cout << "its not an available spot ! choose another number :" << endl;
						cin >> sign[0];
					}
					//done checking errors.
					//placing the sign into its spot.
					*(*board + sign[0] - 1) = x;
				}//done player turn

				 //starting com turn.
				else if (!playerTurn)
					PvPC(board, count);

				//printing the board.
				if (count % 2 == 1)
					printBoard(board, 3, 3);
				//checking for someone if he wins.
				if (check(board, CurSign)) // checking if someone in winning.
				{
					printBoard(board, SIZE, SIZE);
					if (count % 2 == 0)
						cout << "player's wins !\n\n" << endl;
					else
						cout << "PC wins !\n\n" << endl;

					break;
				}
				signSwap(CurSign);
				count++;
				playerTurn = !playerTurn;
			}//while
		}
		//playing against the player
		else if (input != 2)
		{
			cout << "enter the number you want to place your mark" << endl << endl;
			printBoard(board, 3, 3);
			//from here the player part.
			PvP(count, CurSign, sign, board);
			//to here.
		}
		if (count == 9) // if the board is full
		{
			printBoard(board, SIZE, SIZE);
			cout << "\n\nNo winner" << endl;
		}

		cout << "\n\ndo you want to play again? press any number :" << endl;
		cin >> a;
		if (a != NULL)
		{
			//resetting the board.
			for (int i = 0; i < SIZE; i++)
				for (int j = 0; j < SIZE; j++)
					board[i][j] = ' ';


			ifContinue = true;
			CurSign = x;
			count = 0;
			playerTurn = true;
			a = NULL;
		}

	} while (ifContinue);
	system("pause");
}
