using System.Text;

string username = Console.ReadLine();

//Set Password to be reversed username
StringBuilder password = new StringBuilder();

for (int i = username.Length - 1; i >= 0; i--)
{
    password.Append(username[i]);
}

int invalidPassCounter = 0;

while (true)
{
    string guessPassword = Console.ReadLine();

    if (guessPassword == password.ToString())
    {
        Console.WriteLine($"User {username} logged in.");
        break;
    }
    else
    {
        invalidPassCounter++;

        if (invalidPassCounter >= 4)
        {
            Console.WriteLine($"User {username} blocked!");
            break;
        } else
        {
            Console.WriteLine("Incorrect password. Try again.");
        }
    }
}
