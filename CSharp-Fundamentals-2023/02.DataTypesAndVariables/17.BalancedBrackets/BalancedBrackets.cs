// Your task is to find out if the brackets are balanced.
// That means after every closing bracket should follow an opening one.
// Nested parentheses are not valid and if two consecutive opening brackets exist, the expression should be marked as unbalanced.

// On the first line, you will receive n – the number of lines, which will follow.
// On the next n lines, you will receive '(', ')' or another string.

int n = int.Parse(Console.ReadLine());
bool isBalanced = true;
string prevBracket = "";

for (int i = 0; i < n; i++)
{
    string input = Console.ReadLine();

    switch (input)
    {
        case "(":
            if (prevBracket == ")" || prevBracket == "")
            {
                prevBracket = input;
            }
            else if (prevBracket == "(")
            {
                isBalanced = false;
            }
            break;
        case ")":
            if (prevBracket == "(")
            {
                prevBracket = input;
            }
            else if (prevBracket == ")" || prevBracket == "")
            {
                isBalanced = false;
            }
            break;
        default: break;
    }

    if (isBalanced == false)
    {
        break;
    }
}

Console.WriteLine((isBalanced && prevBracket == ")") ? "BALANCED" : "UNBALANCED");
