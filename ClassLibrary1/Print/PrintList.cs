using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Print
{
    public static class PrintList
    {
        public static void PrintOut<T>(IList<T> list)
        {
            Console.WriteLine(string.Join(',', list));
        }
    }
}
