using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoDeWumpus
{
    public class Oro : Entidad
    {
        public Oro(int i, int j) : base("Oro", i, j)
        {
        }

        public static void AdyacenteOro()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Se puede ver un resplandor cerca");
            Console.ResetColor();

        }
    }

}
