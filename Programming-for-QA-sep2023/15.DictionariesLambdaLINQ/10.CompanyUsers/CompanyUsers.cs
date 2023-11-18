/*
 * INPUT
 * Until you receive the "End" command, you will be receiving input in the format: "{companyName} -> {employeeId}".
 * The input always will be valid.
 * 
 * LOGIC
 * Add each employee to the given company. Keep in mind that a company cannot have two employees with the same id.
 */

Dictionary<string, HashSet<string>> employees = new();

string[] input = Console.ReadLine().Split(" -> ");

while (input[0] != "End")
{
    string companyName = input[0];
    string employeeID = input[1];

    if (!employees.ContainsKey(companyName))
    {
        employees.Add(companyName, new HashSet<string>());
    }

    employees[companyName].Add(employeeID);

    input = Console.ReadLine().Split(" -> ");
}

/*
 * OUTPUT
 * print the company's name and each employee's id in the following format:
 *   {companyName}
 *   -- {id1}
 *   -- {id2}
 *   -- {idN}
 */

foreach (KeyValuePair<string, HashSet<string>> pair in employees)
{
    Console.WriteLine(pair.Key);
    Console.WriteLine(string.Join(Environment.NewLine, pair.Value.Select(e => $"-- {e}")));
}