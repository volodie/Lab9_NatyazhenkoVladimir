
using Magazin;
using System.Text;

internal class Program
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

        Magazine list = new Magazine();
        CounterClothes count = new CounterClothes();
        Counter c = new Counter(20);
        c.CountReached += c_CountReachedRedColour;
        count.OnCountRaise += c.Add;
        count.OnCountRaise += (i,j) => Console.WriteLine($"Added to magazin {i} clothes. Quantitiy clothes in magazine is {j}");

        PrintDelegate printDelegate = (string msg) => { Console.WriteLine(msg); };
       
        list.AddClothes(clothes1, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes2, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes3, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes4, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes5, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes6, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes7, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes8, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes9, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes10, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes11, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes12, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes13, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes14, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes15, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes16, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes17, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes18, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes19, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes20, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes21, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.AddClothes(clothes22, printDelegate);
        count.Raise(1, Magazine.clothes.Count);

        list.UpdateClothes(clothes1, "1000000", printDelegate);
        list.DeleteClothes(clothes6, printDelegate);
        count.Raise(1, Magazine.clothes.Count);
        list.GetPopular( printDelegate);
        list.GetAllClothes( printDelegate);
        
        static void c_CountReachedRedColour(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The magazin is full");
            Console.ResetColor();
        }

    }
        
}

public delegate void PrintDelegate(string msg);


public class Magazine
{
    public static List<Clothes> clothes = new List<Clothes>();

    public void AddClothes(Clothes clothes, PrintDelegate output)
    {

        Magazine.clothes.Add(clothes);

        output($"Clothe added: {clothes.GetInfo()}");

    }
    public void DeleteClothes(Clothes clothes, PrintDelegate output)
    {
        Magazine.clothes.Remove(clothes);
        output($"Clothe deleted: {clothes.GetInfo()}");
    }

    public void UpdateClothes(Clothes clothes, string newValue, PrintDelegate output)
    {
        int i = Magazine.clothes.IndexOf(clothes);
        Magazine.clothes[i].UpdateCost(newValue);
        output($"Clothe updated: {Magazine.clothes[i].GetInfo()}");
    }

    public void GetPopular(PrintDelegate output)
    {
        int[] array = new int[Magazine.clothes.Count];
        int i = 0;
        foreach (var ch in Magazine.clothes)
        {
            array[i] = ch.Size;
            i++;
        }
        var result = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault().Key;
        output($"Most popular size : {result}\n");
    }
    public void GetAllClothes(PrintDelegate output)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("List of all clothes:\n");
        foreach (var ch in Magazine.clothes)
        {
           sb.Append(ch.GetInfo());
        }
        output(sb.ToString());
    }
   
}
class Counter
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

class CounterClothes 
{
    public event Action<int, int> OnCountRaise;

    public void Raise(int i, int y)
    {
        OnCountRaise(i,y);
    }
}
