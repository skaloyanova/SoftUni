using System.Text;

namespace _09.PasswordValidator
{
    internal class PasswordValidator
    {
        static void Main(string[] args)
        {
            /* 
             * Checks if a given password is valid.
             *  It should contain 6 – 10 characters (inclusive)
             *  It should contain only letters and digits
             *  It should contain at least 2 digits 
             */

            // INPUT
            string password = Console.ReadLine();

            // LOGIC
            StringBuilder sb = new StringBuilder();

            bool isLengthValid = ValidatePasswordLength(password);
            bool isOnlyLettersDigitsValid = ValidatePasswordIsOnlyLettersDigits(password);
            bool isMinTwoDigitsValid = ValidatePasswordIsMinTwoDigits(password);

            if (isLengthValid && isOnlyLettersDigitsValid && isMinTwoDigitsValid)
            {
                sb.AppendLine("Password is valid");
            }

            if (!isLengthValid)
            {
                sb.AppendLine("Password must be between 6 and 10 characters");
            }

            if (!isOnlyLettersDigitsValid)
            {
                sb.AppendLine("Password must consist only of letters and digits");
            }

            if (!isMinTwoDigitsValid)
            {
                sb.AppendLine("Password must have at least 2 digits");
            }

            // OUTPUT
            Console.WriteLine(sb);

        }

        // METHODs
        static bool ValidatePasswordLength(string text)
        {
            return text.Length >= 6 && text.Length <= 10;
        }

        static bool ValidatePasswordIsOnlyLettersDigits(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (!Char.IsLetterOrDigit(text[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool ValidatePasswordIsMinTwoDigits(string text)
        {
            int digitCount = 0;

            // VAR 1

            //for (int i = 0; i < text.Length; i++)
            //{
            //    string currentSymbol = "" + text[i];
            //    try
            //    {
            //        int.Parse(currentSymbol);
            //        digitCount++;
            //    }
            //    catch (Exception)
            //    {
            //    }

            //    if (digitCount == 2)
            //    {
            //        return true;
            //    }
            //}

            //return false;


            // VAR 2

            foreach (char c in text)
            {
                if (Char.IsDigit(c))
                {
                    digitCount++;
                }

                if (digitCount == 2)
                {
                    return true;
                }
            }

            return false;


            // VAR 3
            //foreach (char c in text)
            //{
            //    if (c >= 48 && c <= 57) //ASCII code
            //    {
            //        digitCount++;
            //    }

            //    if (digitCount == 2)
            //    {
            //        return true;
            //    }
            //}

            //return false;
        }
    }
}