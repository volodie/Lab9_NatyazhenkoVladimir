
using Magazin;
using System.Text;

public class Program
{
    private static void Main(string[] args)
    {
        var clothes1 = new Jacket() { Cost = "10000", Size = 26 };
        var clothes2 = new T_shirt() { Cost = "9100", Size = 28 };
        var clothes3 = new T_shirt() { Cost = "820", Size = 29 };
        var clothes4 = new Jacket() { Cost = "9300", Size = 30 };
        var clothes5 = new T_shirt() { Cost = "9400", Size = 28 };
        var clothes6 = new T_shirt() { Cost = "9500", Size = 28 };
        var clothes7 = new Jacket() { Cost = "10000", Size = 26 };
        var clothes8 = new T_shirt() { Cost = "9100", Size = 28 };
        var clothes9 = new T_shirt() { Cost = "820", Size = 29 };
        var clothes10 = new Jacket() { Cost = "9300", Size = 30 };
        var clothes11 = new Jacket() { Cost = "10000", Size = 26 };
        var clothes12 = new T_shirt() { Cost = "9100", Size = 28 };
        var clothes13 = new T_shirt() { Cost = "820", Size = 29 };
        var clothes14 = new Jacket() { Cost = "9300", Size = 30 };
        var clothes15 = new Jacket() { Cost = "10000", Size = 26 };
        var clothes16 = new T_shirt() { Cost = "9100", Size = 28 };
        var clothes17 = new T_shirt() { Cost = "820", Size = 29 };
        var clothes18 = new Jacket() { Cost = "9300", Size = 30 };
        var clothes19 = new Jacket() { Cost = "10000", Size = 26 };
        var clothes20 = new T_shirt() { Cost = "9100", Size = 28 };
        var clothes21= new T_shirt() { Cost = "820", Size = 29 };
        var clothes22 = new Jacket() { Cost = "9300", Size = 30 };
        PrintDelegate DelegPrint = (string msg) => Console.WriteLine(msg);
        Magazine mag = new Magazine(DelegPrint);
        CounterClothes count = new CounterClothes();
        Counter c = new Counter(20);
        c.CountReached += c_CountReachedRedColour;
        count.OnCountRaise += c.Add;
        count.OnCountRaise += (i,j) => Console.WriteLine($"Added to magazin {i} clothes. Quantitiy clothes in magazine is {j}");

        
        mag.AddClothes(clothes1);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes2);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes3);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes4);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes5);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes6);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes7);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes8);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes9);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes10);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes11);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes12);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes13);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes14);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes15);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes16);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes17);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes18);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes19);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes20);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes21);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.AddClothes(clothes22);
        count.Raise(1, mag.clothesMagazine.Count);

        mag.UpdateClothes(clothes1, "1000000");
        mag.DeleteClothes(clothes6);
        count.Raise(1, mag.clothesMagazine.Count);
        mag.GetPopular();
        mag.GetAllClothes();
        
        static void c_CountReachedRedColour(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The magazin is full");
            Console.ResetColor();
        }

    }
    public class Counter
    {
        public event EventHandler CountReached;

        private int itemNumber;
        private int total;

        public Counter(int passItemNumber)
        {
            itemNumber = passItemNumber;
        }
        public void Add(int x, int y)
        {
            total += x;
            if (total >= itemNumber)
            {
                CountReached?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public class CounterClothes
    {
        public event Action<int, int> OnCountRaise;

        public void Raise(int i, int y)
        {
            OnCountRaise(i, y);
        }
    }
}


