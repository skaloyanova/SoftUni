/*
 * Create a program that receives four integer numbers in the range [-2,147,483,648…2,147,483,647].
 * 
 * You should perform the following operations:
 *   Add first to the second.
 *   Divide (integer) the result of the first operation by the third number.
 *   Multiply the result of the second operation by the fourth number.
 *   
 * Print the result after the last operation.
 */

int n1 = int.Parse(Console.ReadLine());
int n2 = int.Parse(Console.ReadLine());
int n3 = int.Parse(Console.ReadLine());
int n4 = int.Parse(Console.ReadLine());

Console.WriteLine(((n1 + n2) / n3 ) * n4);