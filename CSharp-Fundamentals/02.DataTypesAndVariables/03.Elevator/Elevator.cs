/*
 * Calculate how many courses will be needed to elevate n persons by using an elevator of the capacity of p persons.
 * The input holds two lines: the number of people n and the capacity p of the elevator.
 */

//INPUT
int people = int.Parse(Console.ReadLine());
int capacity = int.Parse(Console.ReadLine());

/* VAR 1 */

//int courses = people / capacity;

//if (people % capacity != 0)
//{
//    courses += 1;
//}

//Console.WriteLine(courses);

/* VAR 2 */

int courses = (int)Math.Ceiling((double) people / capacity);

Console.WriteLine(courses);