/* 
* Create a program that reads an article in the following format "{title}, {content}, {author}".
* On the next line, you will receive a number n, representing the number of commands, which will follow after it. 
* On the next n lines, you will be receiving the following commands: 
*   "Edit: {new content}"
*   "ChangeAuthor: {new author}"
*   "Rename: {new title}"
* In the end, print the final state of the article.
*/

using _07.Articles;

string[] articleSplit = Console.ReadLine().Split(", ");

var article = new Article(articleSplit[0], articleSplit[1], articleSplit[2]);

int numberOfCommands = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfCommands; i++)
{
    string[] commandSplit = Console.ReadLine().Split(": ");
    string command = commandSplit[0];
    string update = commandSplit[1];

    switch(command)
    {
        case "Edit": article.Edit(update); break;
        case "ChangeAuthor": article.ChangeAuthor(update); break;
        case "Rename": article.Rename(update); break;
    }
}

Console.WriteLine(article);