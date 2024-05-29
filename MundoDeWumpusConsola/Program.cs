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
        static bool terminar = false;
        static Mapa mapa; // Declarar el objeto Mapa

        private static void Juego()
        {
            Console.Clear();
            Console.WriteLine("Ingrese el tamaño del tablero. Solo se permiten tableros de 5x5 hasta 8x8");

            Console.Write("Filas: ");
            string aux = Console.ReadLine().Trim();

            Console.Write("Columnas: ");
            string aux2 = Console.ReadLine().Trim();

            if (int.TryParse(aux, out int filas) && int.TryParse(aux2, out int columnas))
            {
                if ((filas >= 5 && columnas >= 5) && (filas <= 8 && columnas <= 8))
                {
                    mapa = new Mapa(filas, columnas); // Inicializar el objeto Mapa
                    mapa.PintarPantalla();
                    Console.WriteLine("Presiona ENTER para comenzar");
                    Console.ReadLine();

                    while (!terminar)
                    {
                        mapa.PintarPantalla();
                        MoverPersonaje();
                        
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

        private static void MoverPersonaje()
        {
            ConsoleKeyInfo tecla = Console.ReadKey();

            int nuevaFila = mapa.Jugador.I;
            int nuevaColumna = mapa.Jugador.J;

            switch (tecla.Key)
            {
                case ConsoleKey.UpArrow:
                    nuevaFila--;
                    break;
                case ConsoleKey.DownArrow:
                    nuevaFila++;
                    break;
                case ConsoleKey.LeftArrow:
                    nuevaColumna--;
                    break;
                case ConsoleKey.RightArrow:
                    nuevaColumna++;
                    break;
            }

            terminar= mapa.MoverJugador(nuevaFila, nuevaColumna);
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
