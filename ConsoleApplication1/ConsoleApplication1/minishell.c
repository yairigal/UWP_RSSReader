#define _CRT_SECURE_NO_DEPRECATE
#include<stdio.h>
//#include<unistd.h>
#include<string.h>

char* readComm();
char** getCommArray(char* string, int * size);
void ExecuteFunction(char ** arr);

int main(int argc, char**argv) {
	int exit = 0;
	char*comm;
	char ** arr;
	int size;

	while (!exit) {
		printf("minishell> ");
		//comm = readNextCommand();
		comm = readComm();
		int size = strlen(comm);
		arr = getCommArray(comm, &size);
		//switch the function name
		if (!strcmp(arr[0], "exit"))
		{
			printf("The Father will Now Exit");
			return 1;
		}
		else
		{
			ExecuteFunction(arr);
		}
	}

}

//returns the next array.
char* readComm()
{
	char *line = malloc(80);
	fgets(line, 80, stdin);
	return line;
}

//returns the parameters array. - last one is NULL
//size returns the size of the array - with the name of the func
char** getCommArray(char* string, int * size)
{
	int i = 0;
	char * arr[20];
	char * curr;
	curr = strtok(string, " ");
	arr[i++] = curr;
	while (curr != "\n") {
		curr = strtok(NULL, " ");
		arr[i++] = curr;
	}
	arr[i] = NULL;
	size = i;
	return arr;
}

void ExecuteFunction(char ** arr)
{
	//the child - exec the func.
	if (fork() == 0)
	{
		execv(arr[0], arr);
	}
}
