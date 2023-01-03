using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magazin
{
    public class ViewAllInformation : IAllInformationVieawable
    {
            public void PrintToConsole(string str)
            {
                Console.WriteLine(str);
            }
    }
}
