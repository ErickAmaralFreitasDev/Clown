namespace Clown
{
    interface IClown
    {
        public string FunnyThingIHave { get; }

        void Honk();
    }

    interface IScaryClown : IClown
    {
        public string ScaryThingIHave { get; }

        void ScareLittleChildren();
    }

    class FunnyFunny : IClown
    {
        private string funnyThingIHave;
        public string FunnyThingIHave
        {
            get { return funnyThingIHave; }
        }

        public FunnyFunny(string funnyThingIHave)
        {
            this.funnyThingIHave = funnyThingIHave;
        }

        public void Honk()
        {
            Console.WriteLine("Hi! I have a " + funnyThingIHave);
        }
    }

    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int scaryThingCount;

        public ScaryScary(string funnyThing, int scaryThingCount) : base(funnyThing)
        {
            this.scaryThingCount = scaryThingCount;
        }

        public string ScaryThingIHave
        {
            get { return $"{scaryThingCount} spiders"; }
        }

        public void ScareLittleChildren()
        {
            Console.WriteLine("BOO! I have a " + ScaryThingIHave);
        }
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

            IClown fingersTheClown = new ScaryScary("Big red nose", 14);
            fingersTheClown.Honk();
            if (fingersTheClown is IScaryClown iScaryClownReference)
            {
                iScaryClownReference.ScareLittleChildren();
            }
        }
    }
}