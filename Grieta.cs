using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoDeWumpus
{
    internal class Grieta : Entidad
    {
        public Grieta(int i, int j) : base("Grieta", i, j)
        {
        }

        public static void AdyacenteGrieta()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Se siente una brisa cerca");
            Console.ResetColor();

        }
    }
}
