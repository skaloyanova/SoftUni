using System.Diagnostics;

int peopleCount = int.Parse(Console.ReadLine());
string groupType = Console.ReadLine();  //Students, Business or Regular
string day = Console.ReadLine();        //Friday, Saturday or Sunday

double pricePerPerson = 0.0;

//Defining pricing table

if (groupType == "Students")
{
    switch (day)
    {
        case "Friday": pricePerPerson = 8.45; break;
        case "Saturday": pricePerPerson = 9.80; break;
        case "Sunday": pricePerPerson = 10.46; break;
    }
}
else if (groupType == "Business")
{
    switch (day)
    {
        case "Friday": pricePerPerson = 10.90; break;
        case "Saturday": pricePerPerson = 15.60; break;
        case "Sunday": pricePerPerson = 16; break;
    }
}
else if (groupType == "Regular")
{
    switch (day)
    {
        case "Friday": pricePerPerson = 15; break;
        case "Saturday": pricePerPerson = 20; break;
        case "Sunday": pricePerPerson = 22.50; break;
    }
}

//Defining discount

if (groupType == "Students" && peopleCount >= 30)
{
    pricePerPerson = pricePerPerson * 0.85; // 15% discount
}
else if (groupType == "Business" && peopleCount >= 100)
{
    peopleCount = peopleCount - 10;     // 10 people will stay for free
}
else if (groupType == "Regular" && peopleCount >= 10 && peopleCount <= 20)
{
    pricePerPerson = pricePerPerson * 0.95; // 5% discount
}

double totalCost = peopleCount * pricePerPerson;

Console.WriteLine($"Total price: {totalCost:f2}");