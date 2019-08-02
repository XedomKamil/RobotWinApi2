namespace TEST1
{
    class Program
    {
        static void Main(string[] args)
        {
            WinterTire tire = new WinterTire("192");
            Auto auto = new Auto(tire);
            System.Console.Write(auto.tire.TireName);
            System.Console.Write(", ");
            System.Console.Write(auto.tire.MinTemp);
            System.Console.Write("-");
            System.Console.WriteLine(auto.tire.MaxTemp);

            SummerTire tire2 = new SummerTire("122");
            auto = new Auto(tire2);
            System.Console.Write(auto.tire.TireName);
            System.Console.Write(", ");
            System.Console.Write(auto.tire.MinTemp);

            //System.Console.Write("-");
            //System.Console.WriteLine(auto.tire.MaxTemp);

            System.Console.ReadLine();
        }
    }



    public class Auto
    {
        public Tire tire;
        public Auto(Tire tire)
        {
            this.tire = tire;
        }
    }

    public interface Tire
    {
        string TireName { get; set; }
        int MinTemp { get; set; }
        int MaxTemp { get; set; }
    }

    public class WinterTire : Tire
    {
        public string TireName { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public WinterTire(string TireName)
        {
            this.TireName = TireName;
            MinTemp = -23;
            MaxTemp = 10;
        }
    }

    public class SummerTire : Tire
    {
        public string TireName { get; set; }
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
        public SummerTire(string TireName)
        {
            this.TireName = TireName;
            MinTemp = -2;
            MaxTemp = 50;
        }
    }

}
