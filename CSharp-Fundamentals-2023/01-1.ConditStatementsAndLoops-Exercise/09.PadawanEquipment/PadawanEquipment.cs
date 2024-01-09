/*
 * Yoda is starting his newly created Jedi academy. So, he asked master John to buy the needed equipment. 
 * The number of items depends on how many students will sign up. The equipment for each Padawan contains: Lightsaber, Belt and Robe
 * 
 * You will be given the amount of money John has, the number of students and the prices of each item. 
 * Calculate if John has enough money to buy equipment for each Padawan or how much more money he needs.
 * 
 * There are some additional requirements:
 *  - Lightsabres sometimes break, so John should buy 10% more (taken from the students' count), rounded up to the next integer.
 *  - Every sixth belt is free.
 */


//INPUT
double money = double.Parse(Console.ReadLine());        //[0.00…1000.00]
int studentsCount = int.Parse(Console.ReadLine());      //[0…100]
double saberPrice = double.Parse(Console.ReadLine());   //[0.00…100.00]
double robePrice = double.Parse(Console.ReadLine());    //[0.00…100.00]
double beltPrice = double.Parse(Console.ReadLine());    //[0.00…100.00]

//LOGIC
double costForSabers = Math.Ceiling(studentsCount * 1.1) * saberPrice;
double costForRobes = studentsCount * robePrice;

int freeBeltsCount = studentsCount / 6;
double costForBelts = (studentsCount - freeBeltsCount) * beltPrice;

double totalCost = costForSabers + costForRobes + costForBelts;

//OUTPUT
if (money >= totalCost)
{
    Console.WriteLine($"The money is enough - it would cost {totalCost:f2}lv.");
}
else
{
    Console.WriteLine($"John will need {(totalCost - money):f2}lv more.");
}