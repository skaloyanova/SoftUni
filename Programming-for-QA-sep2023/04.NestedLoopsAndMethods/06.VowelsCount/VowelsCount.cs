namespace _06.VowelsCount
{
    internal class VowelsCount
    {
        static void Main(string[] args)
        {
            // INPUT
            string text = Console.ReadLine();

            // OUTPUT
            Console.WriteLine(CountVowels(text));
        }

        // METHOD
        static int CountVowels(string text)
        {
            int count = 0;
            text = text.ToLower();

            for (int i = 0; i < text.Length; i++)
            {
                switch (text[i])
                {
                    case 'a':
                    case 'o':
                    case 'u':
                    case 'e':
                    case 'i': count++; break;
                }
            }
            return count;
        }
    }
}