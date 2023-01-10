using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin;

namespace Magazin
{
    public abstract class Clothes
    {
        public abstract string GetInfo();
        public abstract string UpdateCost(string a);
        public  int Size { get; set; }
    }

    
}
