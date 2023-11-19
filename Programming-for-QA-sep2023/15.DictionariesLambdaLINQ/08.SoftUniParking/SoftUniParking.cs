/*
 * The program receives 2 commands:
 *     - "register {username} {licensePlateNumber}" 
 *     - "unregister {username}"
 */

Dictionary<string, string> parking = new();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] input = Console.ReadLine().Split();

    string command = input[0];
    string username = input[1];

    if (command == "register")
    {
        string lpn = input[2];

        try
        {
            parking.Add(username, lpn);
            Console.WriteLine($"{username} registered {lpn} successfully");
        }
        catch (Exception)
        {
            Console.WriteLine($"ERROR: already registered with plate number {parking[username]}");
        }
    }
    else if (command == "unregister")
    {
        bool isUnregistered = parking.Remove(username);

        if (isUnregistered)
        {
            Console.WriteLine($"{username} unregistered successfully");
        }
        else
        {
            Console.WriteLine($"ERROR: user {username} not found");
        }
    }
}

// print all of the currently registered users and their license plates in the format: "{username} => {licensePlateNumber}"
parking.Select(x => $"{x.Key} => {x.Value}").ToList().ForEach(x => Console.WriteLine(x));
