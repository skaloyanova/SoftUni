namespace _01.Songs
{
    internal class Songs
    {
        static void Main(string[] args)
        {
            /* INPUT
             * On the first line, you will receive the number of songs - N.
             * On the next N lines, you will be receiving data in the following format:  "{typeList}_{name}_{time}".
             * On the last line, you will receive Type List or "all".
             */

            List<Song> lists = new ();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputSplit = Console.ReadLine().Split("_");       //{typeList}_{name}_{time}

                Song song = new Song()
                {
                    TypeList = inputSplit[0],
                    Name = inputSplit[1],
                    Time = inputSplit[2],
                };

                lists.Add(song);
            }

            /* OUTPUT
             * If you receive Type List as an input on the last line, print out only the names of the songs, which are from that Type List.
             * If you receive the "all" command, print out the names of all the songs.
             */
            string printList = Console.ReadLine();

            if (printList == "all")
            {
                lists.ForEach(e => Console.WriteLine(e.Name));
            }
            else
            {
                lists
                    .Where(e => e.TypeList == printList)
                    .ToList()
                    .ForEach(e => Console.WriteLine(e.Name));
            }
        }
    }

    public class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
    }
}