int n = int.Parse(Console.ReadLine());

int tankLiters = 0;

while (n > 0)
{
    int liters = int.Parse(Console.ReadLine());

    if (liters > (255 - tankLiters))
    {
        Console.WriteLine("Insufficient capacity!");
        n--;
        continue;
    }

    tankLiters += liters;

    n--;
}

Console.WriteLine(tankLiters);