namespace Clown
{
    class TallGuy : IClown
    {
        public string Name;
        public int Height;
        public string FunnyThingIHave { get {return "big shoes"; } }

        public void TalkAboutYourself()
        {
            Console.WriteLine($"Hi, my name is {Name} and I am {Height} inches tall.");
        }

        public void Honk()
        {
            Console.WriteLine("Honk Honk!");
        }
    }

    interface IClown
    {
        public string FunnyThingIHave { get; }

        void Honk();
    }

    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy()
            {
                Name = "Big Joe",
                Height = 72
            };
            tallGuy.TalkAboutYourself();
            Console.WriteLine($"I have {tallGuy.FunnyThingIHave}.");
            tallGuy.Honk();
        }
    }
}