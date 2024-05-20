using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MundoDeWumpus;

namespace MundoDeWumpusConsola
{
    internal class Program
    {
        static Boolean ganar = false;
        static int jugadorFila;
        static int jugadorColumna;

        private static void Juego()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el tamaño del tablero. Solo se permiten tableros de 5x5 hasta 8x8");

            Console.Write("Filas: ");
            String aux = Console.ReadLine().Trim();

            Console.Write("Columnas: ");
            String aux2 = Console.ReadLine().Trim();

            int elementosA = 0;
            int elementosB = 0;

            if (int.TryParse(aux, out elementosA) && int.TryParse(aux2, out elementosB))
            {
                if ((elementosA >= 5 && elementosB >= 5) && (elementosA <= 8 && elementosB <= 8))
                {
            

                    Console.WriteLine("Presiona ENTER para comenzar");

                    while (!ganar)
                    {
                        MoverPersonaje(ref matriz);
                        PintarPantalla(ref matriz);
                        Interactuar(ref matriz, jugadorFila, jugadorColumna, ref ganar);

                    }
                }
                else
                {
                    Console.WriteLine("El número de elementos debe ser mayor o igual a 5 y menor o igual que 8");
                }
            }
            else
            {
                Console.WriteLine("Debe ingresar una unidad numérica entera");
            }

        }


        private static void MoverPersonaje(ref String[,] matriz)
        {
            ConsoleKeyInfo tecla = Console.ReadKey();

            matriz[jugadorFila, jugadorColumna] = " ";

            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    if (jugadorFila > 0)

                        jugadorFila--;

                    break;

                case ConsoleKey.DownArrow:
                    if (jugadorFila < matriz.GetLength(0) - 1)

                        jugadorFila++;

                    break;

                case ConsoleKey.LeftArrow:
                    if (jugadorColumna > 0)

                        jugadorColumna--;

                    break;

                case ConsoleKey.RightArrow:
                    if (jugadorColumna < matriz.GetLength(1) - 1)

                        jugadorColumna++;

                    break;
            }

            if (matriz[jugadorFila, jugadorColumna] == null || matriz[jugadorFila, jugadorColumna] == " ")
            {
                matriz[jugadorFila, jugadorColumna] = "J";
            }


        }

        static void Main(string[] args)
        {
            Juego();

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
