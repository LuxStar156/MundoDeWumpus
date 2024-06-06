using System;
using System.Text.Json;
using MundoDeWumpus;
using System.IO;


namespace MundoDeWumpusConsola
{
    internal class Program
    {
        /// <summary>
        /// Se inicializan las variables que se utilizarán en el juego
        /// </summary>
        static bool terminar;
        static Mapa mapa;
        static int vidas;
        static int puntos;
        static int VolverJugar;

        /// <summary>
        /// Funcion principal del juego, donde se inicializa el tablero y se inicia el juego
        /// junto a todas sus interacciones y funciones de la clase mapa
        /// </summary>
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

        /// <summary>
        /// Funcion que permite mover al personaje en el tablero utilizando las flechas del teclado
        /// </summary>
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

        /*
        static void MainSerial()
        {
            Console.WriteLine("Bienvenido a Wumpus Serial!");
            Wumpus wumpus = new Wumpus(5, 5);

            string archivo = "wumpus.json";
            GuardarEnArchivo(wumpus, archivo);
            Console.WriteLine($"Objeto serializado y guardado como {archivo}");

            Wumpus deserializado = LeerDeArchivo(archivo);
            Console.WriteLine("Objeto deserializado de JSON:");
            Console.WriteLine(deserializado);
        }

        static void GuardarEnArchivo(Wumpus wumpus, string archivo)
        {
            string jsonString = JsonSerializer.Serialize(wumpus);
            File.WriteAllText(archivo, jsonString);
        }

        static Wumpus LeerDeArchivo(string archivo)
        {
            string jsonString = File.ReadAllText(archivo);
            return JsonSerializer.Deserialize<Wumpus>(jsonString);
        }

        */

        /// <summary>
        /// Funcion principal del programa
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
          
            Juego();
            //MainSerial();

            Console.WriteLine();
            Console.WriteLine("Presione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
    }
}
