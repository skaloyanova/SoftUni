using _08.TeamworkProjects;
using System.Text;

List<Team> teams = new();

// CREATE TEAMs

int numberOfTeams = int.Parse(Console.ReadLine());

for (int i = 0; i < numberOfTeams; i++)
{
    // Input format: {user}-{team}
    string[] teamCreateInput = Console.ReadLine().Split("-");
    string teamCreator = teamCreateInput[0];
    string teamName = teamCreateInput[1];

    // Team cannot be created more than once. Team creator cannot create more than 1 Team
    bool teamExists = IsTeamExistent(teamName, teams);
    bool creatorExists = IsCreatorExistent(teamCreator, teams);

    if (!creatorExists && !teamExists)
    {
        teams.Add(new Team(teamName, teamCreator));
        Console.WriteLine($"Team {teamName} has been created by {teamCreator}!");
    }
    else if (teamExists)
    {
        Console.WriteLine($"Team {teamName} was already created!");
    }
    else if (creatorExists)
    {
        Console.WriteLine($"{teamCreator} cannot create another team!");
    }
}

// JOIN TEAMs

string teamJoinInput = Console.ReadLine();

while (teamJoinInput != "end of assignment")
{
    // Input format: {user}->{team}
    string teamMember = teamJoinInput.Split("->")[0];
    string team = teamJoinInput.Split("->")[1];


    if (!IsTeamExistent(team, teams))           //User cannot join non-existent Team.
    {
        Console.WriteLine($"Team {team} does not exist!");
    }
    else if (IsUserExistent(teamMember, teams))   //Member of a team cannot join another team.
    {
        Console.WriteLine($"Member {teamMember} cannot join team {team}!");
    }
    else    // Join Team
    {
        var teamToJoin = teams.Find(t => t.Name == team);
        teamToJoin.Members.Add(teamMember);
    }

    teamJoinInput = Console.ReadLine();
}

// OUTPUT

// Print every team, ordered by the count of its members (descending) and then by name (ascending).
// For each team, you have to print its members sorted by name (ascending)  => this is done in Team class method ListTeamMembers()
teams
    .Where(t => t.Members.Count > 0)
    .OrderByDescending(t => t.Members.Count)
    .ThenBy(t => t.Name)
    .ToList()
    .ForEach(t => Console.WriteLine(t.ListTeamMembers()));

// Teams with zero members (with only a creator) should disband and you have to print them ordered by name in ascending order
Console.WriteLine("Teams to disband:");
teams
    .Where(t => t.Members.Count == 0)
    .OrderBy(t => t.Name)
    .ToList()
    .ForEach(t => Console.WriteLine(t.Name));


// Methods
bool IsTeamExistent(string teamName, List<Team> teams)
{
    return teams.Any(t => t.Name == teamName);
}

bool IsCreatorExistent(string teamCreator, List<Team> teams)
{
    return teams.Any(t => t.Creator == teamCreator);
}
bool IsUserExistent(string teamMember, List<Team> teams)
{
    return teams.Any(t => t.Members.Contains(teamMember)) || teams.Any(t => t.Creator.Contains(teamMember));
}

