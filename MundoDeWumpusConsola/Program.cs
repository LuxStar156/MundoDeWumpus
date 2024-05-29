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

                    while (!terminar)
                    {
                        MoverPersonaje();
                        mapa.PintarPantalla();
                        // Verificar estado del juego (ganar o perder)
                        VerificarEstadoJuego();
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

            mapa.MoverJugador(nuevaFila, nuevaColumna);
        }

        private static void VerificarEstadoJuego()
        {
            // Lógica para verificar si el jugador ha ganado o perdido
            Entidad entidadActual = mapa.ObtenerEntidad(mapa.Jugador.I, mapa.Jugador.J);
            if (entidadActual is Oro)
            {
                terminar = true;
                Console.WriteLine("¡Has encontrado el oro! ¡Has ganado!");
            }
            else if (entidadActual is Wumpus || entidadActual is Grieta)
            {
                terminar = true;
                Console.WriteLine("¡Has caído en una trampa o encontrado al Wumpus! ¡Has perdido!");
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