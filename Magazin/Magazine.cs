using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public delegate void PrintDelegate(string msg);
    public class Magazine
    {
        public List<Clothes> clothesMagazine = new List<Clothes>();

        //PrintDelegate printDelegate = (string msg) => { Console.WriteLine(msg); };

        private PrintDelegate DelegatePrint;

        public Magazine(PrintDelegate printDelegate)
        {
            DelegatePrint = printDelegate;
        }
        public void AddClothes(Clothes clothes)
        {
            clothesMagazine.Add(clothes);
            DelegatePrint($"Clothe added: {clothes.GetInfo()}");
        }
        public void DeleteClothes(Clothes clothes)
        {
            clothesMagazine.Remove(clothes);
            DelegatePrint($"Clothe deleted: {clothes.GetInfo()}");
        }

        public void UpdateClothes(Clothes clothes, string newValue)
        {
            int i = clothesMagazine.IndexOf(clothes);
            clothesMagazine[i].UpdateCost(newValue);
            DelegatePrint($"Clothe updated: {clothesMagazine[i].GetInfo()}");
        }

        public void GetPopular()
        {
            int[] array = new int[clothesMagazine.Count];
            int i = 0;
            foreach (var ch in clothesMagazine)
            {
                array[i] = ch.Size;
                i++;
            }
            var result = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault().Key;
            DelegatePrint($"Most popular size : {result}\n");
        }
        public void GetAllClothes()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("List of all clothes:\n");
            foreach (var ch in clothesMagazine)
            {
                sb.Append(ch.GetInfo());
            }
            DelegatePrint(sb.ToString());
        }
    }
}
