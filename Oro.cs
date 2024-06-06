using System;


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
