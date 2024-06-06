using System;


namespace MundoDeWumpus
{
    public class Grieta : Entidad
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
