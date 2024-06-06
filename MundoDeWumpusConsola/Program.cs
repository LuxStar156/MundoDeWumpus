using System;
using MundoDeWumpus;


namespace MundoDeWumpusConsola
{
    internal class Program
    {
        static bool terminar;
        static Mapa mapa;
        static int vidas;
        static int puntos;
        static int VolverJugar;

        private static void Juego()
        {
            Console.WriteLine(@"
      
(_______) |                        | |            | |        | || || |                             
 _____  | |   ____  _   _ ____   _ | | ___      _ | | ____   | || || |_   _ ____  ____  _   _  ___ 
|  ___) | |  |    \| | | |  _ \ / || |/ _ \    / || |/ _  )  | ||_|| | | | |    \|  _ \| | | |/___)
| |_____| |  | | | | |_| | | | ( (_| | |_| |  ( (_| ( (/ /   | |___| | |_| | | | | | | | |_| |___ |
|_______)_|  |_|_|_|\____|_| |_|\____|\___/    \____|\____)   \______|\____|_|_|_| ||_/ \____(___/ 
                                                                                 |_|                                                                                                   
            ");
 
            Console.WriteLine("Ingrese el tamaño del tablero. Solo se permiten tableros de 5x5 hasta 8x8");

            Console.Write("Filas: ");
            string aux = Console.ReadLine().Trim();

            Console.Write("Columnas: ");
            string aux2 = Console.ReadLine().Trim();

            if (int.TryParse(aux, out int filas) && int.TryParse(aux2, out int columnas))
            {
                if ((filas >= 5 && columnas >= 5) && (filas <= 8 && columnas <= 8))
                {
                    mapa = new Mapa(filas, columnas);
                    bool Juego = true;

                    while (Juego)
                    {
                        terminar = false;
                        mapa.PoblarTablero(filas, columnas);
                        mapa.PintarPantalla();

                        while (!terminar)
                        {
                            mapa.PintarPantalla();
                            mapa.Interactuar();
                            MoverPersonaje();

                        }

                        Console.WriteLine();
                        Console.WriteLine("Si quiere volver a jugar presione ' 1 '. De lo contrario, Presione cualquier otro numero");

                        VolverJugar = int.Parse(Console.ReadLine());

                        if (VolverJugar == 1 && mapa.Jugador.Vidas >= 1)
                        {
                            Juego = true;

                        }
                        else
                        {
                            Console.WriteLine("Que lastima, se le acabaron las vidas :(");
                            Juego = false;
                        }

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

            terminar = mapa.MoverJugador(nuevaFila, nuevaColumna);
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
