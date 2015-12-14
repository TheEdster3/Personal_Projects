#include <iostream>
#include <algorithm>

using namespace std;

void getInput(string& palindrome)
{
    cout << "Please enter a word you would like to turn into a palindrome.\n\n";

    cin >> palindrome;
    cout << "\nPalindromes: " << endl;
}

void determinePalindrome(string& palindrome)
{

    for(int i = palindrome.length(), j = 0; i > 0 ; i--, j++)
    {

        string rev_palindrome = palindrome;

        reverse(rev_palindrome.begin(), rev_palindrome.end());
        string temp_rev = rev_palindrome;

        temp_rev = temp_rev.substr(0, j);
        reverse(temp_rev.begin(), temp_rev.end());

        if(rev_palindrome.substr(0, j) == temp_rev && j != 0)
        {
            cout << palindrome.substr(0, i) << rev_palindrome.substr(0, j) << rev_palindrome.substr(j, rev_palindrome.length());
            cout << endl;
        }
    }

    //cout << palindrome << rev_palindrome;
}

void run(string palindrome)
{
    getInput(palindrome);
    determinePalindrome(palindrome);

}

int main()
{
    string palindrome;
    run(palindrome);
    return 0;
}
