/*
 * Create a program, which emulates typing an SMS, following this guide (multiple pressing one and the same button for next letter)
 * 1
 * 2 - abc  //offset 0
 * 3 - def  //offset 3
 * 4 - ghi  //offset 6
 * 5 - jkl  //offset 9
 * 6 - mno  //offset 12
 * 7 - pqrs //offset 15
 * 8 - tuv  //offset 19
 * 9 - wxyz //offset 22
 * 0 - space //offset 26
 */

using System.Text;

int lettersCount = int.Parse(Console.ReadLine());

StringBuilder sms = new StringBuilder();

// VAR 2
int firstLetter = 'a';

for (int i = 0; i < lettersCount; i++)
{
    string letter = Console.ReadLine();
    int digit = int.Parse(letter) % 10;
    int digitRepeat = letter.Length;

    int offset = (digit - 2) * 3;

    if (digit == 8 || digit == 9)
    {
        offset++;
    }
    if (offset < 0) //0 is clicked
    {
        offset = -65;
    }

    int currentLetter = firstLetter + offset + digitRepeat - 1;
    sms.Append((char)currentLetter);
}

Console.WriteLine(sms);

//VAR1
/*
for (int i = 0; i < lettersCount; i++)
{
    int input = int.Parse(Console.ReadLine());

	switch (input)
	{
		case 2: sms.Append("a"); break;
		case 22: sms.Append("b"); break;
		case 222: sms.Append("c"); break;
        case 3: sms.Append("d"); break;
        case 33: sms.Append("e"); break;
        case 333: sms.Append("f"); break;
        case 4: sms.Append("g"); break;
        case 44: sms.Append("h"); break;
        case 444: sms.Append("i"); break;
        case 5: sms.Append("j"); break;
        case 55: sms.Append("k"); break;
        case 555: sms.Append("l"); break;
        case 6: sms.Append("m"); break;
        case 66: sms.Append("n"); break;
        case 666: sms.Append("o"); break;
        case 7: sms.Append("p"); break;
        case 77: sms.Append("q"); break;
        case 777: sms.Append("r"); break;
        case 7777: sms.Append("s"); break;
        case 8: sms.Append("t"); break;
        case 88: sms.Append("u"); break;
        case 888: sms.Append("v"); break;
        case 9: sms.Append("w"); break;
        case 99: sms.Append("x"); break;
        case 999: sms.Append("y"); break;
        case 9999: sms.Append("z"); break;
        case 0: sms.Append(" "); break;

        default: sms.Append(""); break;
	}
}

Console.WriteLine(sms);
*/

