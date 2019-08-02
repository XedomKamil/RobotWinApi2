using System;
using System.Windows.Forms;

namespace TestLambda
{

    public partial class Form1 : Form
    {

        public Form1()
        {
   
            InitializeComponent();

            SingleClickButtton buttton = new SingleClickButtton();

            buttton.Location = new System.Drawing.Point(26, 15);
            buttton.Name = "button22";
            buttton.Size = new System.Drawing.Size(282, 111);
            buttton.TabIndex = 0;
            buttton.Text = "button1";
            buttton.UseVisualStyleBackColor = true;
            //  buttton.Click += new System.EventHandler(this.button1_Click);
            panel1.Controls.Add(buttton);



            Counter c = new Counter(10);
            c.ThresholdReached += c_ThresholdReached;
            c.TotalIsNegative += c_TotalNegative;

            Console.WriteLine("adding 4");
            c.Add(4);
            Console.WriteLine("adding 4");
            c.Add(4);
            Console.WriteLine("adding 4");
            c.Add(4);

            Console.WriteLine("adding -66");
            c.Add(-66);

        }



        public class SingleClickButtton : Button

        {
            protected override void OnClick(EventArgs e)
            {

                Console.WriteLine("Kliknieto");
            }


        }
        static void c_TotalNegative(object sender, EventArgs e)
        {

            Console.WriteLine("The negative number.");
            // Environment.Exit(0);
        }


        static void c_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine(e.TimeReached);
            Console.WriteLine("The threshold was reached.");
            // Environment.Exit(0);
        }

        private delegate int Operation(int x);
        private delegate int Operation2(int xm, int x2);
        static int Transform(int value, Operation operation)
        {
            int result = operation(value);
            return result;
        }

        private static int Cube(int a) => a * a * a;


        private static int Square(int a) => a * a;
        private static int Plus2(int a, int b) => a + b;
        private static int Minus2(int a, int b) => a - b;



        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = new System.Windows.Forms.Button();


            Operation2 operation2 = (a, b) =>
            {
                Console.WriteLine("op2 start", a * b);
                return a * b;
            };
            //operation2 += Plus2;
            operation2 += Test(operation2);

            Console.WriteLine(operation2.Method);
            Console.WriteLine(operation2.Target);

        }

        static Operation2 Test(Operation2 operation2)
        {
            // Console.WriteLine(value);
            operation2 += Minus2;
            return operation2;
        }


    }



    class Counter
    {
        private int threshold;
        private int total;


        public Counter(int passedThreshold)
        {
            threshold = passedThreshold;
        }

        public void Add(int x)
        {
            total += x;
            if (total >= threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }


            if (total < 0)
            {
                Console.WriteLine("Total is neg");

                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnTotalIsNegative(args);
            }
        }



        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if (handler != null)
            {

                handler(this, e);
            }
        }
        protected virtual void OnTotalIsNegative(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = TotalIsNegative;

            if (handler != null)
            {

                handler(this, e);
            }
        }



        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        public event EventHandler<ThresholdReachedEventArgs> TotalIsNegative;
    }
    public class ThresholdReachedEventArgs : EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }





}
