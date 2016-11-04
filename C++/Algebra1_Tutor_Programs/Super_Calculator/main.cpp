#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <sstream>
#include <string>

using namespace std;

void UserPrompt();
void Adder();
void MultiAdder();
void missingVariable();

int main(int argc, char **argv)
{
    UserPrompt();
	return 0;
} //Runs user prompt

void clearConsole()
{
    cout << "\033[2J\033[1;H";
}

void UserPrompt()
{
    string option = "";
    while(option != "exit")
    {
        cout << "Enter the number of what you would like to do." << endl;
        cout << "Algebra One Material:" << endl;
        cout << "1. Add two numbers" << endl;
        cout << "2. Add multiple numbers" << endl;
        cout << "3. Determine missing variable" << endl;
        /*cout << "4. Apply the Quadratic Formula" << endl;
        cout << "5. Factor a polynomial" << endl;
        cout << "6. Solve Systems of Linear Equations" << endl << endl;
        cout << "Trigonometry Material:" << endl;
        cout << "7. " << endl << endl;
        */
        cout << endl;
        cout << "type exit to quit." << endl;
        cout << endl;
        
        getline(cin, option);
        clearConsole(); //Clears the console on linux machines

        if(option == "1")
        {
            Adder();
        }
        else if(option == "2")
        {
            MultiAdder();
        }
        else if(option == "3")
        {
            missingVariable();
        }
        clearConsole();
    }
    cout << "Thanks for using!" << endl;
} //Handles options for user input

void Adder()
{
    int x, y;
    cout << "Enter two numbers seperated by a space" << endl;
    cin >> x >> y;
    if(x == NULL || y == NULL)
        cout << "Error parsing input" << endl;
    else
        cout << (x + y) << endl;
        
    cin.clear();
    cout << "Press ENTER to continue..." << endl;
    getchar();
    getchar();
    
} // Adds two numbers

void MultiAdder()
{
    string numbers;
    int i = 0;
    int total = 0;
    
    cout << "Enter multiple numbers seperated by spaces" << endl;
    
    getline(cin, numbers);
    stringstream ss(numbers);
    
    while(ss)
    {
        total += i; //SUGAAAARRRR
        ss >> i;

    }
    
    cout << total << endl;
    cout << "Press ENTER to continue..." << endl;
    getchar();
    //clearConsole();
} // Adds two numbers

void missingVariable()
{
    string numbers;
    string equation;
    string tempHolder;
    int givenNumberX = 0;
    int givenNumberY = 0;
    int givenNumberZ = 0;
    
    
    cout << "Enter a string of the format X + Y = Z leaving one as a variable" << endl;
    
    getline(cin, numbers);
    stringstream ss(numbers);
    ss >> equation;
    if(equation == "X")
    {
        ss >> tempHolder; //Plus sign
        ss >> givenNumberY; //number in position Y
        ss >> tempHolder; //Equal sign
        ss >> givenNumberZ;
        cout << "X = " << (givenNumberZ - givenNumberY) << endl;
    }
    else
    {
        givenNumberX = atoi(equation.c_str()); //Number given for X
        ss >> tempHolder; //Plus sign
        ss >> equation; //Number in Y position
    }
    if(equation == "Y")
    {
        ss >> tempHolder; //Equals sign
        ss >> givenNumberZ; //Get Z value
        cout << "Y = " << (givenNumberZ - givenNumberX) << endl;
    }
    else
    {
        givenNumberY = atoi(equation.c_str()); //Number given for Y
        ss >> tempHolder; //Equal sign
        ss >> equation; //Number in Z position
    }
    if(equation == "Z")
    {
        cout << "Z = " << givenNumberX + givenNumberY << endl;
    }
    cout << "Press ENTER to continue..." << endl;
    getchar();
}

void readInput()
{
    
}
