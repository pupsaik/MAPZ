namespace ClassLibrary1
{
    interface ISwimming
    {
        void Swim();
    }

    struct Dolphin
    {
        void Surface() { Console.WriteLine("I'm breathing"); }
        int Age { get; set; }
        string _specie;
    }

    class Pufferfish
    {
        public static string Ocean = "Pacific";
        public static int Population;

        public string Name = "Default Fugu";
        public double Length;
        public bool IsPoisonous;

        static Pufferfish()
        {
            Population = 10000;
            Console.WriteLine("Static constructor: Population set.");
        }

        public Pufferfish(string name, double length, bool isPoisonous)
        {
            Name = name;
            Length = length;
            IsPoisonous = isPoisonous;
            Console.WriteLine($"Constructor: Created {Name}, {Length}cm, Poisonous: {IsPoisonous}");
        }
    }

    public static class StaticClass
    {
        public static int Depth;

        public static void StaticMethod()
        {
            Depth++;
        }

        public static void Recursive()
        {
            Depth++;
            Recursive();
        }
    }

    public class Class
    {
        public int Depth;

        public void Method()
        {
            Depth++;
        }

        public void Recursive()
        {
            Depth++;
            Recursive();
        }
    }

    public class Celsius
    {
        public double Temperature { get; set; }
        public static implicit operator Celsius(Farenheit temperature) => new() { Temperature = (temperature.Temperature - 32) * 5 / 9 };
    }

    public class Farenheit
    {
        public double Temperature { get; set; }
        public static explicit operator Farenheit(Celsius temperature) => new() { Temperature = temperature.Temperature * 9 / 5 + 32 };
    }

    enum Permissions
    {
        None = 0,
        Read = 1,
        Write = 2,
        Execute = 4,
        Delete = 8
    }

}
