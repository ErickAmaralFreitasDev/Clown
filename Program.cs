namespace Clown
{
    interface IClown
    {
        public string FunnyThingIHave { get; }

        void Honk();

        protected static Random random = new Random();
        private static int carCapacity = 12;

        public static int CarCapacity
        {
            get { return carCapacity; }
            set
            {
                if (value > 10)
                {
                    carCapacity = value;
                }
                else
                {
                    Console.Error.WriteLine($"{value} is too small for a clown car. It must be greater than 10.");
                }
            }
        }

        public static string ClownCarDescription() => $"A car clown with {random.Next(CarCapacity / 2, CarCapacity)} clowns in it.";

    }

    interface IScaryClown : IClown
    {
        public string ScaryThingIHave { get; }

        void ScareLittleChildren();

        void ScareAdults() {
            Console.WriteLine($@"I am an ancient evil that will haunt your dreams. Behold my terrifying necklace with {random.Next(4, 10)} of my last victims' fingers. Oh, also, before I forget, "); 
            ScareLittleChildren();
        }
    }

    class FunnyFunny : IClown
    {
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get => funnyThingIHave; 
        }

        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        public void Honk() => Console.WriteLine("Hi! I have a " + funnyThingIHave);
    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private readonly int scaryThingCount;

        public ScaryScary(string funnyThing, int scaryThingCount) : base(funnyThing)
        {
            this.scaryThingCount = scaryThingCount;
        }

        public string ScaryThingIHave
        {
            get => $"{scaryThingCount} spiders";
        }

        public void ScareLittleChildren() => Console.WriteLine("BOO! I have a " + ScaryThingIHave);

    }

    /*class TallGuy : IClown
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
    }*/

    class Program
    {
        static void Main(string[] args)
        {
            /*TallGuy tallGuy = new TallGuy()
            {
                Name = "Big Joe",
                Height = 72
            };
            tallGuy.TalkAboutYourself();*/

            IClown.CarCapacity = 18;
            Console.WriteLine(IClown.ClownCarDescription());
            IClown fingersTheClown = new ScaryScary("Big red nose", 14);
            fingersTheClown.Honk();
            if (fingersTheClown is IScaryClown iScaryClownReference)
            {
                iScaryClownReference.ScareAdults();
            }
        }
    }
}