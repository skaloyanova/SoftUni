// You will receive a key (integer) and n characters afterward.
// Add the key to each of the characters and append them to a message.
// At the end print the message, which you decrypted.

using System.Text;

int key = int.Parse(Console.ReadLine());
int n = int.Parse(Console.ReadLine());

StringBuilder decrypted = new();

for (int i = 0; i < n; i++)
{
    decrypted.Append((char)(char.Parse(Console.ReadLine()) + key));
}

Console.WriteLine(decrypted);