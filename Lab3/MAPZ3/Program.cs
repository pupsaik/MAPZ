using System.Threading.Channels;

namespace MAPZ3
{
    static class Program
    {
        static void Main()
        {
            Console.WriteLine("Authors:");
            foreach (Author author in Table.Authors)
            {
                Console.WriteLine(author);
            }

            Console.WriteLine("==============================================");

            Console.WriteLine("Songs:");
            foreach (Song song in Table.Songs)
            {
                Console.WriteLine(song);
            }

            Console.WriteLine("==============================================");


            Dictionary<uint, List<Song>> dictionary = Table.Songs.GroupBy(s => s.AuthorID).ToDictionary(s => s.Key, s => s.ToList());

            foreach (var pair in dictionary)
            {
                Console.WriteLine($"Author ID: {pair.Key}");
                foreach (var song in pair.Value)
                {
                    Console.WriteLine($"\t{song}");
                }
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Extention method:");

            Table.Songs.Print();

            Console.WriteLine("==============================================");
            Console.WriteLine("IComparer sorting:");

            List<Song> songs = Table.Songs.OrderBy(x => x, new SongNameComparer()).ToList();
            songs.ForEach(Console.WriteLine);

            Console.WriteLine("==============================================");
            Console.WriteLine("Queue:");

            Queue<Song> queue = new(Table.Songs);
            queue.Enqueue(new(8, "Busy Woman", 3));

            int queueLength = queue.Count;

            for (int i = 0; i < queueLength; i++)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Stack:");

            Stack<Author> stack = new(Table.Authors);
            stack.Push(new(8, "Tate McRae", "Canada"));

            int stackLength = stack.Count;

            for (int i = 0; i < stackLength; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Sorted List:");

            SortedList<string, uint> sortedList = new(Table.Songs.ToDictionary(s => s.Title, s => s.ID));

            foreach (var pair in sortedList)
            {
                Console.WriteLine(String.Format("{0} - {1}", pair.Key, pair.Value));
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Hash Set:");

            HashSet<string> hashSet = new(Table.Authors.Select(a => a.OriginCountry));

            foreach (var country in hashSet)
            {
                Console.WriteLine(country);
            }

            Console.WriteLine("==============================================");
            Console.WriteLine("Additional methods:");

            var subset1 = Table.Songs.Where(s => s.Title.Length > 5);

            Console.WriteLine("Songs with titles longer than 5 symbols:");
            foreach (var song in subset1)
            {
                Console.WriteLine(song);
            }
            Console.WriteLine();

            var subset2 = Table.Authors.Take(3).OrderBy(a => a.Name);
            Console.WriteLine("First three authors, sorted by name in ascending order:");
            foreach (var song in subset2)
            {
                Console.WriteLine(song);
            }
            Console.WriteLine();

            Console.WriteLine("Do we have an author with a letter \"k\" in their name?");
            Console.WriteLine(Table.Authors.Any(a => a.Name.Contains('k')));

            Console.WriteLine();

            Console.WriteLine("Authors sorted by quantity of songs:");
            

            var result1 = Table.Songs.GroupBy(s => s.AuthorID).Select(g => new { g.Key, Count = g.Count()});
            foreach (var item in result1)
            {
                Console.Write(item.Key + " ");
                Console.WriteLine(item.Value);
            }
            
        }
    }

    static class PrintSongNamesExtention
    {
        static public void Print(this List<Song> songs) => songs.ForEach(s => Console.WriteLine(s.Title));
    }

     class SongNameComparer : IComparer<Song>
     {
        public int Compare(Song x, Song y) => string.Compare(x.Title, y.Title, StringComparison.OrdinalIgnoreCase);
     }

    class Song(uint id, string title, uint authorID)
    {
        public uint ID { get; set; } = id;
        public string Title { get; set; } = title;
        public uint AuthorID { get; set; } = authorID;

        public override string ToString()
        {
            return String.Format("ID: {0}, Title: {1}, Author ID: {2}", ID, Title, AuthorID);
        }
    }

    class Author(uint id, string name, string originCountry)
    {
        public uint ID { get; set; } = id;
        public string Name { get; set; } = name;
        public string OriginCountry { get; set; } = originCountry;

        public override string ToString()
        {
            return String.Format("ID: {0}, Name: {1}, Origin Country: {2}", ID, Name, OriginCountry);
        }
    }

    class Table
    {
        public static List<Song> Songs => [
                new (1, "Club Classics", 1),
                    new (2, "Image", 2),
                    new (3, "Von Dutch", 1),
                    new (4, "Taste", 3),
                    new (5, "Take a Bite", 4),
                    new (6, "365", 1),
                    new (7, "Beaches", 4)
        ];

        public static List<Author> Authors => [
                new (1, "Charli XCX", "United Kingdom"),
                    new (2, "Magdalena Bay", "United States"),
                    new (3, "Sabrina Carpenter", "United States"),
                    new (4, "beabadoobee", "Philippines")
        ];
    }
}

//list авторів і їх к-ть пісень