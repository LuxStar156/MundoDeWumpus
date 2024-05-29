using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoDeWumpus
{
    public class Wumpus : Entidad
    {
        public Wumpus(int i, int j) : base("Wumpus", i, j)
        {
        }

        public static void AdyacenteGrieta()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Se siente un mal olor cerca");
            Console.ResetColor();

        }

    }

}
