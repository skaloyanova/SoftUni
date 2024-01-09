/*
 * We are placing N orders at a time. You need to calculate the price with the following formula: ((daysInMonth * capsulesCount) * pricePerCapsule)
 * 
 * Input / Constraints
 * On the first line, you will receive integer N – the count of orders the shop will receive.
 * For each order you will receive the following information:
 *   Price per capsule – floating-point number in the range [0.00…1000.00].
 *   Days – integer in the range [1…31].
 *   Capsules count – integer in the range [0…2000].
 */


int ordersCnt = int.Parse(Console.ReadLine());
double totalCost = 0;

for (int i = 0; i < ordersCnt; i++)
{
    double capsulePrice = double.Parse(Console.ReadLine());
    int days = int.Parse(Console.ReadLine());
    int capsuleCnt = int.Parse(Console.ReadLine());

    double orderCost = (days * capsuleCnt) * capsulePrice;

    totalCost += orderCost;

    Console.WriteLine($"The price for the coffee is: ${orderCost:f2}");
}

Console.WriteLine($"Total: ${totalCost:f2}");